using System.IO;
using System.ServiceModel;

namespace ppedv.TalkingMoose.Contracts
{
    [ServiceContract(CallbackContract = (typeof(IClient)))]
    public interface IServer
    {
        [OperationContract(IsOneWay = true)]
        void SendText(string txt);

        [OperationContract(IsOneWay = true)]
        void SendPic(Stream pic);

        [OperationContract(IsOneWay = true)]
        void SendFile(Stream file);

        [OperationContract(IsOneWay =true)]
        void Login(string name);

        [OperationContract(IsOneWay = true)]
        void Logout();
    }
}
