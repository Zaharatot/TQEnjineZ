using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TQEnjineZ.Clases.Wrappers.Scene
{
    /// <summary>
    /// Список действий объекта сцены
    /// </summary>
    class SceneObjectActions
    {
        /// <summary>
        /// Список типов действий
        /// </summary>
        public enum ActionType
        {
            Без_триггера,
            Догрузка_элемента,
            Наведение_курсора,
            Убирание_курсора,
            Перемещение_курсора,
            Клик
        }

        /// <summary>
        /// Тип действия
        /// </summary>
        public ActionType type { get; set; }
        /// <summary>
        /// Название задействуемого триггера
        /// </summary>
        public string triggerName { get; set; }
        /// <summary>
        /// Id рабочего элемента
        /// </summary>
        public string elementId { get; set; }

        /// <summary>
        /// Возвращает код, который нужно вставить в объект цсены
        /// </summary>
        public string getCode
        {
            get
            {
                string ex = "";

                //Получаем функцию триггера
                string action = getFunctionByTriggerName();

                //Выбираем действие по типу
                switch (type)
                {
                    case ActionType.Без_триггера:
                        {
                            ex = "";
                            break;
                        }
                    case ActionType.Догрузка_элемента:
                        {
                            ex = "";
                            break;
                        }
                    case ActionType.Клик:
                        {
                            ex = "";
                            break;
                        }
                    case ActionType.Наведение_курсора:
                        {
                            ex = "";
                            break;
                        }
                    case ActionType.Перемещение_курсора:
                        {
                            ex = "";
                            break;
                        }
                    case ActionType.Убирание_курсора:
                        {
                            ex = "";
                            break;
                        }
                }

                return ex;
            }
        }

        /// <summary>
        /// Возвращает имя основной функции триггера
        /// по его названию
        /// </summary>
        /// <returns>Основная функция триггера</returns>
        private string getFunctionByTriggerName()
        {
            string ex = "";

            /* Вот тут будет код получения функции триггера по его имени */

            return ex;
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public SceneObjectActions()
        {
            //Указываем дефолтные параметры
            type = ActionType.Без_триггера;
            triggerName = "";
        }

    }
}
