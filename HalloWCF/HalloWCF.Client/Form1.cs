using HalloWCF.Client.ServiceReference1;
using System;
using System.Threading;
using System.Windows.Forms;

namespace HalloWCF.Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

#if DEBUG
            Console.Beep();
#endif
        }
        Service1Client client = new Service1Client();

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = client.GetObst();
        }

        private void getButton2_Click(object sender, EventArgs e)
        {

            label1.Text = client.GetData().ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            client.SetData((int)numericUpDown1.Value);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            client.Verdoppeln(6);
        }
    }
}
