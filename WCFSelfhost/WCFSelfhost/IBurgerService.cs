using System.Collections.Generic;
using System.ServiceModel;

namespace WCFSelfhost
{
    [ServiceContract]
    public interface IBurgerService
    {
        [OperationContract]
        IEnumerable<Burger> GetBurgers();
    }

}
