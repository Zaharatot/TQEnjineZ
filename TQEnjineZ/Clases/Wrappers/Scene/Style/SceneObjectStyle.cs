using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;


namespace TQEnjineZ.Clases.Wrappers.Scene.Style
{
    /// <summary>
    /// Стиль объекта сцены
    /// </summary>
    class SceneObjectStyle
    {
        /// <summary>
        /// Стиль шрифта, применяемый в этом блоке
        /// </summary>
        public string fontStyle { get; set; }
        /// <summary>
        /// Стиль рамки, применяемый в этом блоке
        /// </summary>
        public string borderStyle { get; set; }
        /// <summary>
        /// Стиль заднего плана, применяемый в этом блоке
        /// </summary>
        public string backgroundStyle { get; set; }

        /// <summary>
        /// Возвращаем список классов данного блока
        /// </summary>
        public string getClass
        {
            get
            {
                return string.Format("{0} {1} {2}", fontStyle, borderStyle, backgroundStyle);
            }
        }


        /// <summary>
        /// Инициализация объекта сцены дефолтными значениями
        /// </summary>
        public SceneObjectStyle()
        {
            //Определяем дефолтные стили
            //Задний план - дефолтный
            backgroundStyle = "";
            //Шрифт - дефолтный
            fontStyle = "";
            //Рамка - без рамки
            borderStyle = "";
        }      
    }
}
