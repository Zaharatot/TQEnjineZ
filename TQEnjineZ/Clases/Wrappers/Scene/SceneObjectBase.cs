using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TQEnjineZ.Clases.Wrappers.Scene.Style;
using TQEnjineZ.Clases.Wrappers.Scene.Animation;

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
        /// Список дочерних объектов сцены
        /// </summary>
        public List<SceneObjectBase> childs { get; set; }

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
        /// Слой объекта сцены
        /// </summary>
        public int Layer { get; set; }

        /// <summary>
        /// Возвращает Html-код данной сцены
        /// </summary>
        public string getHtml
        {
            get
            {
                return CompileHtml();
            }
        }

        /// <summary>
        /// Стиль объекта сцены
        /// </summary>
        public SceneObjectStyle Style { get; set; }
        /// <summary>
        /// Анимация объекта сцены
        /// </summary>
        public SceneObjectAnimation Animation { get; set; }

        /// <summary>
        /// Инициалилируем базовый объект сцены дефолтными значениями
        /// </summary>
        public SceneObjectBase()
        {
            Style = new SceneObjectStyle();
        }

        /// <summary>
        /// Формируем html-код сцены
        /// </summary>
        /// <returns>Строка с html-кодом</returns>
        private string CompileHtml()
        {
            string ex = "";


            return ex;
        }
    }
}
