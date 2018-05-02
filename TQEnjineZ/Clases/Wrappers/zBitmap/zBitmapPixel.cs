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
    }
}
