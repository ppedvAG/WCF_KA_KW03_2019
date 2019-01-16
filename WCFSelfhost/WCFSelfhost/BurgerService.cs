using System.Collections.Generic;
using System.ServiceModel;

namespace WCFSelfhost
{
    public class BurgerService : IBurgerService
    {
        public IEnumerable<Burger> GetBurgers()
        {
            yield return new Burger()
            {
                Name = "Hamburger",
                Preis = 4.5m
            };
            yield return new Burger()
            {
                Name = "Cheeseburger",
                Preis = 5.5m
            };
            yield return new Burger()
            {
                Name = "BBQ-Burger",
                Preis = 5.9m
            };
        }
    }

}
