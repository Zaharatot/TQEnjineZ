using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TQEnjineZ.Clases.StyleSheet
{
    /// <summary>
    /// Стиль куска рамки
    /// </summary>
    class StyleBorderPart
    {
        /// <summary>
        /// Стиль рамки
        /// </summary>
        public enum borderStyle
        {
            unset = 0,      //Без рамки
            dashed = 1,     //Штриховой пунктир
            dotted = 2,     //Точечный пунктир
            double_ = 3,    //Двойная линия
            inset = 4,      //Объёмная рамка, вдавленная
            outset = 5,     //Объёмная рамка, выдавленная
            solid = 6       //Простая линия
        }

        /// <summary>
        /// Тип рамки
        /// </summary>
        public StyleBorder.borderType type { get; set; }
        /// <summary>
        /// Цвет рамки
        /// </summary>
        public Color color { get; set; }
        /// <summary>
        /// Стиль рамки
        /// </summary>
        public borderStyle style { get; set; }
        /// <summary>
        /// Толщина рамки
        /// </summary>
        public decimal size { get; set; }

        /// <summary>
        /// Возвращает стиль части рамки
        /// </summary>
        public string getCss
        {
            get
            {
                string ex = "";

                //Если тип пустой стиль бордера тоже будет пустым
                if (type != StyleBorder.borderType.none)
                {
                    //Бордер, для одного из краёв
                    ex = string.Format("border{3}: {0} {1}px {2};",
                        OtherFuncs.replaceName(style.ToString(), ""),
                        size,
                        OtherFuncs.getCssCloor(color),
                        ((type == StyleBorder.borderType.full) ? "" : ("-" + type.ToString()))
                    );
                }

                return ex;
            }
        }

        /// <summary>
        /// Инициализация куска рамки
        /// </summary>
        public StyleBorderPart()
        {
            //Пишем дефолтные значения
            //Цвет рамки - чёрный
            color = Color.FromRgb(0, 0, 0);
            //Стиль - без рамки
            style = borderStyle.unset;
            //Размер - 1px
            size = 1;
        }
    }
}
