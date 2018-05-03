using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;


namespace TQEnjineZ.Clases.Wrappers.zBitmap
{
    /// <summary>
    /// Формат картинки, для движка. Изображение, поддерживающее слои.
    /// </summary>
    class zBitmap
    {

        //Смешивание 3 картинок 250х250 идёт аж 0,3 секунды! Нужно ускорять...
        //3 картинки 1500х1500 обрабатываются 9 секунд =_=. очень фейловый результат.
        //UPDATE
        //Довёл скорость обработки трёх картинок 1500х1500 до 3,14 секунд. Прогресс =_=
        //Правда, при этом перестало работать всё
        //UPDATE2
        //Довёл скорость обработки трёх слоёв по 1500х1500, до 1,15 секунд
        //(Правда теперь, формирование картинки происходит при её выводе)
        //Зато - поправил все косяки
        //Update3
        //Изменение формулы на дефолтную из вики дало прирост до 1 секунды
        //Update3,5
        //Мелкая правка дала прирост до 0,93 секунд
        //Update4
        //Довёл время обработки 3 слоёв до 0,522 секунд
        //Пилять... Перевёл на байты, теперь косяк с цветами >_<
        //Да и с рассчётом альфа канала тоже...
        //Update5.
        //Пофиксил проблему с цветами. Текущее время работы - 0,58 секунд...
        //Многовато, конечно, но в целом - приемлемо. 
        //Если грузить кучу картинок такого формата в разных потоках - то даже сойдёт.


        /// <summary>
        /// Список слоёв, по их именам
        /// </summary>
        private Dictionary<string, zBitmapLayer> layers;

        /// <summary>
        /// Ширина картинки
        /// </summary>
        private int width;
        /// <summary>
        /// Высота картинки
        /// </summary>
        private int height;

        /// <summary>
        /// Финальное изображение, генерируемое в этом классе
        /// </summary>
        public WriteableBitmap GetFinalImage
        {
            get
            {
                //Компилируем слои, при запросе картинки
                return compileLayers();
            }
        }


        /// <summary>
        /// Инициализация изображения
        /// </summary>
        /// <param name="Background">Фон изображения</param>
        public zBitmap(BitmapImage Background)
        {
            //Записываем высоту и ширину картинки
            width = Background.PixelWidth;
            height = Background.PixelHeight;
            //Инициализируем список слоёв
            layers = new Dictionary<string, zBitmapLayer>();
            //Добавляем слой фона, в начало порядка слоёв
            addLayer("Background", Background, 0, true, 100);
        }
        

        /// <summary>
        /// Добавляем нвоый слой в список
        /// </summary>
        /// <param name="name">Имя слоя</param>
        /// <param name="Image">Картинка слоя</param>
        /// <param name="zIndex">Индекс слоя в порядке слоёв</param>
        /// <param name="Visible">Видимость слоя</param>
        /// <param name="Opacity">Прозрачность слоя</param>
        public void addLayer(string name, BitmapImage Image, int zIndex, bool Visible, byte Opacity)
        {
            //Добавляем новый слой в словарь
            layers.Add(name, new zBitmapLayer(Image, zIndex, Visible, Opacity));
        }

        /// <summary>
        /// Изменяем слой
        /// </summary>
        /// <param name="name">Имя слоя</param>
        /// <param name="Image">Картинка слоя</param>
        /// <param name="zIndex">Индекс слоя в порядке слоёв</param>
        /// <param name="Visible">Видимость слоя</param>
        /// <param name="Opacity">Прозрачность слоя</param>
        public void editLayer(string name, BitmapImage Image = null, int? zIndex = null, bool? Visible = null, byte? Opacity = null)
        {
            //Если такой слой есть
            if(layers.ContainsKey(name))
            {
                //Получаем слой
                var layer = layers[name];
                //Обновляем картинку, если нужно
                if (Image != null)
                    layer.updateImage(Image);

                //Обновляем порядок, если нужно
                if (zIndex != null)
                    layer.ZIndex = zIndex.Value;

                //Обновляем видимость, если нужно
                if (Visible != null)
                    layer.Visible = Visible.Value;

                //Обновляем прозрачность, если нужно
                if (Opacity != null)
                    layer.Opasity = Opacity.Value;

                //Сохраняем изменённый слой
                layers[name] = layer;
            }
        }

        /// <summary>
        /// Удаляем указанный слой
        /// </summary>
        /// <param name="name">Имя слоя</param>
        public void removeLayer(string name)
        {
            //Если такой слой есть
            if (layers.ContainsKey(name))
            {
                //Удаляем его
                layers.Remove(name);
            }
        }

        /// <summary>
        /// Формируем все слои в готовую картинку
        /// </summary>
        /// <returns>Готовая картинка</returns>
        private WriteableBitmap compileLayers()
        {
            //Создаём картинку, для вывода на неё пикселов
            WriteableBitmap ex = new WriteableBitmap(width, height, 140, 140, PixelFormats.Bgra32, null);
         /*   try
            {*/
                int i = 0;
                //Формируем список из всех слоёв
                zBitmapLayer[] layersList = new zBitmapLayer[layers.Count];
                //Превращаем словарь в список
                foreach (var layer in layers)
                    //Добавляем слой в список, только если он видимый
                    if (layer.Value.Visible)
                        layersList[i++] = layer.Value;

                //Сортируем список слоёв, по индексу расположения
                //Располагаем их в порядке возрастания
                Array.Sort(layersList, delegate (zBitmapLayer a, zBitmapLayer b)
                {
                    return a.ZIndex.CompareTo(b.ZIndex);
                });

                //Формируем из кучи слоёв один
                var imagePixels = mixLayersPixels(layersList);
                //Множим ширину, на количество байт в цвете
                int stride = width * 4;

                //Формируем картинку
                ex.WritePixels(new Int32Rect(0, 0, width, height), imagePixels, stride, 0);                
         /*   }
            catch { }
            */
            //Возвращаем картинку
            return ex;
        }

      

        /// <summary>
        /// Формируем один массив пикселов, из кучи слоёв
        /// </summary>
        /// <param name="layersList"></param>
        /// <returns></returns>
        private byte[] mixLayersPixels(zBitmapLayer[] layersList)
        {
            byte[] buff;
            //Получаем длинну массива пикселов фона
            int countPixels = width * height;
            //Формируем выходной массив
            byte[] ex;
            //Получаем количество слоёв
            int layersCount = layersList.Length;
            //Если слои есть
            if (layersCount > 0)
            {
                //Запоминаем нулевой слой
                buff = layersList[0].getLayer;
                //Проходимся по слоям
                for (int i = 1; i < layersCount; i++)
                    //Миксим текущий слой, как слой переднего плана, с 
                    //запомненным слоем, как слоем фона, запоминая 
                    //получившийся в итоге слой
                    buff = layersList[i].mixPixelColors(buff);
                ex = buff;
            }
            //Если слоёв нету, то возвращаем пустой массив
            else
                ex = new byte[0];
            //Возвращаем массив пикселов
            return ex;
        }

    }
}
