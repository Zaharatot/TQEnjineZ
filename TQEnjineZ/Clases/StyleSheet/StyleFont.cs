using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace TQEnjineZ.Clases.StyleSheet
{
    /// <summary>
    /// Информация о шрифте стиля
    /// </summary>
    class StyleFont
    {
        /// <summary>
        /// Жирность шрифта
        /// </summary>
        public enum fontWeight
        {
            normal = 0, //Обычный текст
            bold = 1    //Жирный текст
        }

        /// <summary>
        /// Подчёркивание шрифта
        /// </summary>
        public enum textDecoration
        {
            none = 0,           //Без подчёркивания
            underline = 1,      //Нижнее подчёркивание
            overline = 2,       //Верхнее подчёркивание
            line_through = 3     //Зачёркнутый текст
        }

        /// <summary>
        /// Подчёркивание шрифта
        /// </summary>
        public enum textDecorationStyle
        {
            initial = 0,    //Если есть textDecoration, то простая линия, иначе - ничего
            dashed = 1,     //Штриховой пунктир
            dotted = 2,     //Точечный пунктир
            double_ = 3,    //Двойное подчёркивание
            solid = 4,      //Одинарное подчёркивание
            wavy = 5        //Волнистая линия
        }

        /// <summary>
        /// Название стиля в программе
        /// </summary>
        public string styleName { get; set; }
        /// <summary>
        /// Название класса. Генерироваться будет автоматически
        /// при формировании CSS-файла
        /// </summary>
        public string className { get; private set; }

        /// <summary>
        /// Имя стиля шрифта
        /// </summary>
        public string family { get; set; }
        /// <summary>
        /// Размер шрифта
        /// </summary>
        public decimal size { get; set; }
        /// <summary>
        /// Жирность шрифта
        /// </summary>
        public fontWeight weight { get; set; }
        /// <summary>
        /// Подчёркивание шрифта
        /// </summary>
        public textDecoration decoration { get; set; }
        /// <summary>
        /// Стиль подчёркивания шрифта
        /// </summary>
        public textDecorationStyle decorationStyle { get; set; }
        /// <summary>
        /// Цвет подчёркивания текста
        /// </summary>
        public Color decorationColor { get; set; }
        /// <summary>
        /// Цвет текста
        /// </summary>
        public Color color { get; set; }

        /// <summary>
        /// Возвращает CSS-стиль шрифта
        /// </summary>
        public string getCss
        {
            get
            {
                //Возвращаем кусок файла стилей, с параметрами данного шрифта
                return string.Format(@"                    
                        font-family: {0};
                        font-size: {1}px;
                        font-weight: {2};
                        text-decoration: {3};
                        text-decoration-style: {4};
                        text-decoration-color: {5};
                        color: {6};
                    ", 
                    family, 
                    size, 
                    weight.ToString(),
                    OtherFuncs.replaceName(decoration.ToString(), "-"),
                    OtherFuncs.replaceName(decorationStyle.ToString(), ""),
                    OtherFuncs.getCssCloor(decorationColor),
                    OtherFuncs.getCssCloor(color)
                );
            }
        }


        /// <summary>
        /// Инициализация шрифта стиля дефолтными значениями
        /// </summary>
        public StyleFont()
        {
            //Прописываем дефолтные параметры шрифта
            family = "Arial";
            size = 15;
            weight = fontWeight.normal;
            decoration = textDecoration.none;
            decorationStyle = textDecorationStyle.initial;
            decorationColor = Color.FromRgb(0, 0, 0);
            //Текст - чёрный
            color = Color.FromRgb(0, 0, 0);
            //Инициализируем дефолтные значения
            styleName = "newFontStyle";

            /* вот тут будет получение уникального названия класса */
        }
    }
}
