using BLZClient.ServiceReference1;
using System;
using System.Windows.Forms;

namespace BLZClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var client = new BLZServicePortTypeClient("BLZServiceSOAP12port_http");

            var result = client.getBank(textBox1.Text);
            //label1.Text = string.Format("{0}\n{1}\n{2} {3}", result.bezeichnung, result.bic, result.plz, result.ort);
            label1.Text = $"{result.bezeichnung}\n{result.bic}\n{result.plz} {result.ort}";
        }
    }
}
