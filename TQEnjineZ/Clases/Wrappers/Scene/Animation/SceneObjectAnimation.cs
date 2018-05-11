using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TQEnjineZ.Clases.Wrappers.Scene.Animation
{
    /// <summary>
    /// Анимация объекта сцены
    /// </summary>
    class SceneObjectAnimation
    {
        /// <summary>
        /// Анимация, с эффектом мерцания (медленно прозрачность опускается до 0, и наоборот)
        /// </summary>
        public SceneObjectAnimationBlink blink;
        /// <summary>
        /// Анимация, с эффектом мигания (объект исчезает и появляется)
        /// </summary>
        public SceneObjectAnimationFlashing flash;
        /// <summary>
        /// Анимация, с эффектом передвижения
        /// </summary>
        public SceneObjectAnimationMove move;
        /// <summary>
        /// Анимация с эффектом изменения прозрачности
        /// </summary>
        public SceneObjectAnimationOpacity opacity;
        /// <summary>
        /// Анимация с эффектом плавного изменения цвета
        /// </summary>
        public SceneObjectAnimationColor color;

        /// <summary>
        /// Инициализация дефолтных анимаций
        /// </summary>
        public SceneObjectAnimation()
        {
            blink = null;
            flash = null;
            move = null;
            opacity = null;
            color = null;
        }
    }
}
