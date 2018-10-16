using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TQEnjineZ.Clases.Wrappers.WorkClasses;

namespace TQEnjineZ.Clases.Wrappers.StyleSheet.StyleImage
{
    /// <summary>
    /// Изображение в сцене, состоящее из нескольких слоёв
    /// </summary>
    class LayeredImage
    {
        /// <summary>
        /// Список слоёв картинок, по их id
        /// </summary>
        private Dictionary<int, ImageLayer> images;

        /// <summary>
        /// Возвращает слой, в виде css стиля заднего фона
        /// </summary>
        public string getCss
        {
            get
            {
                string ex = "";
                //Если есть хоть одна картинка
                if (images.Count > 0)
                {
                    //Получаем список отсортированных слоёв
                    var layers = getSortedLayers();
                    //Добавляем первый слой в список
                    ex = string.Format("{0} no-repeat", layers.First().Value.image.getCss);
                    //Проходимся по оставшимся слоям
                    for (int i = 1; i < layers.Count; i++)
                        ex += string.Format(", {0} no-repeat", layers[i].Value.image.getCss);
                }
                //Если слоёв нету, вернём пустой стиль
                else
                    ex = "";

                return ex;
            }
        }

        /// <summary>
        /// Инициализация слоёной каринки
        /// </summary>
        public LayeredImage()
        {
            images = new Dictionary<int, ImageLayer>();
        }

        /// <summary>
        /// Добавляем новый слой
        /// </summary>
        /// <param name="image">Сама картинка</param>
        /// <param name="zIndex">Индекс в порядке слоёв</param>
        /// <param name="layerName">Название слоя</param>
        public void addImageLayer(Base64Image image, int zIndex, string layerName = "")
        {
            //Инициализируем новый слой
            ImageLayer layer = new ImageLayer {
                name = layerName,
                image = image,
                zIndex = zIndex
            };

            //Если такой слой уже есть, мы его заменяем.
            if (images.ContainsKey(zIndex))
                images[zIndex] = layer;
            //В противном случае - просто добавляем новый
            else
                images.Add(zIndex, layer);
        }

        /// <summary>
        /// Получаем изображение по id слоя
        /// </summary>
        /// <param name="zIndex">id слоя</param>
        /// <returns>Картинка, или null, если такого слоя нету в списке</returns>
        public Base64Image getImageFromLayer(int zIndex)
        {
            Base64Image ex = null;

            //Если такой слой найден - возвращаем его картинку
            if (images.ContainsKey(zIndex))
                ex = images[zIndex].image;
            //В проитивном случае - возвращаем null           

            return ex;
        }

        /// <summary>
        /// Получаем слой по id
        /// </summary>
        /// <param name="zIndex">id слоя</param>
        /// <returns>Картинка, или null, если такого слоя нету в списке</returns>
        public ImageLayer getLayerFromId(int zIndex)
        {
            ImageLayer ex = null;

            //Если такой слой найден - возвращаем его картинку
            if (images.ContainsKey(zIndex))
                ex = images[zIndex];
            //В проитивном случае - возвращаем null           

            return ex;
        }


        /// <summary>
        /// Возвращает список слоёв, отсортированных в нужном порядке
        /// </summary>
        /// <returns>Список сортированных слоёв</returns>
        private List<KeyValuePair<int, ImageLayer>> getSortedLayers()
        {
            //Получаем список из словаря
            var imgList = images.ToList();
            //Сортируем список по индексу расположения
            imgList.Sort((a, b) => {
                return b.Value.zIndex.CompareTo(a.Value.zIndex);
            });

            return imgList;
        }
    }
}
