using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TQEnjineZ.Clases.Wrappers.Scene
{
    /// <summary>
    /// Базовый объект сцены, размещается внутри сцены
    /// </summary>
    class SceneObjectBase
    {
        /// <summary>
        /// Типы объектов сцены
        /// </summary>
        public enum SceneObjectType
        {
            Текст,
            Изображение
        }

        /// <summary>
        /// Тип отображения объекта сцены
        /// </summary>
        public enum SceneObjectDisplay
        {
            Не_отображается,
            Указанный_размер,
            По_размеру_содержимого,
            По_размеру_Контейнера
        }

        /// <summary>
        /// Делегат события клика по объекту сцены
        /// </summary>
        public delegate void SceneObjectClick();
        /// <summary>
        /// Событие клика по сцене
        /// </summary>
        public event SceneObjectClick SceneObjectClickEvent;

        /// <summary>
        /// Ширина объекта сцены
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// Высота объекта сцены
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// Координата левого верхнего угла обекта сцены, по оси X
        /// </summary>
        public int Left { get; set; }
        /// <summary>
        /// Координата левого верхнего угла обекта сцены, по оси Y
        /// </summary>
        public int Top { get; set; }


        /// <summary>
        /// Стиль объекта сцены
        /// </summary>
        public SceneObjectStyle Style { get; set; }        
        /// <summary>
        /// Анимация объекта сцены
        /// </summary>
        public SceneObjectAnimation Animation { get; set; }



    }
}
