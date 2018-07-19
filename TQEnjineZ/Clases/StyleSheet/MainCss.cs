using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TQEnjineZ.Clases.StyleSheet
{
    /// <summary>
    /// Класс основного CSS-файла. Содержит в себе списки всех 
    /// стилей приложения, и может генерировать итоговый css-файл
    /// </summary>
    class MainCss
    {
        /// <summary>
        /// Список стилей рамок
        /// </summary>
        private List<StyleBorder> borders;

        /// <summary>
        /// Список стилей шрифтов
        /// </summary>
        private List<StyleFont> fonts;


        /// <summary>
        /// Список стилей заднего плана
        /// </summary>
        private List<StyleBackground> backgrounds;

        /// <summary>
        /// Возвращает файл стилей
        /// </summary>
        public string getCss
        {
            get
            {
                string ex = "";

                //Проходимся по всем рамкам
                foreach (var br in borders)
                    //Добавляем стиль каждой в список
                    ex += createClass(br.className, br.getCss);


                //Проходимся по всем шрифтам
                foreach (var f in fonts)
                    //Добавляем стиль каждого в список
                    ex += createClass(f.className, f.getCss);

                //Проходимся по всем задним планам
                foreach (var bg in backgrounds)
                    //Добавляем стиль каждого в список
                    ex += createClass(bg.className, bg.getCss);

                return ex;
            }
        }

        /// <summary>
        /// Инициализация основного CSS-файла
        /// </summary>
        public MainCss()
        {
            //Инициализируем все списки стилей
            borders = new List<StyleBorder>();
            fonts = new List<StyleFont>();
            backgrounds = new List<StyleBackground>();
        }

        /// <summary>
        /// Формируем текст css-класса
        /// </summary>
        /// <param name="className">Имя класса</param>
        /// <param name="content">Содержимое класса</param>
        /// <returns>Текст CSs- класса</returns>
        private string createClass(string className, string content) =>
            string.Format(".{0} {1}\r\n{3}\r\n{2}\r\n",
                            className,
                            "{",
                            "}",
                            content
                        );


    }
}
