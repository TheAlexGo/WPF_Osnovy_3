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

        // Обработчик наведения на объект Run.
        private void run_MouseEnter(object sender, MouseEventArgs e)
        {
            // Делаем Popup видимым.
            popLink.IsOpen = true;
        }
        // Переход по ссылке.
        private void lnk_Click(object sender, RoutedEventArgs e)
        {
            string fileName = ((Hyperlink)sender).NavigateUri.ToString();
            // Запускаем приложение, которое ассоциируется с файлом.
            Process.Start(fileName);
        }
    }
}
