using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TQEnjineZ.Clases.Wrappers.Scripts;
using TQEnjineZ.Clases.Wrappers.StyleSheet;
using TQEnjineZ.Clases.Wrappers.Scene;

namespace TQEnjineZ.Clases.Wrappers
{
    /// <summary>
    /// Класс, реализующий загрузку нужных 
    /// дополнительных файлов страницы.
    /// </summary>
    class PageLoader
    {
        /// <summary>
        /// Файл стилей страницы
        /// </summary>
        private MainCss css;
        /// <summary>
        /// Файл скриптов страницы
        /// </summary>
        private MainScript script;
        /// <summary>
        /// Файл сцены
        /// </summary>
        private SceneObjectBase scene;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public PageLoader()
        {
            //Инициализируем дефолты
            css = new MainCss();
            script = new MainScript();
            scene = new SceneObjectBase();
        }

        /// <summary>
        /// Загружаем страницу
        /// </summary>
        /// <param name="gameName">Название игры</param>
        /// <param name="fileType">Тип файла</param>
        /// <param name="fileName">Имя файла</param>
        /// <returns>Страница, для возврата</returns>
        public string loadPage(string gameName, string fileType, string fileName)
        {
            string ex = "";


            return ex;
        }
    }
}
