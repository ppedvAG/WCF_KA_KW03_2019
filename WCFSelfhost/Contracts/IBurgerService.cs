//using Contracts;
using Contracts;
using System.Collections.Generic;
using System.ServiceModel;

namespace WCFSelfhost
{
    [ServiceContract]
    public interface IBurgerService
    {
        [OperationContract]
        [FaultContract(typeof(BurgerException))]
        IEnumerable<Burger> GetBurgers();
    }

}
