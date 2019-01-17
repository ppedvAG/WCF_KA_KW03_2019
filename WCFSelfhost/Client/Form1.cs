using Contracts;
using System;
using System.ServiceModel;
using System.Windows.Forms;
using WCFSelfhost;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var bind = new NetTcpBinding();
            var cf = new ChannelFactory<IBurgerService>(bind, "net.tcp://localhost:2");

            var client = cf.CreateChannel();

            //try
            {
                dataGridView1.DataSource = client.GetBurgers();
            }
            //catch (FaultException<BurgerException> bex)
            //{
            //    MessageBox.Show($"BEXXXXX: {bex.Message}");
            //}
            //catch (FaultException fex)
            //{
            //    MessageBox.Show(fex.Reason.ToString());
            //}

            var co = (ICommunicationObject)client;
            co.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var bind = new BasicHttpBinding();
            var cf = new ChannelFactory<IBurgerService>(bind, "http://localhost:1");

            var client = cf.CreateChannel();

            dataGridView1.DataSource = client.GetBurgers();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var bind = new WSHttpBinding();
            var cf = new ChannelFactory<IBurgerService>(bind, "http://localhost:3");

            var client = cf.CreateChannel();

            dataGridView1.DataSource = client.GetBurgers();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var bind = new NetNamedPipeBinding();
            var cf = new ChannelFactory<IBurgerService>(bind, "net.pipe://localhost/Burger");

            var client = cf.CreateChannel();

            dataGridView1.DataSource = client.GetBurgers();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var bind = new UdpBinding();

            var cf = new ChannelFactory<IBurgerService>(bind, "soap.udp://localhost:4");

            var client = cf.CreateChannel();

            dataGridView1.DataSource = client.GetBurgers();

        }
    }
}
