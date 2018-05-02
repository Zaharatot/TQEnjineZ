using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        /// Формируемое финальное изображение
        /// </summary>
        private WriteableBitmap Image;
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
        public WriteableBitmap GetFinalImage {
            get {
                return Image;
            }
        }


        /// <summary>
        /// Инициализация изображения
        /// </summary>
        /// <param name="Background">Фон изображения</param>
        public zBitmap(BitmapImage Background)
        {
            //Инициализируем список слоёв
            layers = new Dictionary<string, zBitmapLayer>();
            //Добавляем слой фона
            layers.Add("Background", CreateLayer(Background, true, 100));
            //Записываем высоту и ширину картинки
            width = Background.PixelWidth;
            height = Background.PixelHeight;
        }

        /// <summary>
        /// Формируем слой изображения
        /// </summary>
        /// <param name="Visible">Видимость слоя</param>
        /// <param name="Opacity">Прозрачность слоя</param>
        /// <param name="Image">Изначальная картинка, для слоя</param>
        /// <returns>Слой изображения</returns>
        private zBitmapLayer CreateLayer(BitmapImage Image, bool Visible, byte Opacity)
        {
            int bytesInPixel, pxCt, channelsCt, stride;
            byte[] pixArr;
            //Выходной массив пикселов
            List<zBitmapPixel> ex = new List<zBitmapPixel>();

            //Считаем количество байт на пиксель, в исходной картинке
            bytesInPixel = Image.Format.BitsPerPixel / 8;
            //Если у нас 4 байта на пиксель, то всё ок
            if (bytesInPixel == 4)
            {
                //Считаем общее количество пикселов
                pxCt = (int)Image.PixelWidth * (int)Image.PixelWidth;
                //Считаем общее количество каналов (цветов на пиксель)
                channelsCt = pxCt * bytesInPixel;
                //Считаем размер шага (чёрт его знает, просто слизал с примера, вроде пашет)
                stride = (Image.PixelWidth * Image.Format.BitsPerPixel) / 8;
                //Инициализируем массив, для получения пикселов
                pixArr = new byte[channelsCt];
                //Сливаем все пиксели картинки
                Image.CopyPixels(pixArr, stride, 0);

                //Проходимся по всем каналам
                for(int i = 0; i < channelsCt; i+= bytesInPixel)
                    //Добавляя пиксели в список, помня, что формат у нас - BGRA
                    ex.Add(new zBitmapPixel() {
                        Blue = pixArr[i],
                        Green = pixArr[i + 1],
                        Red = pixArr[i + 2],
                        Alpha = pixArr[i + 3]
                    });                
            }
            //Иначе - вернём пустую картинку

            //Возвращаем слой, с указанными параметрами
            return new zBitmapLayer(ex.ToArray(), Visible, Opacity);
        }

        /// <summary>
        /// Формируем все слои в готовую картинку
        /// </summary>
        /// <returns>Готовая картинка</returns>
        private WriteableBitmap compileLayers()
        {

        }
    }
}
