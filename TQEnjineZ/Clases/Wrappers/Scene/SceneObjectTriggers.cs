using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TQEnjineZ.Clases.Wrappers.Scene
{
    /// <summary>
    /// Список триггеров объекта сцены
    /// </summary>
    class SceneObjectTriggers
    {
        /// <summary>
        /// Список триггеров объекта
        /// </summary>
        public List<string> triggers { get; set; }


        /// <summary>
        /// Возвращает информацию о триггерах
        /// </summary>
        public string getTriggers
        {
            get
            {
                //Проверяем, есть ли триггеры
                bool triggerON = (triggers.Count > 0);
                string triggerList = "";

                //Проходимся по списку триггеров
                foreach (var trigger in triggers)
                    //Добавляем их в общий список
                    triggerList += $"{trigger}; ";

                return $"trigger_on=\"{triggerON}\" triggerList=\"{triggerList}\"";
            }
        }


        /// <summary>
        /// Конструктор класса
        /// </summary>
        public SceneObjectTriggers()
        {
            triggers = new List<string>();
        }

    }
}
