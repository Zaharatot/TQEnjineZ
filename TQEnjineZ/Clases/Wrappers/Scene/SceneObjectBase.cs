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
        /// Список дочерних объектов сцены
        /// </summary>
        public List<SceneObjectBase> childs { get; set; }
        /// <summary>
        /// Стиль объекта сцены
        /// </summary>
        public SceneObjectStyle Style { get; set; }
        /// <summary>
        /// Список триггеров объекта сцены
        /// </summary>
        public SceneObjectTriggers Triggers { get; set; }
        /// <summary>
        /// Id элемента
        /// </summary>
        public string elementId { get; private set; }

        /// <summary>
        /// Название объекта сцены
        /// </summary>
        public string objectName { get; set; }


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
        /// Инициалилируем базовый объект сцены дефолтными значениями
        /// </summary>
        public SceneObjectBase()
        {
            //Инициализируем дефолтные значения
            Style = new SceneObjectStyle();
            Triggers = new SceneObjectTriggers();

            elementId = "NewSceneElement";
            /* Вот тут эудет код формирования уникального идентификатора элемента */
        }

        /// <summary>
        /// Формируем html-код сцены
        /// </summary>
        /// <returns>Строка с html-кодом</returns>
        private string CompileHtml()
        {
            string ex = "";

            //Получаем триггеры объекта
            string trigger = Triggers.getTriggers;
            //Получаем класс элемента
            string clas = Style.getClass;
            //Вот тут будет получение дочерних элементов
            string childs = "";

            //Формируем тело элемента
            ex = $"<div name=\"{objectName}\" id=\"{elementId}\" {clas} {trigger}>{childs}</div>";


            return ex;
        }
    }
}
