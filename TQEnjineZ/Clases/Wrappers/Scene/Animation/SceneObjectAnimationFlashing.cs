using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TQEnjineZ.Clases.Wrappers.Scene.Animation
{
    /// <summary>
    /// Информация, о параметрах анимации
    /// Тип анимации - мигание
    /// </summary>
    class SceneObjectAnimationFlashing
    {
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
