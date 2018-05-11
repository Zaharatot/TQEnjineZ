using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TQEnjineZ.Clases.Wrappers.Scene.Animation
{
    /// <summary>
    /// Информация, о параметрах анимации
    /// Тип анимации - сдвиг
    /// </summary>
    class SceneObjectAnimationMove
    {
        /// <summary>
        /// Тип анимации объекта
        /// </summary>
        public enum SceneObjectAnimationType
        {
            Изменение_прозрачности,
            Перемещение,
            Мигание,
            Мерцание
        }

        /// <summary>
        /// Тип анимации
        /// </summary>
        public SceneObjectAnimationType animationType { get; set; }
        /// <summary>
        /// На сколько меняем значение, за каждый тик
        /// </summary>
        public decimal changeValue { get; set; }
        /// <summary>
        /// Задержка, между обновлениями анимации
        /// </summary>
        public decimal animationDelay { get; set; }
        /// <summary>
        /// Время выполнения анимации 0 - бесконечная
        /// </summary>
        public decimal anumationTime { get; set; }
    }
}
