using Microsoft.Win32;
using ppedv.TalkingMoose.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ppedv.TalkingMoose.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IClient
    {
        IServer server = null;

        public MainWindow()
        {
            InitializeComponent();

            if (true == !true)
            {
                string adr = "net.tcp://192.168.50.33:1";
                NetTcpBinding tcp = new NetTcpBinding();
                tcp.Security.Mode = SecurityMode.Transport;
                tcp.ReliableSession.Enabled = true;
                //tcp.TransferMode = TransferMode.Buffered;
                tcp.MaxReceivedMessageSize = int.MaxValue;


                var cf = new DuplexChannelFactory<IServer>(this, tcp, new EndpointAddress(adr));
                cf.Credentials.Windows.ClientCredential.UserName = "Fred";
                cf.Credentials.Windows.ClientCredential.Password = "123456";

                server = cf.CreateChannel();
            }
            else
            {
                string adr = "http://192.168.50.25:5555/chat";
                WSDualHttpBinding http = new WSDualHttpBinding();
                http.MaxReceivedMessageSize = int.MaxValue;
                http.Security.Mode = WSDualHttpSecurityMode.None;


                var cf = new DuplexChannelFactory<IServer>(this, http, new EndpointAddress(adr));
              //  cf.Credentials.Windows.ClientCredential.UserName = "Fred";
              //  cf.Credentials.Windows.ClientCredential.Password = "123456";

                server = cf.CreateChannel();
            }
        }

        public void LoginFailed(string txt)
        {
            MessageBox.Show($"Login failed: {txt}");
        }

        public void LoginOk()
        {
            nameTb.IsEnabled = false;
            loginBtn.IsEnabled = false;
            logoutBtn.IsEnabled = true;
            msgTb.IsEnabled = true;
            msgBtn.IsEnabled = true;

        }

        public void ShowFile(Stream file)
        {
            throw new NotImplementedException();
        }

        public void ShowPic(Stream pic)
        {
            var ms = new MemoryStream();
            pic.CopyTo(ms);
            ms.Position = 0;

            var img = new Image();
            img.BeginInit();
            img.Source = BitmapFrame.Create(ms, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            img.Stretch = System.Windows.Media.Stretch.None;
            img.EndInit();

            msgLb.Items.Add(img);
        }

        public void ShowText(string txt)
        {
            msgLb.Items.Add(txt);
        }

        public void ShowUserlist(IEnumerable<string> users)
        {
            usersLb.ItemsSource = users;
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            server.Login(nameTb.Text);
        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            server.Logout();
            nameTb.IsEnabled = !false;
            loginBtn.IsEnabled = !false;
            logoutBtn.IsEnabled = !true;
            msgTb.IsEnabled = !true;
            usersLb.ItemsSource = null;
            msgBtn.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            server.SendText(msgTb.Text);
            msgTb.Clear();
            msgTb.Focus();
        }

        private void PicBtn_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "Bild|*.png;*.jpg;*.gif|Irgendwas|*.*";
            if (dlg.ShowDialog().Value)
            {
                var stream = File.OpenRead(dlg.FileName);
                server.SendPic(stream);
            }
        }
    }
}
