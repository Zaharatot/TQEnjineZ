using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TQEnjineZ.Clases.Wrappers.Scene.Style
{
    /// <summary>
    /// Информация о цвете стиля
    /// </summary>
    public class SceneObjectStyleColor
    {
        /// <summary>
        /// Делегат события изменения стиля объекта сцены
        /// </summary>
        public delegate void EditStyleEvent();
        /// <summary>
        /// Ивент изменения цвета объекта сцены
        /// </summary>
        public event EditStyleEvent EditColor;

        /// <summary>
        /// Цвет заднего фона
        /// </summary>
        private Color bgColor;
        /// <summary>
        /// Цвет контента
        /// </summary>
        private Color fgColor;
        /// <summary>
        /// Цвет рамки
        /// </summary>
        private Color bColor;


        /// <summary>
        /// Публичный параметр цвета заднего фона
        /// </summary>
        public Color backgroundColor
        {
            get
            {
                return bgColor;
            }
            set
            {
                //Присваиваем значение
                bgColor = value;
                //Вызываем ивент, сообщающий об изменении
                EditColor?.Invoke();
            }
        }
        /// <summary>
        /// Публичный параметр цвета контента
        /// </summary>
        public Color foregroundColor
        {
            get
            {
                return fgColor;
            }
            set
            {
                //Присваиваем значение
                fgColor = value;
                //Вызываем ивент, сообщающий об изменении
                EditColor?.Invoke();
            }
        }
        /// <summary>
        /// Публичный параметр цвета рамки
        /// </summary>
        public Color borderColor
        {
            get
            {
                return bColor;
            }
            set
            {
                //Присваиваем значение
                bColor = value;
                //Вызываем ивент, сообщающий об изменении
                EditColor?.Invoke();
            }
        }

        /// <summary>
        /// Инициализация цвета стиля дефолтными значениями
        /// </summary>
        public SceneObjectStyleColor()
        {
            //Прописываем дефолтные цвета
            bgColor = new Color() { A = 255, R = 251, G = 251, B = 251 };
            fgColor = new Color() { A = 255, R = 15, G = 15, B = 15 };
            bColor = new Color() { A = 255, R = 20, G = 20, B = 20 };
        }
    }
}
