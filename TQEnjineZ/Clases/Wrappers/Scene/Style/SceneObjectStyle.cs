using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TQEnjineZ.Clases.Wrappers.Scene.Style
{
    /// <summary>
    /// Стиль объекта сцены
    /// </summary>
    class SceneObjectStyle
    {
        /// <summary>
        /// Делегат события изменения стиля объекта сцены
        /// </summary>
        public delegate void EditStyleEvent();
        /// <summary>
        /// Ивент изменения цвета объекта сцены
        /// </summary>
        public event EditStyleEvent EditColor;
        /// <summary>
        /// Ивент изменения шрифта объекта сцены
        /// </summary>
        public event EditStyleEvent EditFont;

        /// <summary>
        /// Цвет стиля
        /// </summary>
        private SceneObjectStyleColor styleColor;
        /// <summary>
        /// Шрифт стиля
        /// </summary>
        private SceneObjectStyleFont styleFont;



        /// <summary>
        /// Публичные параметры цвета стиля
        /// </summary>
        public SceneObjectStyleColor Color
        {
            get
            {
                return styleColor;
            }
            set
            {
                //Присваиваем цвета стиля1
                styleColor = value;
                //Добавляем прослушку внутренних ивентов
                Color.EditColor += Color_EditColor;
                //Вызываем ивент
                EditColor?.Invoke();
            }
        }
        
        /// <summary>
        /// Публичные параметры шрифта стиля
        /// </summary>
        public SceneObjectStyleFont Font
        {
            get
            {
                return styleFont;
            }
            set
            {
                //Присваиваем цвета стиля1
                styleFont = value;
                //Добавляем прослушку внутренних ивентов
                Font.EditFont += Font_EditFont;
                //Вызываем ивент
                EditFont?.Invoke();
            }
        }

        /// <summary>
        /// Инициализация объекта сцены дефолтными значениями
        /// </summary>
        public SceneObjectStyle()
        {
            //Инициализируем дефолтные значения
            Color = new SceneObjectStyleColor();
            Font = new SceneObjectStyleFont();
            //Добавляем прослушку внутренних ивентов
            Color.EditColor += Color_EditColor;
            Font.EditFont += Font_EditFont;
        }

        /// <summary>
        /// ивент изменения шрифта
        /// </summary>
        private void Font_EditFont()
        {
            //Вызываем внешний ивент
            EditFont?.Invoke();
        }

        /// <summary>
        /// ивент изменения цвета
        /// </summary>
        private void Color_EditColor()
        {
            //Вызываем внешний ивент
            EditColor?.Invoke();
        }
    }
}
