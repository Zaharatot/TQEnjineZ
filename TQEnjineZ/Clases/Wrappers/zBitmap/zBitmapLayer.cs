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
        private byte[] Image { get; set; }
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
        public byte[] getLayer { get; set; }

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
        private byte[] compileLayer()
        {
            byte[] ex;
            //Если слой виден
            if (Visible)
            {
                //Возвращаем новый массив пикселов
                ex = getPixelsWithOpacity(OpacityValue);
            }
            //В случае, если слой не виден, вернём пустой массив
            else
                ex = new byte[0];             

            return ex;
        }

        /// <summary>
        /// Получаем список пикселов, из картинки
        /// </summary>
        /// <param name="Image">Картинка</param>
        /// <returns>Список пикселов</returns>
        private byte[] getPixelsFromImage(BitmapImage Image)
        {
            int bytesInPixel, pxCt, channelsCt, stride;
            //Выходной массив пикселов
            byte[] ex;

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
                ex = new byte[channelsCt];
                //Сливаем все пиксели картинки
                Image.CopyPixels(ex, stride, 0);                
            }
            //Во всех остальных случаях возвращаем пустой массив
            else
                ex = new byte[0];

            return ex;
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


        /// <summary>
        /// Возвращает массив пикселов, с новой прозрачностью
        /// </summary>
        /// <param name="Opacity">Значение прозрачности</param>
        /// <returns>Пиксели с новой прозрачностью</returns>
        public byte[] getPixelsWithOpacity(byte Opacity)
        {
            //СОздаём выходной массив таким же, как и эталонная картинка
            byte[] ex = new byte[Image.Length];
            //Копируем байты картинки в выходной массив
            Image.CopyTo(ex, 0);
            //ПРоходимся по каналам
            for (int i = 3; i < ex.Length; i += 4)
                //Меняем значение, для альфа-канала
                ex[i] = (byte)((ex[i] * Opacity) / 100);

            return ex;
        }


        /// <summary>
        /// Смешиваем цвета, с учётом 2 слоёв
        /// </summary>
        /// <param name="foreground">Пиксели переднего плана</param>
        /// <returns>Смешанный слой</returns>
        public byte[] mixPixelColors(byte[] backgeround)
        {
            /*
             Как показала практика, вызов рассчётов в отдельной функции сжирает 
             до 0,3 секунд, так что, всё будет в одной функции.
             А, вот, присваивание сначала в переменную, а потом в массив особой разницы 
             в скорости не даёт, так что останется так, т.к. мне так удобнее.             
             */

            byte av3, colR, colG, colB;
            int r, g, b, a;
            //Записываем пиксели фона
            byte[] foreground = getLayer;
            //Инициализируем новый массив, по размеру фона
            byte[] ex = new byte[backgeround.Length];
            //Проходимся по пикселям фона
            for (int i = 0; i < backgeround.Length; i+=4)
            {
                //BGRA
                b = i;
                g = i + 1;
                r = i + 2;
                a = i + 3;

                //Если у фона альфа канал непрозрачен, то считаем вот так:
                if (backgeround[a] == 255)
                {
                    //Итоговый альфа-канал - непрозрачный
                    av3 = 255;
                    //Считаем значения цветов
                    colG = (byte)(foreground[g] * foreground[a] + backgeround[g] * (255 - foreground[a]));
                    colB = (byte)(foreground[b] * foreground[a] + backgeround[b] * (255 - foreground[a]));
                    colR = (byte)(foreground[r] * foreground[a] + backgeround[r] * (255 - foreground[a]));
                }
                else
                {
                    //Считаем значение суммарного альфа-канала
                    av3 = (byte)(foreground[a] + backgeround[a] * (255 - foreground[a]));
                    //Если результирующий альфа-канал равен нулю, то все цвета ставим белым, т.к. всё равно получится прозрачный
                    if (av3 == 0)
                        colR = colG = colB = 255;
                    else
                    {
                        //Считаем значения цветов
                        colG = (byte)((foreground[g] * foreground[a] + backgeround[g] * backgeround[a] * (255 - foreground[a])) / av3);
                        colB = (byte)((foreground[b] * foreground[a] + backgeround[b] * backgeround[a] * (255 - foreground[a])) / av3);
                        colR = (byte)((foreground[r] * foreground[a] + backgeround[r] * backgeround[a] * (255 - foreground[a])) / av3);
                    }
                }

                //Возвращаем миксовый цвет
                ex[g] = colG;
                ex[b] = colB;
                ex[r] = colR;
                ex[a] = av3;
            }

            return ex;
        }
    }
}
