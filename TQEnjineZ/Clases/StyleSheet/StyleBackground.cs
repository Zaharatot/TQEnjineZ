using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using TQEnjineZ.Clases.StyleSheet.StyleImage;

namespace TQEnjineZ.Clases.StyleSheet
{
    /// <summary>
    /// Информация о заднем плане стиля
    /// </summary>
    class StyleBackground
    {
        /// <summary>
        /// Режим встраивания картинки
        /// </summary>
        public enum sizeMode
        {
            unset = 0,      //Не задан
            auto = 1,       //Автоматический - картинки будут в своём дефолтном размере
            contain = 2,    //Автоматически сожмёт/растянет картинку так, чтобы 
                            //она влезала в блок, но если размеры блока с картинкой не 
                            //совпадут, то часть блока будет без картинки
            cover = 3       //Растянет картинку по одной из сторон (самой большой)
        }

        /// <summary>
        /// Название стиля в программе
        /// </summary>
        public string styleName { get; set; }
        /// <summary>
        /// Название класса. Генерироваться будет автоматически
        /// при формировании CSS-файла
        /// </summary>
        public string className { get; private set; }

        /// <summary>
        /// Прозрачность элемента
        /// </summary>
        public int opacity { get; set; }
        /// <summary>
        /// Цвет заднего фона
        /// </summary>
        public Color color { get; set; }
        /// <summary>
        /// Картинка заднего фона
        /// </summary>
        public LayeredImage image { get; set; }
        /// <summary>
        /// Режим заполнения картинкой блока
        /// </summary>
        public sizeMode size { get; set; }

        /// <summary>
        /// Возвращает CSS-стиль шрифта
        /// </summary>
        public string getCss
        {
            get
            {      
                //Возвращаем кусок файла стилей, с параметрами данного фона
                return $@"           
                        background-color: { OtherFuncs.getCssCloor(color) };
                        background-size: { size };
                        background: { image.getCss };
                        opacity: { OtherFuncs.getAlpha(opacity, 100) };
                       ";
            }
        }


        /// <summary>
        /// Инициализация фона стиля дефолтными значениями
        /// </summary>
        public StyleBackground()
        {
            //Прописываем дефолтные параметры заднего фона
            //цвет - белый
            color = Color.FromRgb(255, 255, 255);
            //Картинка - дефолтная
            image = new LayeredImage();
            //Режим заполнения - не задан
            size = sizeMode.unset;
            //Инициализируем дефолтные значения
            styleName = "newBackgroundStyle";

            /* вот тут будет получение уникального названия класса */
        }
    }
}
