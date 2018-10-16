using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TQEnjineZ.Clases.Wrappers.WorkClasses;


namespace TQEnjineZ.Clases.Wrappers.StyleSheet.StyleImage
{
    /// <summary>
    /// Небольшой класс, просто для хранения информации о слое
    /// </summary>
    class ImageLayer
    {
        /// <summary>
        /// Название слоя
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Id слоя в порядке слоёв
        /// </summary>
        public int zIndex { get; set; }
        /// <summary>
        /// Картинка расположенная на слое
        /// </summary>
        public Base64Image image { get; set; }
    }
}
