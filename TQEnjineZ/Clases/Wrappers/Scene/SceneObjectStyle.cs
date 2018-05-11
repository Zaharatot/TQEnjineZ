using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;


namespace TQEnjineZ.Clases.Wrappers.Scene
{
    /// <summary>
    /// Стиль объекта сцены
    /// </summary>
    class SceneObjectStyle
    {
        /// <summary>
        /// Делегат события изменения стиля объекта сцены
        /// </summary>
        public delegate void EditStyleEvent();
        /// <summary>
        /// Ивент изменения стиля объекта сцены
        /// </summary>
        public event EditStyleEvent EditStyle;

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
        /// Имя шрифта
        /// </summary>
        private FontFamily fFamily;
        /// <summary>
        /// Размер шрифта
        /// </summary>
        private double fSize;
        /// <summary>
        /// Жирность шрифта
        /// </summary>
        private FontWeight fWeight;
        /// <summary>
        /// Подчёркивание шрифта
        /// </summary>
        private TextDecorationCollection tDecoration;



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
                EditStyle?.Invoke();
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
                EditStyle?.Invoke();
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
                EditStyle?.Invoke();
            }
        }

        /// <summary>
        /// Публичный параметр имени шрифта
        /// </summary>
        public FontFamily fontFamily
        {
            get
            {
                return fFamily;
            }
            set
            {
                //Присваиваем значение
                fFamily = value;
                //Вызываем ивент, сообщающий об изменении
                EditStyle?.Invoke();
            }
        }
        /// <summary>
        /// Публичный параметр размера шрифта
        /// </summary>
        public double fontSize
        {
            get
            {
                return fSize;
            }
            set
            {
                //Присваиваем значение
                fSize = value;
                //Вызываем ивент, сообщающий об изменении
                EditStyle?.Invoke();
            }
        }
        /// <summary>
        /// Публичный параметр жирности шрифта
        /// Все дефолтные варианты лежат в FontWeights
        /// </summary>
        public FontWeight fontWeight
        {
            get
            {
                return fWeight;
            }
            set
            {
                //Присваиваем значение
                fWeight = value;
                //Вызываем ивент, сообщающий об изменении
                EditStyle?.Invoke();
            }
        }
        /// <summary>
        /// Публичный параметр подчёркивания шрифта
        /// Все дефолтные варианты лежат в TextDecorations
        /// </summary>
        public TextDecorationCollection textDecoration
        {
            get
            {
                return tDecoration;
            }
            set
            {
                //Присваиваем значение
                tDecoration = value;
                //Вызываем ивент, сообщающий об изменении
                EditStyle?.Invoke();
            }
        }


        /// <summary>
        /// Инициализация объекта сцены дефолтными значениями
        /// </summary>
        public SceneObjectStyle()
        {
            //Прописываем дефолтные цвета
            bgColor = new Color() { A = 255, R = 251, G = 251, B = 251 };
            fgColor = new Color() { A = 255, R = 15, G = 15, B = 15 };
            bColor = new Color() { A = 255, R = 20, G = 20, B = 20 };

            //Прописываем дефолтные параметры шрифта
            fFamily = new FontFamily("Arial");
            fSize = 15;
            fWeight = FontWeights.Normal;
            tDecoration = null;
        }
    }
}
