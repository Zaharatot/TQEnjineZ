using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TQEnjineZ.Clases.Scripts
{
    /// <summary>
    /// Класс, реализующий триггер скрипта
    /// </summary>
    class ScriptTrigger
    {
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
        /// Козвращаем код скрипта
        /// </summary>
        public string getScript
        {
            get
            {
                string ex = "";
                //Формируем список действий
                string actions = compileActions();

                //Формируем код триггера
                ex = $@"
                    // Trigger name :  { triggerName }
                    function { functionName } () { "{" }
                        //Trigger actions
                        { actions }
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
        /// Конструктор класса
        /// </summary>
        public ScriptTrigger()
        {
            //Устанавливаем дефолтные значения
            actions = new List<ScriptAction>();

            triggerName = "NewTrigger";
            functionName = "NewTrigger";
            /* Вот тут будет код формирования оригинального названия */
        }

    }
}
