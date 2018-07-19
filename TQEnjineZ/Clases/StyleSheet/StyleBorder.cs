using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;


namespace TQEnjineZ.Clases.StyleSheet
{
    /// <summary>
    /// Рамка, вокруг элемента
    /// </summary>
    class StyleBorder
    {
        /// <summary>
        /// Стиль рамки
        /// </summary>
        public enum borderType
        {
            none = 0,       //Без рамки
            full = 1,       //Рамка для всего элемента
            top = 2,        //Рамка сверху
            bottom = 3,     //Рамка снизу
            left = 4,       //Рамка слева
            right = 5,      //Рамка справа
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
        /// Список рамок объекта
        /// </summary>
        public List<StyleBorderPart> borders { get; set; }
        
        /// <summary>
        /// Возвращает общий стиль рамок
        /// </summary>
        public string getCss
        {
            get
            {
                string ex = "";

                //Если у нас есть вообще хоть одна рамка
                if (borders.Count > 0)
                {
                    //Ищщем в списке бордеров тот, у которого есть стиль - общий бордер
                    var full = borders.Where(br => (br.type == borderType.full)).FirstOrDefault();
                    //Если такой есть
                    if (full != null)
                        //Протсо берём его стиль
                        ex = full.getCss;
                    //Если такого нету
                    else
                        //Проходимся по всем бордерам в списке
                        //И добавляем их стили к нашему
                        foreach (var br in borders)
                            ex += br.getCss + "\r\n";
                }

                return ex;
            }
        }

        /// <summary>
        /// Инициализация рамки
        /// </summary>
        public StyleBorder()
        {
            //Инициализируем дефолтные значения
            styleName = "newBorderStyle";

            /* вот тут будет получение уникального названия класса */

            //Инициализируем пустой список рамок
            borders = new List<StyleBorderPart>();
        }
    }
}
