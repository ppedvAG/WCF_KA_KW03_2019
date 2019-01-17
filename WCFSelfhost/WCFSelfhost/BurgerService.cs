//using Contracts;
using Contracts;
using System.Collections.Generic;
using System.ServiceModel;

namespace WCFSelfhost
{
    //[ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class BurgerService : IBurgerService
    {
        List<Burger> burgerList = new List<Burger>();

        public BurgerService()
        {
            burgerList.Add(new Burger()
            {
                Name = "Hamburger",
                Preis = 4.5m
            });

            burgerList.Add(new Burger()
            {
                Name = "Cheeseburger",
                Preis = 5.5m
            });
            burgerList.Add(new Burger()
            {
                Name = "BBQ-Burger",
                Preis = 5.9m
            });
        }

        public IEnumerable<Burger> GetBurgers()
        {
            //throw new FaultException("Blöd");
            throw new FaultException<BurgerException>(new BurgerException() { BurgerCount = -5 }, "BÖÖÖÖD");
            yield return new Burger();
            //return burgerList;
        }
    }

}
