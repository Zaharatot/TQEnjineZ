using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;


namespace TQEnjineZ.Clases.Wrappers.Scene
{
    /// <summary>
    /// Стиль объекта сцены
    /// </summary>
    class SceneObjectStyle
    {
        /// <summary>
        /// Список классов объекта
        /// </summary>
        public List<string> classes { get; set; }


        /// <summary>
        /// Возвращает информацию о классах объекта
        /// </summary>
        public string getClass
        {
            get
            {
                string classList = "";

                //Проходимся по списку классов
                foreach (var clas in classes)
                    //Добавляем их в общий список
                    classList += $"{clas} ";

                return $"class=\"{classList}\"";
            }
        }



        /// <summary>
        /// Инициализация объекта сцены дефолтными значениями
        /// </summary>
        public SceneObjectStyle()
        {
            //Инициализируем пустой массив
            classes = new List<string>();
        }      
    }
}
