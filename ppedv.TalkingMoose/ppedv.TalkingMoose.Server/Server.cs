using ppedv.TalkingMoose.Contracts;
using System;
using System.IO;

namespace ppedv.TalkingMoose.Server
{
    public class Server : IServer
    {
        public void Login(string name)
        {
            Console.WriteLine($"Login: {name}");
        }

        public void Logout()
        {
            Console.WriteLine($"Logout");
        }

        public void SendFile(Stream file)
        {
            Console.WriteLine($"SendFile");
        }

        public void SendPic(Stream pic)
        {
            Console.WriteLine($"SendPic");
        }

        public void SendText(string txt)
        {
            Console.WriteLine($"SendText: {txt}");
        }
    }
}
