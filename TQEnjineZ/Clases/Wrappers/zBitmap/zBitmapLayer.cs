using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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
            }
        }

        /// <summary>
        /// Фозвращаем картинку слоя
        /// </summary>
        public zBitmapPixel[] getLayer
        {
            get
            {
                //Формируем слой, и возвращаем его
                return compileLayer();
            }
        }

        /// <summary>
        /// Инициализируем новый слой
        /// </summary>
        /// <param name="Image">Список пикселей картинки</param>
        /// <param name="OpacityValue">Значение прозрачности. От 0 до 100</param>
        /// <param name="Visible">Видимость слоя</param>
        public zBitmapLayer(zBitmapPixel[] Image, bool Visible = true, byte OpacityValue = 100)
        {
            this.Image = Image;
            this.Visible = Visible;
            Opasity = OpacityValue;
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
    }
}
