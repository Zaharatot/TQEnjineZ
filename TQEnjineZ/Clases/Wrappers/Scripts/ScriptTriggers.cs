using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TQEnjineZ.Clases.Wrappers.Scripts
{
    /// <summary>
    /// Класс, реализующий триггер скрипта
    /// </summary>
    class ScriptTrigger
    {
        /// <summary>
        /// Тип триггера
        /// </summary>
        public enum triggerType
        {
            По_клику,
            По_наведению_мыши,
            По_убиранию_мыши,
            Без_триггера
        }

        /// <summary>
        /// Название триггера
        /// </summary>
        public string triggerName;
        /// <summary>
        /// Название функции триггера
        /// </summary>
        public string functionName;
        /// <summary>
        /// Список действий, которые необходимо будет 
        /// выполнить по срабатыванию триггера
        /// </summary>
        public List<ScriptAction> actions;
        /// <summary>
        /// Тип триггера
        /// </summary>
        public triggerType type;

        /// <summary>
        /// Козвращаем код скрипта
        /// </summary>
        public string getScript
        {
            get
            {
                string ex = "";
                //Формируем список действий
                string actions = compileActions();
                //функция добавления триггера
                string addTrigger = getActionByTrigger();

                //Формируем код триггера
                ex = $@"
                    // Trigger name :  { triggerName }
                    function { functionName } () { "{" }
                        //Trigger actions
                        { actions }
                    { "}" }

                    //Добавляем триггер { triggerName }, для элемента elem
                    function addTrigger_{ functionName } (elem) { "{" }
                        { addTrigger }
                    { "}" }
                ";

                return ex;
            }
        }

        /// <summary>
        /// Возвращает основную функцию триггера для вызова
        /// </summary>
        public string getFunction
        {
            get
            {
                return $"{functionName}();";
            }
        }

        /// <summary>
        /// Формируем из дейстций список вызовов функций
        /// </summary>
        /// <returns>Список вызываемых функций с параметрами</returns>
        private string compileActions()
        {
            string ex = "";

            //Проходимся по списку действий
            foreach (var act in actions)
                //Добавляем действие в список
                ex += $"{ act.getActionName }\r\n";

            return ex;
        }

        /// <summary>
        /// Получаем действие по триггеру
        /// </summary>
        /// <returns>Строка с добавлением действия</returns>
        private string getActionByTrigger()
        {
            string ex = "";

            //Выбираем действие по типу
            switch (type)
            {
                case triggerType.Без_триггера:
                    {
                        ex = "";
                        break;
                    }
                case triggerType.По_клику:
                    {
                        //Вызов триггера по клику
                        ex = $"elem.click({functionName}());";
                        break;
                    }
                case triggerType.По_наведению_мыши:
                    {
                        //Вызов триггера по наведению
                        ex = $"elem.mouseenter({functionName}());";
                        break;
                    }
                case triggerType.По_убиранию_мыши:
                    {
                        //Вызов триггера по убиранию
                        ex = $"elem.mouseleave({functionName}());";
                        break;
                    }
            }


            return ex;
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public ScriptTrigger()
        {
            //Устанавливаем дефолтные значения
            actions = new List<ScriptAction>();
            type = triggerType.Без_триггера;


            triggerName = "NewTrigger";
            functionName = "NewTrigger";
            /* Вот тут будет код формирования оригинального названия */
        }

    }
}
