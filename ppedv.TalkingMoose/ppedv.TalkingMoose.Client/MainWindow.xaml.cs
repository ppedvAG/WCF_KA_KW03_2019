using ppedv.TalkingMoose.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.Windows;

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

            string adr = "net.tcp://localhost:1";
            NetTcpBinding tcp = new NetTcpBinding();

            var cf = new DuplexChannelFactory<IServer>(this, tcp, new EndpointAddress(adr));
            server = cf.CreateChannel();
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
            throw new NotImplementedException();
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
    }
}
