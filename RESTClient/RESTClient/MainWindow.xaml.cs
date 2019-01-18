using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace RESTClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                wc.UploadString("URL", "PUT", "NEUE BUCH");

                //wc.Headers.Add("Accept", "text/xml");
                //wc.Credentials = new NetworkCredential("Fred", "password");
                wc.UseDefaultCredentials = true;
                var json = await wc.DownloadStringTaskAsync("https://www.googleapis.com/books/v1/volumes?q=wcf");
                //tb.Text = json;
                var br = Newtonsoft.Json.JsonConvert.DeserializeObject<BooksResult>(json);
                myGrid.ItemsSource = br.items.Select(x => x.volumeInfo);
            }
        }
    }
}
