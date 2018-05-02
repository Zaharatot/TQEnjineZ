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


            BitmapImage img = new BitmapImage(new Uri(@"D:\test.png", UriKind.Relative));
            BitmapImage img1 = new BitmapImage(new Uri(@"D:\test1.png", UriKind.Relative));
            BitmapImage img2 = new BitmapImage(new Uri(@"D:\test2.png", UriKind.Relative));
            //   img.CreateOptions = BitmapCreateOptions.None;


            TQEnjineZ.Clases.Wrappers.zBitmap.zBitmap pic = new Clases.Wrappers.zBitmap.zBitmap(img);

            pic.editLayer("Background", null, null, null, 70);

            
            pic.addLayer("ulitka", img1, 1, true, 50);
            pic.addLayer("zayats", img2, 2, true, 40);


            CreateThumbnail(@"D:\testImage.png", pic.GetFinalImage.Clone());
            pictOut.Source = pic.GetFinalImage;
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
