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
        private Color backgroundColorP;
        /// <summary>
        /// Цвет контента
        /// </summary>
        private Color foregroundColorP;
        /// <summary>
        /// Цвет рамки
        /// </summary>
        private Color borderColorP;


        /// <summary>
        /// Публичный параметр цвета заднего фона
        /// </summary>
        public Color backgroundColor
        {
            get
            {
                return backgroundColorP;
            }
            set
            {
                //Присваиваем значение
                backgroundColorP = value;
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
                return foregroundColorP;
            }
            set
            {
                //Присваиваем значение
                foregroundColorP = value;
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
                return borderColorP;
            }
            set
            {
                //Присваиваем значение
                borderColorP = value;
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
            backgroundColorP = new Color() { A = 255, R = 251, G = 251, B = 251 };
            foregroundColorP = new Color() { A = 255, R = 15, G = 15, B = 15 };
            borderColorP = new Color() { A = 255, R = 20, G = 20, B = 20 };
        }
    }
}
