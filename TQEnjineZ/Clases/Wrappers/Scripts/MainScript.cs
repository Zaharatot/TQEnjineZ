using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TQEnjineZ.Clases.Wrappers.Scripts
{
    /// <summary>
    /// Основной класс формирования скриптов
    /// </summary>
    class MainScript
    {
        /// <summary>
        /// Список триггеров
        /// </summary>
        public List<ScriptTrigger> triggers;

        /// <summary>
        /// Возвращает сформированный js-файл, со списком триггеров
        /// </summary>
        public string getJS
        {
            get
            {
                string ex = "";

                //Проходимся по списку триггеров
                foreach (var trigger in triggers)
                    //Добавляем их код в наш файл
                    ex += trigger.getScript + "\r\n";

                return ex;
            }
        }



        /// <summary>
        /// Конструктор класса
        /// </summary>
        public MainScript()
        {
            //Добавляем триггер
            triggers = new List<ScriptTrigger>();
        }
    }
}
