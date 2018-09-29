using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;


namespace TQEnjineZ.Clases.Wrappers.Scene
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
        /// Стиль позиции, применяемый в этом блоке
        /// </summary>
        public string positionStyle { get; set; }

        /// <summary>
        /// Возвращаем список классов данного блока
        /// </summary>
        public string getClass
        {
            get
            {
                return $"{fontStyle} {borderStyle} {backgroundStyle} {positionStyle}";
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
            //Позиция - без позиции
            positionStyle = "";
        }      
    }
}
