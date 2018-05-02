using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TQEnjineZ.Clases.Wrappers.zBitmap
{
    /// <summary>
    /// Один пиксель изображения
    /// </summary>
    class zBitmapPixel
    {
        /// <summary>
        /// Красный канал
        /// </summary>
        public byte Red { get; set; }
        /// <summary>
        /// Зелёный канал
        /// </summary>
        public byte Green { get; set; }
        /// <summary>
        /// Синий канал
        /// </summary>
        public byte Blue { get; set; }
        /// <summary>
        /// Альфа канал
        /// </summary>
        public byte Alpha { get; set; }

        /// <summary>
        /// Возвращает значение пиксела, с новой прозрачностью
        /// </summary>
        /// <param name="Opacity">Значение прозрачности</param>
        /// <returns>Новый пиксель</returns>
        public zBitmapPixel getPixelWithOpacity(byte Opacity)
        {
            //Получаем новое значение прозрачности, приняв дефолтное за 100%
            byte newAlpha = (byte)(Alpha * Opacity / 100);
            //Инициализируем новый пиксель, с новым значением прозрачности
            return new zBitmapPixel() {
                Red = Red,
                Green = Green,
                Blue = Blue,
                Alpha = newAlpha
            };
        }


        /// <summary>
        /// Миксуем 2 цвета
        /// </summary>
        /// <param name="backgroundChannel">Значения канала заднего плана</param>
        /// <param name="foregroundChannel">Значение канала фона</param>
        /// <param name="foregroundAlphaChannel">Значение альфа-канала фона</param>
        /// <returns>Новаое значение цвета</returns>
        private double mixChannel(double backgroundChannel, double foregroundChannel, double foregroundAlphaChannel)
        {
            //Приводим 
            double alpha = foregroundAlphaChannel / 100.00;
            return foregroundChannel + backgroundChannel * (1.0 - alpha);
        }

        /// <summary>
        /// Смешиваем цвета, с учётом слоёв
        /// </summary>
        /// <param name="foreground">Цвет фона</param>
        /// <returns>Цвет нового пикселя</returns>
        public zBitmapPixel mixPixelColors(zBitmapPixel foreground)
        {
            //Возвращаем миксовый цвет
            return new zBitmapPixel()
            {
                Red = (byte)mixChannel(Red, foreground.Red, foreground.Alpha),
                Blue = (byte)mixChannel(Blue, foreground.Blue, foreground.Alpha),
                Green = (byte)mixChannel(Green, foreground.Green, foreground.Alpha),
                Alpha = (byte)mixChannel(Alpha, foreground.Alpha, foreground.Alpha)
            };
        }


    }
}
