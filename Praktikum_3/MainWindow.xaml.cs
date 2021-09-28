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

        private dynamic getDataJson(string location)
        {
            WebClient client = new WebClient() { Encoding = System.Text.Encoding.UTF8 };
            long unixTime = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds();
            string urlMain = String.Format("https://maps.googleapis.com/maps/api/timezone/json?location={0}&timestamp={1}&key={2}", 
                location,
                unixTime,
                "AIzaSyDZXNyu8SBDGP8sTHAduhTYFidcsPjwHqs"
                );
            string text = client.DownloadString(urlMain);
            return JsonConvert.DeserializeObject(text);
        }
        private DateTime getTimeNow()
        {
            return DateTime.Now;
        }
        private string getTime(string location)
        {
            dynamic obj = getDataJson(location);
            int dstOffset = obj["dstOffset"];
            int rawOffset = obj["rawOffset"];
            DateTime date = getTimeNow().AddSeconds(-10800);
            DateTime currentDate = date.AddSeconds(dstOffset + rawOffset);
            return currentDate.ToString();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            string type = pressed.Content.ToString();
            TextBlock result = TextBlockResult;
            switch (type)
            {
                case "Системное время":
                    result.Text = getTimeNow().ToString();
                    break;
                case "Лондон":
                    result.Text = getTime("51.528308,-0.3817765");
                    break;
                case "Токио":
                    result.Text = getTime("35.5062647,138.6458125");
                    break;
                case "Чикаго":
                    result.Text = getTime("41.875732, -87.623766");
                    break;
                default:
                    break;
            }
            TextBlockResult.Visibility = Visibility.Visible;
        }
    }
}
