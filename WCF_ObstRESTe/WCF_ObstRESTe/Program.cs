using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace WCF_ObstRESTe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** WCF ObstRESTe ***");

            var web = new WebHttpBinding();
            web.Security.Mode = WebHttpSecurityMode.TransportCredentialOnly;
            web.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;

            var host = new ServiceHost(typeof(Obstservice));
            var ep = host.AddServiceEndpoint(typeof(IObstService), web, "http://localhost:1");

            ep.EndpointBehaviors.Add(new WebHttpBehavior()
            {
                AutomaticFormatSelectionEnabled = true
            });

            host.Open();
            Console.ReadLine();
            host.Close();

            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}
