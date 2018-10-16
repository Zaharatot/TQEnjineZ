using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TQEnjineZ.Clases.Wrappers.Parameters
{
    /// <summary>
    /// Класс, осуществляющий загрузку и сохранение 
    /// пользовательских параметров
    /// </summary>
    class ParameterLoader
    {
        /// <summary>
        /// Путь к файлам игр
        /// </summary>
        private string path;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public ParameterLoader()
        {
            //Инициализраця всякого
            init();
        }

        /// <summary>
        /// Инициализраця всякого
        /// </summary>
        private void init()
        {
            //Инициализируем переменные
            initVariables();
            //Инициализируем путь
            initPath();
        }

        /// <summary>
        /// Инициализируем переменные
        /// </summary>
        private void initVariables()
        {
            //Путь к папке игр
            path = Environment.CurrentDirectory + @"/Content/Games/";


        }

        /// <summary>
        /// Инициализируем путь
        /// </summary>
        private void initPath()
        {
            //Создаём папку, если её до этого не было
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }



        public string loadGame(string )
        {

        }
    }
}
