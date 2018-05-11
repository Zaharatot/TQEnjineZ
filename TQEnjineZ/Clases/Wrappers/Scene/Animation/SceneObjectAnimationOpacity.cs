using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TQEnjineZ.Clases.Wrappers.Scene.Animation
{
    /// <summary>
    /// Информация, о параметрах анимации
    /// Тип анимации - изменение прозрачности
    /// </summary>
    class SceneObjectAnimationOpacity
    {
        /// <summary>
        /// Стартовое значение прозрачности
        /// От 0 до 1000
        /// </summary>
        private int startOpacityP;
        /// <summary>
        /// Конечное значение прозрачности
        /// От 0 до 1000
        /// </summary>
        private int finOpacityP;
        /// <summary>
        /// Продолжительность анимации, в милисекундах
        /// От 0 до MAX(int)
        /// </summary>
        private int durationP;
        /// <summary>
        /// Интервал, между итерациями анимации
        /// От 0 до MAX(int)
        /// </summary>
        private int delayP;

        /// <summary>
        /// Публичный параметр стартового значения прозрачности
        /// От 0 до 1000
        /// </summary>
        public int startOpacity
        {
            get
            {
                return startOpacityP;
            }
            set
            {
                //Значение не может быть больше 1000
                startOpacityP = (value <= 1000) ? value : 1000;                
            }
        }

        /// <summary>
        /// Публичный параметр конечного значения прозрачности
        /// От 0 до 1000
        /// </summary>
        public int finOpacity
        {
            get
            {
                return finOpacityP;
            }
            set
            {
                //Значение не может быть больше 1000
                finOpacityP = (value <= 1000) ? value : 1000;
            }
        }

        /// <summary>
        /// Продолжительность анимации, в милисекундах
        /// От 0 до MAX(int)
        /// </summary>
        public int duration
        {
            get
            {
                return durationP;
            }
            set
            {
                //Значение не может быть меньше 0
                durationP = (value >= 0) ? value : 0;
            }
        }

        /// <summary>
        /// Продолжительность анимации, в милисекундах
        /// От 0 до MAX(int)
        /// </summary>
        public int delay
        {
            get
            {
                return delayP;
            }
            set
            {
                //Значение не может быть меньше 0
                delayP = (value >= 0) ? value : 0;
            }
        }
    }
}
