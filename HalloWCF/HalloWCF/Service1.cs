using System;
using System.Collections.Generic;

namespace HalloWCF
{
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public IEnumerable<Obst> GetObst()
        {
            yield return new Obst()
            {
                Name = "Apfel",
                Farbe = "Rot",
                KCal = 80,
                Preis = 0.3m,
                HaltbarBis = DateTime.Now.AddDays(30)
            };

            yield return new Obst()
            {
                Name = "Banane",
                Farbe = "Gelb",
                KCal = 95,
                Preis = 0.2m,
                HaltbarBis = DateTime.Now.AddDays(5)
            };

            yield return new Obst()
            {
                Name = "Birne",
                Farbe = "Grün",
                KCal = 55,
                Preis = 0.25m,
                HaltbarBis = DateTime.Now.AddDays(15)
            };
        }

        public int Verdoppeln(int value)
        {
            return value * 2;
        }
    }
}
