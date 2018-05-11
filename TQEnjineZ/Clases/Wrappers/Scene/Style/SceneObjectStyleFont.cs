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
                return fSize;
            }
            set
            {
                //Присваиваем значение
                fSize = value;
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
                return fWeight;
            }
            set
            {
                //Присваиваем значение
                fWeight = value;
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
                return tDecoration;
            }
            set
            {
                //Присваиваем значение
                tDecoration = value;
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
            fFamily = new FontFamily("Arial");
            fSize = 15;
            fWeight = FontWeights.Normal;
            tDecoration = null;
        }

    }
}
