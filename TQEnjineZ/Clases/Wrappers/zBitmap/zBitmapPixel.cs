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
            byte newAlpha = (byte)((double)Alpha * (double)Opacity / 100.00);
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
        /// <param name="с1">Значения канала заднего плана</param>
        /// <param name="с2">Значение канала фона</param>
        /// <param name="av3">Новый альфа-канал</param>
        /// <param name="av2">Значение альфа-канала переднего плана</param>
        /// <param name="av1">Значение альфа-канала фона</param>
        /// <returns>Новаое значение цвета</returns>
        private double mixChannel(double с1, double av1, double с2, double av2, double av3)
        {
            //Приводим 
            double ex;

            //Для случая, если пиксель переднего плана прозрачный, просто игнорим его
            if (av2 == 0)
                ex = с1;
            //Если он полностью непрозрачный - игнорим задний фон
            //Либо, аналогично, если пиксель заднего фона полностью прозрачный
            else if ((av2 == 1) || (av1 == 0))
                ex = с2;
            else
            {
                //Высчитываем значение заднего фона, без альфа-канала
                double c01 = с1 * av1;
                //Высчитываем значение переднего плана, без альфа-канала
                double c02 =  (1 - av2) * c01 + с2 * av2;
                //Получаем максимальное значение, и приводим к виду, с учётом наличия нового альфа-канала
                double max = Math.Max(c01, c02) / av3;
                //Проверяем на выход из диапазона (на всякий случай), и множим на 255
                ex = Math.Min(255, max);                
            }

            return ex;
        }

        /// <summary>
        /// Миксуем альфа-каналы
        /// </summary>
        /// <param name="av2">Значение альфа-канала переднего плана</param>
        /// <param name="av1">Значение альфа-канала фона</param>
        /// <returns>Новаое значение цвета</returns>
        private double mixAlphaChannel(double av1, double av2)
        {
            //ВОзвращаем значение новой прозрачности
            return av2 + av1 - av1 * av2;
        }

        /// <summary>
        /// Смешиваем цвета, с учётом слоёв
        /// </summary>
        /// <param name="foreground">Цвет фона</param>
        /// <returns>Цвет нового пикселя</returns>
        public zBitmapPixel mixPixelColors(zBitmapPixel foreground)
        {
            //Считаем процентные значения альфа-каналов
            double av1 = Alpha / 255.0;
            double av2 = foreground.Alpha / 255.0;
            //Считаем значение суммарного альфа-канала
            double av3 = mixAlphaChannel(av1, av2);
            
            //Возвращаем миксовый цвет
            return new zBitmapPixel()
            {
                Red = (byte)mixChannel(Red, av1, foreground.Red, av2, av3),
                Blue = (byte)mixChannel(Blue, av1, foreground.Blue, av2, av3),
                Green = (byte)mixChannel(Green, av1, foreground.Green, av2, av3),
                Alpha = (byte)(av3 * 255)
            };
        }

    }
}
