using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WCF_ObstRESTe
{
    [ServiceContract]
    public interface IObstService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/Obst")]
        IEnumerable<Obst> GetObst();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/Obst")]
        void AddObst(Obst o);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Obst")]
        void DeleteObst(Obst o);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Obst")]
        void UpdateObst(Obst o);
    }
}
