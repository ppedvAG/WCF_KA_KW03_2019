using ppedv.TalkingMoose.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;

namespace ppedv.TalkingMoose.Server
{
    [ServiceBehavior (InstanceContextMode =InstanceContextMode.Single)]
    public class Server : IServer
    {
        static Dictionary<string, IClient> userlist = new Dictionary<string, IClient>();

        public void Login(string name)
        {
            Console.WriteLine($"Login: {name}");

            var client = OperationContext.Current.GetCallbackChannel<IClient>();
            if (userlist.ContainsKey(name))
            {
                var txt = $"Hallo {name}, dein Name wird bereit verwendet";
                client.LoginFailed(txt);
            }
            else
            {
                userlist.Add(name, client);
                client.LoginOk();
                client.ShowText($"Hallo {name}");
                SendUserlist();
            }
        }

        public void Logout()
        {
            var sender = userlist.FirstOrDefault(x => x.Value == OperationContext.Current.GetCallbackChannel<IClient>());

            Console.WriteLine($"Logout {sender.Key}");
            userlist.Remove(sender.Key);
            SendUserlist();
            ActionToAllUsers(x => x.ShowText($"{sender.Key} ist gegangen 🙁"));
        }

        public void SendFile(Stream file)
        {
            Console.WriteLine($"SendFile");
        }

        public void SendPic(Stream pic)
        {
            Console.WriteLine($"SendPic");

            var stream = new MemoryStream();
            pic.CopyTo(stream);
            pic.Close();

            ActionToAllUsers(x =>
            {
                stream.Position = 0;
                x.ShowPic(stream);
            });

        }

        public void SendText(string txt)
        {
            Console.WriteLine($"SendText: {txt} {OperationContext.Current.SessionId}");

            var sender = userlist.FirstOrDefault(x => x.Value == OperationContext.Current.GetCallbackChannel<IClient>());

            ActionToAllUsers(x => x.ShowText($"{sender.Key}: {txt}"));
        }

        private void SendUserlist()
        {

            ActionToAllUsers(x => x.ShowUserlist(userlist.Select(y => y.Key)));
        }

        private void ActionToAllUsers(Action<IClient> action)
        {
            foreach (var item in userlist.ToList())
            {
                try
                {
                    action.Invoke(item.Value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception for user {item.Key}: {ex.Message}");
                    userlist.Remove(item.Key);
                    SendUserlist();
                }
            }
        }
    }
}
