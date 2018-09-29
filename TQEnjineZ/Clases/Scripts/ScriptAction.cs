using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TQEnjineZ.Clases.Scripts
{
    /// <summary>
    /// Действие для триггера
    /// </summary>
    class ScriptAction
    {
        /// <summary>
        /// Список вариантов анимации
        /// </summary>
        public enum AnimationType
        {
            Без_действия,       //Без анимации
            Мерцание,           //Анимация, с эффектом мерцания (медленно прозрачность опускается до 0, и наоборот)
            Мигание,            //Анимация, с эффектом мигания (объект исчезает и появляется)
            Перемещение,        //Анимация, с эффектом передвижения
            Прозрачность,       //Анимация, с эффектом изменения прозрачности
            Цвет,               //Анимация, с эффектом плавного изменения цвета
            Смена_сцены         //Переход на другую сцену
        }

        /// <summary>
        /// Список параметров, для анимации
        /// </summary>
        public string[] animationParameters { get; set; }
        /// <summary>
        /// Тип анимации
        /// </summary>
        public AnimationType type { get; set; }

        /// <summary>
        /// Возвращает название функции, которая будет вызываться
        /// </summary>
        public string getActionName
        {
            get
            {
                // Возвращаем название функции по типу анимации
                return getFuncName();
            }
        }

        /// <summary>
        /// Возвращает название функции по типу анимации
        /// </summary>
        /// <returns>Название функции с параметрами</returns>
        private string getFuncName()
        {
            string ex = "";

            //Парсим параметры в строку JSON
            string json = OtherFuncs.objectToJSON(animationParameters);

            //Выбираем название по типу
            switch (type)
            {
                case AnimationType.Без_действия:
                    {
                        ex = "";
                        break;
                    }
                case AnimationType.Мерцание:
                    {
                        ex = $"animate_blink({ json });";
                        break;
                    }
                case AnimationType.Мигание:
                    {
                        ex = $"animate_flash({ json });";
                        break;
                    }
                case AnimationType.Перемещение:
                    {
                        ex = $"animate_move({ json });";
                        break;
                    }
                case AnimationType.Прозрачность:
                    {
                        ex = $"animate_opacity({ json });";
                        break;
                    }
                case AnimationType.Цвет:
                    {
                        ex = $"animate_color({ json });";
                        break;
                    }
                case AnimationType.Смена_сцены:
                    {
                        ex = $"scene_redirect({ json });";
                        break;
                    }
            }

            return ex;
        }



        /// <summary>
        /// Инициализация дефолтных анимаций
        /// </summary>
        public ScriptAction()
        {
            //Ставим дефолтные параметры
            animationParameters = new string[0];
            type = AnimationType.Без_действия;
        }
    }
}
