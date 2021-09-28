using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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

        private dynamic getPage()
        {
            WebClient client = new WebClient() { Encoding = System.Text.Encoding.UTF8 };
            string urlMain= "http://worldtimeapi.org/api/timezone/Europe/London";
            string japan = urlMain;
            string text = client.DownloadString(japan);
            return JsonConvert.DeserializeObject(text);
        }

        private string getTime()
        {
            dynamic obj = getPage();
            DateTime date = new DateTime(1970, 1, 1).AddSeconds(int.Parse(obj["unixtime"]));

            return date.ToString();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            string type = pressed.Content.ToString();
            TextBlock result = (TextBlock)TextBlockResult;
            switch (type)
            {
                case "Системная дата":
                    MessageBox.Show(getTime().ToString()); ;
                    break;
                default:
                    break;
            }
        }
    }
}
