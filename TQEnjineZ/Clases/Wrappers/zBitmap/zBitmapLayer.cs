using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace TQEnjineZ.Clases.Wrappers.zBitmap
{
    /// <summary>
    /// Класс слоя картинки
    /// </summary>
    class zBitmapLayer
    {
        /// <summary>
        /// Картинка слоя, в формате массива пикселов
        /// </summary>
        private zBitmapPixel[] Image;
        /// <summary>
        /// Свойство видимости слоя
        /// </summary>
        public bool Visible;
        /// <summary>
        /// Прозрачность слоя. Значения от 0 до 100
        /// </summary>
        private byte OpacityValue;
        /// <summary>
        /// Индекс расположения данного слоя
        /// </summary>
        public int ZIndex;

        /// <summary>
        /// Публичное свойство, позволяющее менять прозрачность слоя
        /// </summary>
        public byte Opasity
        {
            get
            {
                return OpacityValue;
            }
            set
            {
                //Указываем, что больше 100 быть не может,
                //а меньше 0 тип byte не пустит
                OpacityValue = (byte)((value > 100) ? 100 : value);
                //Пересоздаём слой
                getLayer = compileLayer();
            }
        }

        /// <summary>
        /// Фозвращаем картинку слоя
        /// </summary>
        public zBitmapPixel[] getLayer { get; set; }

        /// <summary>
        /// Инициализируем новый слой
        /// </summary>
        /// <param name="Image">Rfhnbyrf</param>
        /// <param name="OpacityValue">Значение прозрачности. От 0 до 100</param>
        /// <param name="Visible">Видимость слоя</param>
        /// <param name="ZIndex">Индекс расположения слоя</param>
        public zBitmapLayer(BitmapImage Image, int ZIndex, bool Visible = true, byte OpacityValue = 100)
        {
            this.Image = getPixelsFromImage(Image);
            this.Visible = Visible;
            Opasity = OpacityValue;
            this.ZIndex = ZIndex;
        }

        /// <summary>
        /// Формирование слоя, со всеми указанными параметрами
        /// </summary>
        /// <returns>Список пикселей слоя</returns>
        private zBitmapPixel[] compileLayer()
        {
            zBitmapPixel[] ex;
            //Если слой виден
            if (Visible)
            {
                //Инициализируем новый массив пикселов
                ex = new zBitmapPixel[Image.Length];
                //Проходимся по всем пикселям изначального изображения
                for (int i = 0; i < Image.Length; i++)
                    //И, проставляем им нужную прозрачность
                    ex[i] = Image[i].getPixelWithOpacity(OpacityValue);
            }
            //В случае, если слой не виден, вернём пустой массив
            else
                ex = new zBitmapPixel[0];             

            return ex;
        }

        /// <summary>
        /// Получаем список пикселов, из картинки
        /// </summary>
        /// <param name="Image">Картинка</param>
        /// <returns>Список пикселов</returns>
        private zBitmapPixel[] getPixelsFromImage(BitmapImage Image)
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
                pxCt = Image.PixelWidth * Image.PixelWidth;
                //Считаем общее количество каналов (цветов на пиксель)
                channelsCt = pxCt * bytesInPixel;
                //Множим ширину, на количество байт в цвете, получая шаг
                stride = Image.PixelWidth * Image.Format.BitsPerPixel / 8;
                //Инициализируем массив, для получения пикселов
                pixArr = new byte[channelsCt];
                //Сливаем все пиксели картинки
                Image.CopyPixels(pixArr, stride, 0);

                //Проходимся по всем каналам
                for (int i = 0; i < channelsCt; i += bytesInPixel)
                    //Добавляя пиксели в список, помня, что формат у нас - BGRA
                    ex.Add(new zBitmapPixel()
                    {
                        Blue = pixArr[i],
                        Green = pixArr[i + 1],
                        Red = pixArr[i + 2],
                        Alpha = pixArr[i + 3]
                    });
            }

            return ex.ToArray();
        }

        /// <summary>
        /// Обновляем картинку слоя
        /// </summary>
        /// <param name="Image">Новая картинка</param>
        public void updateImage(BitmapImage Image)
        {
            this.Image = getPixelsFromImage(Image);
            //Пересоздаём слой
            getLayer = compileLayer();
        }
    }
}
