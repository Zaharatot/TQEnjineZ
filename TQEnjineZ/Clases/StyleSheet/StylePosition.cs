using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace TQEnjineZ.Clases.StyleSheet
{
    /// <summary>
    /// Информация о позиции стиля
    /// </summary>
    class StylePosition
    {       
        /// <summary>
        /// Тип отображения объекта сцены
        /// </summary>
        public enum SceneObjectDisplay
        {
            Не_отображается,
            Указанный_размер,
            Заполнение,
            Левый_край,
            Верхний_край,
            Нижний_край,
            Правый_край,
            Центрировать
        }


        /// <summary>
        /// Тип отображения элемента
        /// </summary>
        public SceneObjectDisplay displayMode { get; set; }
        /// <summary>
        /// Ширина объекта сцены
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// Высота объекта сцены
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// Координата левого верхнего угла обекта сцены, по оси X
        /// </summary>
        public int Left { get; set; }
        /// <summary>
        /// Координата левого верхнего угла обекта сцены, по оси Y
        /// </summary>
        public int Top { get; set; }
        /// <summary>
        /// Слой объекта сцены
        /// </summary>
        public int Layer { get; set; }

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
        /// Возвращает CSS-стиль шрифта
        /// </summary>
        public string getCss
        {
            get
            {
                //Возвращаем кусок файла стилей, с параметрами позиции
                return generateCss();
            }
        }

        /// <summary>
        /// Формируем стиль для данного блока
        /// </summary>
        /// <returns>Строка с описанием стиля</returns>
        private string generateCss()
        {
            string ex = "";

            //Выбираем по стилю отображения
            switch (displayMode)
            {
                case SceneObjectDisplay.Заполнение:
                    {
                        ex = $@"
                                position: Absolute;
                                left: 0px;
                                top: 0px;
                                width: 100%;
                                height: 100%;
                                margin: 0px;
                                display: block;
                                z-index: {Layer};
                            ";
                        break;
                    }
                case SceneObjectDisplay.Центрировать:
                    {
                        //Считаем сдвиги
                        int mt = Height / 2;
                        int mr = Width / 2;

                        ex = $@"
                                position: Absolute;
                                left: 50%;
                                top: 50%;
                                width: {Width}px;
                                height: {Height}px;
                                margin: -{mt}px 0px 0px -{mr}px; 
                                display: block;
                                z-index: {Layer};
                            ";
                        break;
                    }
                case SceneObjectDisplay.Указанный_размер:
                    {
                        ex = $@"
                                position: Absolute;
                                left: {Left}px;
                                top: {Top}px;
                                width: {Width}px;
                                height: {Height}px;
                                margin: 0px;
                                display: block;
                                z-index: {Layer};
                            ";
                        break;
                    }
                case SceneObjectDisplay.Не_отображается:
                    {
                        ex = $@"
                                position: Absolute;
                                left: 0px;
                                top: 0px;
                                width: 0px;
                                height: 0px;
                                margin: 0px;
                                display: none;
                                z-index: {Layer};
                            ";
                        break;
                    }
                case SceneObjectDisplay.Верхний_край:
                    {
                        ex = $@"
                                position: Absolute;
                                left: 0px;
                                top: 0px;
                                width: 100%;
                                height: {Height}px;
                                margin: 0px;
                                display: block;
                                z-index: {Layer};
                            ";
                        break;
                    }
                case SceneObjectDisplay.Левый_край:
                    {
                        ex = $@"
                                position: Absolute;
                                left: 0px;
                                top: 0px;
                                width: {Width}px;
                                height: 100%;
                                margin: 0px;
                                display: block;
                                z-index: {Layer};
                            ";
                        break;
                    }
                case SceneObjectDisplay.Нижний_край:
                    {
                        ex = $@"
                                position: Absolute;
                                left: 0px;
                                bottom: 0px;
                                width: 100%;
                                height: {Height}px;
                                margin: 0px;
                                display: block;
                                z-index: {Layer};
                            ";
                        break;
                    }
                case SceneObjectDisplay.Правый_край:
                    {
                        ex = $@"
                                position: Absolute;
                                right: 0px;
                                top: 0px;
                                width: {Width}px;
                                height: 100%;
                                margin: 0px;
                                display: block;
                                z-index: {Layer};
                            ";
                        break;
                    }
            }

            return ex;
        }

        /// <summary>
        /// Инициализация позиции стиля дефолтными значениями
        /// </summary>
        public StylePosition()
        {
            //Прописываем дефолтные параметры 
            Width = 0;
            Height = 0;
            Left = 0;
            Top = 0;
            Layer = 0;
            displayMode = SceneObjectDisplay.Заполнение;
            //Инициализируем дефолтные значения
            styleName = "newFontStyle";

            /* вот тут будет получение уникального названия класса */
        }
    }
}
