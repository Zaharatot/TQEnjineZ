using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TQEnjineZ
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < 10; i++)
                scenesTree.Items.Add("Scene_" + i.ToString());
            
            DateTime dt = DateTime.Now;

            BitmapImage img = new BitmapImage(new Uri(@"D:\test.png", UriKind.Relative));
            BitmapImage img1 = new BitmapImage(new Uri(@"D:\test1.png", UriKind.Relative));
            BitmapImage img2 = new BitmapImage(new Uri(@"D:\test2.png", UriKind.Relative));
            //   img.CreateOptions = BitmapCreateOptions.None;



            TQEnjineZ.Clases.Wrappers.zBitmap.zBitmap pic = new Clases.Wrappers.zBitmap.zBitmap(img);

            pic.editLayer("Background", null, null, null, 70);
            
            pic.addLayer("ulitka", img1, 1, true, 50);
            pic.addLayer("zayats", img2, 2, true, 40);
            

            CreateThumbnail(@"D:\testImage.png", pic.GetFinalImage.Clone());

            DateTime dt1 = DateTime.Now;

            double time = (dt1 - dt).TotalSeconds;
            //Смешивание 3 картинок 250х250 идёт аж 0,3 секунды! Нужно ускорять...
            //3 картинки 1500х1500 обрабатываются 9 секунд =_=. очень фейловый результат.
            //UPDATE
            //Довёл скорость обработки трёх картинок 1500х1500 до 3,14 секунд. Прогресс =_=
            //Правда, при этом перестало работать всё
            //UPDATE2
            //Довёл скорость обработки трёх слоёв по 1500х1500, до 1,15 секунд
            //(Правда теперь, формирование картинки происходит при её выводе)
            //Зато - поправил все косяки
            //Update3
            //Изменение формулы на дефолтную из вики дало прирост до 1 секунды
            //Update3,5
            //Мелкая правка дала прирост до 0,93 секунд
            //Update4
            //Довёл время обработки 3 слоёв до 0,522 секунд
            //Пилять... Перевёл на байты, теперь косяк с цветами >_<
            //Да и с рассчётом альфа канала тоже...
            //Update5.
            //Пофиксил проблему с цветами. Текущее время работы - 0,58 секунд...
            //Многовато, конечно, но в целом - приемлемо. 
            //Если грузить кучу картинок такого формата в разных потоках - то даже сойдёт.
        }
        

        void CreateThumbnail(string filename, BitmapSource image5)
        {
            if (filename != string.Empty)
            {
                using (FileStream stream5 = new FileStream(filename, FileMode.Create))
                {
                    PngBitmapEncoder encoder5 = new PngBitmapEncoder();
                    encoder5.Frames.Add(BitmapFrame.Create(image5));
                    encoder5.Save(stream5);
                }
            }
        }
    }

}
