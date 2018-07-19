using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TQEnjineZ.Clases.Wrappers.WorkClasses
{
    /// <summary>
    /// Изображение, в формате Base64, для прямого встраивания 
    /// в html-код страницы
    /// </summary>
    class Base64Image
    {
        /// <summary>
        /// Base64 представление картинки
        /// </summary>
        public string imageContent { get; private set; }

        /// <summary>
        /// Возвращаем html-тег с картинкой
        /// </summary>
        public string getHtml
        {
            get
            {
                return string.Format("<img src='{0}' />", imageContent);
            }
        }
        /// <summary>
        /// Возвращаем css с картинкой
        /// </summary>
        public string getCss
        {
            get
            {
                return string.Format("url('{0}')", imageContent);
            }
        }

        /// <summary>
        /// Инициализируем пустую картинку
        /// </summary>
        public Base64Image()
        {
            imageContent = Properties.Resources.noImageBase64;
        }

        /// <summary>
        /// Инициализируем картинку из строки
        /// </summary>
        /// <param name="image">Base64 строка с содержимым картинки, либо путь к файлу на диске</param>
        /// <param name="loadFlag">True - грузим картинку из файла. False - просто принимает её байты</param>
        public Base64Image(string image, bool loadFlag = false)
        {
            //Если грузим файл
            if (loadFlag)
                //Получаем base64 строку из файла
                imageContent = loadImageFromFile(image);
            //Если ничего грузить не нужно
            else
                imageContent = image;
        }        

        /// <summary>
        /// Загружаем картинку из файла
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Содержимое картинки</returns>
        private string loadImageFromFile(string path)
        {
            string ex = "";
            bool result = false;

            try
            {
                //Инициализируем инфу о файле
                FileInfo fi = new FileInfo(path);
                //Если такой файл вообще есть
                if (fi.Exists)
                {
                    //Считываем все байты файла
                    var bytes = File.ReadAllBytes(path);
                    //Получаем формат файла
                    var ext = fi.Extension.Substring(1);
                    //Формируем строку контента, в base64 формате
                    ex = string.Format("data:image/{0};base64,{1}", ext,
                        Convert.ToBase64String(bytes));
                    //Говорим, что с загрузкой всё ок
                    result = true;
                }
            }
            catch { }
            //Если у нас косяк с загрузкой, то подгружаем 
            //пустую картинку из ресурсов
            if (!result)
                ex = Properties.Resources.noImageBase64;

            return ex;
        }
    }
}
