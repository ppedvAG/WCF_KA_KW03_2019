using System;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace WCFSelfhost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** WCF Host ***");

            var httpBind = new BasicHttpBinding();
            var tcpBind = new NetTcpBinding();
            var pipeBind = new NetNamedPipeBinding();
            var wsHttpBind = new WSHttpBinding();
            var mqBind = new NetMsmqBinding();
            var udpBding = new UdpBinding();

            var host = new ServiceHost(typeof(BurgerService));

            host.AddServiceEndpoint(typeof(IBurgerService), httpBind, "http://localhost:1/");
            host.AddServiceEndpoint(typeof(IBurgerService), tcpBind, "net.tcp://localhost:2/");
            host.AddServiceEndpoint(typeof(IBurgerService), pipeBind, "net.pipe://localhost/Burger");
            host.AddServiceEndpoint(typeof(IBurgerService), wsHttpBind, "http://localhost:3/");
            host.AddServiceEndpoint(typeof(IBurgerService), udpBding, "soap.udp://localhost:4/");
            //nur One-way
            //host.AddServiceEndpoint(typeof(IBurgerService), mqBind, "net.msmq://localhost/private/Burger");


            var smb = new ServiceMetadataBehavior()
            {
                HttpGetEnabled = true,
                HttpGetUrl = new Uri("http://localhost:1/mex")
            };
            host.Description.Behaviors.Add(smb);

            host.Open();
            Console.WriteLine("Service läuft");
            Console.ReadLine();
            host.Close();


            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }

}
