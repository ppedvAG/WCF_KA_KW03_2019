using ppedv.TalkingMoose.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.TalkingMoose.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Takling MOOOOOOSE Server v0.1  ***");

            var tcp = new NetTcpBinding();

            var host = new ServiceHost(typeof(Server));
            host.AddServiceEndpoint(typeof(IServer), tcp, "net.tcp://localhost:1");

            host.Open();
            Console.WriteLine("Server gestartet");
            Console.ReadLine();
            host.Close();
            Console.WriteLine("Server beendet");

            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}
