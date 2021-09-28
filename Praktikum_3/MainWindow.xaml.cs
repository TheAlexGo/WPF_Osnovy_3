using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Praktikum_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MouseMoved(object sender, MouseEventArgs e)
        {
            Point pt = e.GetPosition((UIElement)this); // Получение координат мыши, относительно передаваймого элемента.
             lblInfo.Text =
             String.Format(" ({0}; {1}) в оконных координатах.",
             pt.X, pt.Y);
        }
    }
}
