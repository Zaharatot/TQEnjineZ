using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace TQEnjineZ.Clases.Wrappers.Scene.Style
{
    /// <summary>
    /// Информация о шрифте стиля
    /// </summary>
    class SceneObjectStyleFont
    {
        /// <summary>
        /// Делегат события изменения стиля объекта сцены
        /// </summary>
        public delegate void EditStyleEvent();
        /// <summary>
        /// Ивент изменения шрифта объекта сцены
        /// </summary>
        public event EditStyleEvent EditFont;


        /// <summary>
        /// Имя шрифта
        /// </summary>
        private FontFamily fontFamilyP;
        /// <summary>
        /// Размер шрифта
        /// </summary>
        private double fontSizeP;
        /// <summary>
        /// Жирность шрифта
        /// </summary>
        private FontWeight fontWeightP;
        /// <summary>
        /// Подчёркивание шрифта
        /// </summary>
        private TextDecorationCollection textDecorationP;



        /// <summary>
        /// Публичный параметр имени шрифта
        /// </summary>
        public FontFamily fontFamily
        {
            get
            {
                return fontFamilyP;
            }
            set
            {
                //Присваиваем значение
                fontFamilyP = value;
                //Вызываем ивент, сообщающий об изменении
                EditFont?.Invoke();
            }
        }
        /// <summary>
        /// Публичный параметр размера шрифта
        /// </summary>
        public double fontSize
        {
            get
            {
                return fontSizeP;
            }
            set
            {
                //Присваиваем значение
                fontSizeP = value;
                //Вызываем ивент, сообщающий об изменении
                EditFont?.Invoke();
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
                return fontWeightP;
            }
            set
            {
                //Присваиваем значение
                fontWeightP = value;
                //Вызываем ивент, сообщающий об изменении
                EditFont?.Invoke();
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
                return textDecorationP;
            }
            set
            {
                //Присваиваем значение
                textDecorationP = value;
                //Вызываем ивент, сообщающий об изменении
                EditFont?.Invoke();
            }
        }

        /// <summary>
        /// Инициализация шрифта стиля дефолтными значениями
        /// </summary>
        public SceneObjectStyleFont()
        {
            //Прописываем дефолтные параметры шрифта
            fontFamilyP = new FontFamily("Arial");
            fontSizeP = 15;
            fontWeightP = FontWeights.Normal;
            textDecorationP = null;
        }

    }
}
