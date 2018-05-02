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
        public WriteableBitmap GetFinalImage { get; private set; }


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
            //Формируем выходную картинку изо всех слоёв
            this.GetFinalImage = compileLayers();
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
                //Формируем выходную картинку изо всех слоёв
                this.GetFinalImage = compileLayers();
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
                //Формируем выходную картинку изо всех слоёв
                GetFinalImage = compileLayers();
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

            try
            {
                //Формируем список из всех слоёв
                List<zBitmapLayer> layersList = new List<zBitmapLayer>();
                //Превращаем словарь в список
                foreach (var layer in layers)
                    //Добавляем слой в список, только если он видимый
                    if (layer.Value.Visible)
                        layersList.Add(layer.Value);

                //Сортируем список слоёв, по индексу расположения
                //Располагаем их в порядке возрастания
                layersList.Sort(delegate (zBitmapLayer a, zBitmapLayer b)
                {
                    return a.ZIndex.CompareTo(b.ZIndex);
                });

                //Формируем из кучи слоёв один
                var imagePixels = compilelayers(layersList);
                //Превращаем список пикселов, в массив байтов
                var bytes = compilePixelArrayByteArray(imagePixels);
                //Множим ширину, на количество байт в цвете
                int stride = width * 4;
                //Формируем картинку
                ex.WritePixels(new Int32Rect(0, 0, width, height), bytes, stride, 0);
            }
            catch { }

            //Возвращаем картинку
            return ex;
        }

        /// <summary>
        /// Смешиваем пиксели
        /// </summary>
        /// <param name="pixels">Список смешиваемых пикселей</param>
        /// <returns>Итоговый пиксель</returns>
        private zBitmapPixel blendPixels(List<zBitmapPixel> pixels)
        {
            zBitmapPixel ex;

            //Если есть хоть один слой
            if(pixels.Count > 0)
            {
                //берём пиксель прового в порядке слоя, как фон
                ex = pixels.First();
                //Проходимся по всем последующим слоям
                for (int i = 1; i < pixels.Count; i++)
                    //Смешивая цвета фона, с новыми пикселями
                    ex = ex.mixPixelColors(pixels[i]);
            }
            else
                //Если слоёв нету, то заливаем белым прозрачным цветом
                ex = new zBitmapPixel()
                {
                    Red = 255,
                    Green = 255,
                    Blue = 255,
                    Alpha = 0
                };

            return ex;
        }

        /// <summary>
        /// Формируем один массив пикселов, из кучи слоёв
        /// </summary>
        /// <param name="layersList"></param>
        /// <returns></returns>
        private zBitmapPixel[] compilelayers(List<zBitmapLayer> layersList)
        {
            List<zBitmapPixel> buff;
            //Получаем длинну массива пикселов фона
            int countPixels = width * height;
            //Формируем выходной массив
            zBitmapPixel[] ex = new zBitmapPixel[countPixels];

            //Проходимся по выходному массиву
            for(int i = 0; i < countPixels; i++)
            {
                buff = new List<zBitmapPixel>();
                //Проходимся по массиву слоёв
                foreach (var layer in layersList)
                    //Если пиксели слоя не кончились, записываем пиксель
                    if (i < layer.getLayer.Length)
                        buff.Add(layer.getLayer[i]);

                //Смешиваем пиксели со всех имеющихся слоёв
                ex[i] = blendPixels(buff);
            }

            //Возвращаем массив пикселов
            return ex;
        }

        /// <summary>
        /// Превращаем массив пикселов, в мкассив байтов
        /// </summary>
        /// <param name="pixels">Массив пикселов</param>
        /// <returns>Массив байтов</returns>
        private byte[] compilePixelArrayByteArray(zBitmapPixel[] pixels)
        {
            //Формируем массив пикселов, на 4 канала
            int countchannels = width * height * 4;
            byte[] ex = new byte[countchannels];
            int i = 0;

            //Записываем все пикселы в массив байтов, не забывая, что у нас модель BGRA
            foreach (var pixel in pixels)
            {
                ex[i++] = pixel.Blue;
                ex[i++] = pixel.Green;
                ex[i++] = pixel.Red;
                ex[i++] = pixel.Alpha;
            }

            return ex;
        }
    }
}
