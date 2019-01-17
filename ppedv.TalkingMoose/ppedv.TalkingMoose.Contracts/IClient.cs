using System.Collections.Generic;
using System.IO;
using System.ServiceModel;

namespace ppedv.TalkingMoose.Contracts
{
    [ServiceContract]
    public interface IClient
    {
        [OperationContract(IsOneWay = true)]
        void ShowText(string txt);

        [OperationContract(IsOneWay = true)]
        void ShowPic(Stream pic);

        [OperationContract(IsOneWay = true)]
        void ShowFile(Stream file);

        [OperationContract(IsOneWay = true)]
        void ShowUserlist(IEnumerable<string> users);

        [OperationContract(IsOneWay = true)]
        void LoginOk();

        [OperationContract(IsOneWay = true)]
        void LoginFailed(string txt);
    }
}
