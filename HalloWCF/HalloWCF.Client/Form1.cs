using HalloWCF.Client.ServiceReference1;
using System;
using System.Windows.Forms;

namespace HalloWCF.Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new Service1Client();
            dataGridView1.DataSource = client.GetObst();
        }
    }
}
