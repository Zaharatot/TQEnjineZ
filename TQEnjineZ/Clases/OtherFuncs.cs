using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Web.Script.Serialization;

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
            $"rgba({ c.R }, { c.G }, { c.B }, { getAlpha(c.A) })";

        /// <summary>
        /// Получаем пригодное для браузера значение альфа-канала
        /// </summary>
        /// <param name="alpha">Байтовое значение альфа-канала</param>
        /// <returns>Строка с числом</returns>
        public static string getAlpha(int alpha, int max = 255)
        {
            string ex = "1";

            decimal op = 1;

            try
            {
                //Правим граничные значения прозрачности
                if (alpha < 0)
                    alpha = 0;
                else if (alpha > max)
                    alpha = max;

                //Получаем значение прозрачности в процентах
                op = (decimal)(alpha / max);
                //Парсим число в строку
                ex = op.ToString("F5");
            }
            catch { ex = "1"; }

            return ex;
        }

        /// <summary>
        /// Заменяем нижнее подчёркивание в имени ENUM-a, на указанный символ
        /// </summary>
        /// <param name="value">Имя Enum-a</param>
        /// <param name="replaceChar">Символ, которым заменяем</param>
        /// <returns>Исправленное имя</returns>
        public static string replaceName(string value, string replaceChar) =>
            value.Replace("_", replaceChar);



        /// <summary>
        /// Формируем JSON строку из объекта
        /// </summary>
        /// <param name="data">Объект, который будем писать в JSON</param>
        /// <returns>JSON</returns>
        public static string objectToJSON(object data)
        {
            string ex = "";

            try
            {
                //Сериализуем объект в строку JSON
                ex = new JavaScriptSerializer().Serialize(data);
            }
            catch { ex = ""; }

            return ex;
        }
    }
}
