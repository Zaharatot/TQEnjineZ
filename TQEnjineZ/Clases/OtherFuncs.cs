using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TQEnjineZ.Clases
{
    /// <summary>
    /// Различные функции использоуемые много где
    /// </summary>
    class OtherFuncs
    {
        /// <summary>
        /// Кнофертируем цвет в строку понятную CSS-у
        /// </summary>
        /// <param name="c">Исходный цвет</param>
        /// <returns>Цвет подогнанный для CSS</returns>
        public static string getCssCloor(Color c) =>
            string.Format("rgb({0}, {1}, {2})", c.R, c.G, c.B);

        /// <summary>
        /// Заменяем нижнее подчёркивание в имени ENUM-a, на указанный символ
        /// </summary>
        /// <param name="value">Имя Enum-a</param>
        /// <param name="replaceChar">Символ, которым заменяем</param>
        /// <returns>Исправленное имя</returns>
        public static string replaceName(string value, string replaceChar) =>
            value.Replace("_", replaceChar);
    }
}
