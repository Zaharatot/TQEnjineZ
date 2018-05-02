using System;
using System.Collections.Generic;
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

            pic.addLayer("ulitka", img1, 1, true, 100);
            pic.addLayer("zayats", img2, 2, true, 100);


            pictOut.Source = pic.GetFinalImage;
        }
    }
}
