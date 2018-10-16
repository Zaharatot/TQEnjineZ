using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using TQEnjineZ.Clases.Wrappers;

namespace TQEnjineZ.Clases.Server
{
    /// <summary>
    /// Класс сервера, который будет выполнять обработку 
    /// запросов страниц, стилей и скриптов
    /// </summary>
    class ServerWorker
    {
        /// <summary>
        /// Порт, к которому образается сервер
        /// </summary>
        private const string port = "31337";
        /// <summary>
        /// Основной поток прослушки портов
        /// </summary>
        private Thread main;
        /// <summary>
        /// Слушатель запросов
        /// </summary>
        private HttpListener listener;

        /// <summary>
        /// ИНициализируем основной класс сервера
        /// </summary>
        public ServerWorker()
        {
            //Инициализируем слушателя
            listener = new HttpListener();
            //Указываем, какой адрес нужно слушать
            listener.Prefixes.Add(string.Format("http://localhost:{0}/TQEnjineZ/", port));
            //Указываем основному потоку его рабочую функцию
            main = new Thread(work);
        }

        /// <summary>
        /// Запускаем сервер
        /// </summary>
        public void startServer()
        {
            //Если основной рабочий поток проинициализирован
            if (main != null)
                //Запускаем его
                main.Start();
        }

        /// <summary>
        /// Останавливаем сервер
        /// </summary>
        public void closeServer()
        {

            try
            {
                //Останавливаем основной рабочий поток
                if (main != null)
                    main.Abort();
                //Если есть слушатель
                if (listener != null)
                {
                    //Если листнер пашет
                    if(listener.IsListening)
                        //Останавливаем прослушивание подключений
                        listener.Stop();
                    //Закрываем слушателя
                    listener.Close();
                }
            }
            catch { }
        }

        /// <summary>
        /// Основная функция главного рабочего потока
        /// </summary>
        private void work()
        {
            HttpListenerContext context;
            HttpListenerRequest request;
            HttpListenerResponse response;
            byte[] buff;

            //Запускаем слушателя
            listener.Start();
            
            //У нас тут бесконечный цикл
            while (true)
            {
                // метод GetContext блокирует текущий поток, ожидая получение запроса 
                context = listener.GetContext();
                request = context.Request;
                // получаем объект ответа
                response = context.Response;
                
                //Парсим запрос, и возвращаем ответ
                buff = getRequestResponse(request.Url.Segments, request.QueryString);

                //Указываем длинну потока ответа в байтах
                response.ContentLength64 = buff.Length;
                //Подключаемся к потоку ответа
                using (Stream output = response.OutputStream)
                {
                    //Пишем в него все имеющиеся байты
                    output.Write(buff, 0, buff.Length);
                    //Закрываем поток
                    output.Close();
                }
            }
        }

        /// <summary>
        /// Возвращает страницу ответа сервера
        /// </summary>
        /// <param name="reqUrlSegments">Адрес запроса, разделённый на части</param>
        /// <param name="queryString">Строка запроса</param>
        /// <returns>Байты ответа</returns>
        private byte[] getRequestResponse(string[] reqUrlSegments, NameValueCollection queryString)
        {
            byte[] ex = new byte[0];
            /*
                 Пример адреса:
                 Обязательные части запроса:
                     0: /               Корень
                     1: TQEnjineZ/      Название сервера
                 Дополнительные части запроса:
                     2: {gameName}      Название игры
                     3: {filetype}      тип загружаемого файла
                     4: {fileId}        Идентификатор файла, который мы подгружаем для данной сцены
                Строка запроса у нас пока что не используется
             */
            //Если в запросе есть все необходимые части
            if (reqUrlSegments.Length > 4)
                //Формируем строку байтов из скомпилированной страницы
                ex = Encoding.Default.GetBytes(compilePageByRequest(
                        removeSlash(reqUrlSegments[2]),
                        removeSlash(reqUrlSegments[3]),
                        removeSlash(reqUrlSegments[4])
                    ));
            //Если у нас ошибка в длинне запроса
            else
            {
                /*
                    Вот тут будет загрузка дефолтной страницы    
                */

            }

            return ex;
        }

        /// <summary>
        /// Удаляем слеш из строки
        /// </summary>
        /// <param name="part">Часть запроса</param>
        /// <returns>Часть запроса без слешей</returns>
        private string removeSlash(string part) =>
            part.Replace("/", "");

        /// <summary>
        /// Компилируем нужную страницу, и возвращаем её
        /// </summary>
        /// <param name="gameName">Название игры</param>
        /// <param name="fileType">Тип файла</param>
        /// <param name="fileName">Имя файла</param>
        /// <returns>Страница, для возврата</returns>
        private string compilePageByRequest(string gameName, string fileType, string fileName)
        {
            //Инициализируем загрузчик страниц
            PageLoader pl = new PageLoader();
            //Грузим нужную страницу
            return pl.loadPage(gameName, fileType, fileName);
        }
    }
}
