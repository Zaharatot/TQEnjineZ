using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TQEnjineZ.Clases.Wrappers.Scene.Style
{
    /// <summary>
    /// Стиль объекта сцены
    /// </summary>
    class SceneObjectStyle
    {
        /// <summary>
        /// Параметры цвета стиля
        /// </summary>
        public SceneObjectStyleColor Color { get; set; }
        
        /// <summary>
        /// Параметры шрифта стиля
        /// </summary>
        public SceneObjectStyleFont Font { get; set; }

        /// <summary>
        /// Инициализация объекта сцены дефолтными значениями
        /// </summary>
        public SceneObjectStyle()
        {
            //Инициализируем дефолтные значения
            Color = new SceneObjectStyleColor();
            Font = new SceneObjectStyleFont();
        }
    }
}
