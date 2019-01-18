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
            tcp.ReliableSession.Enabled = true;

            tcp.Security.Mode = SecurityMode.Transport;
            tcp.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
            tcp.Security.Message.ClientCredentialType = MessageCredentialType.Windows;

            tcp.MaxReceivedMessageSize = int.MaxValue;


            var http = new WSDualHttpBinding();
            http.MaxReceivedMessageSize = int.MaxValue;
            http.MaxBufferPoolSize = int.MaxValue;
            http.Security.Mode = WSDualHttpSecurityMode.None;


            var host = new ServiceHost(typeof(Server));
            host.AddServiceEndpoint(typeof(IServer), tcp, "net.tcp://localhost:1");
            host.AddServiceEndpoint(typeof(IServer), http, "http://localhost:5555/chat");
            


            host.UnknownMessageReceived += (s, e) => Console.WriteLine(e.Message);
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
