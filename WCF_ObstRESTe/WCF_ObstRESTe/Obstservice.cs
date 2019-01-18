using System;
using System.Collections.Generic;
using System.Linq;

namespace WCF_ObstRESTe
{
    public class Obstservice : IObstService
    {
        static List<Obst> db = new List<Obst>();
        static Obstservice()
        {
            db.Add(new Obst()
            {
                Name = "Apfel",
                Farbe = "Rot",
                KCal = 80,
                Preis = 0.3m,
                HaltbarBis = DateTime.Now.AddDays(30)
            });

            db.Add(new Obst()
            {
                Name = "Banane",
                Farbe = "Gelb",
                KCal = 95,
                Preis = 0.2m,
                HaltbarBis = DateTime.Now.AddDays(5)
            });

            db.Add(new Obst()
            {
                Name = "Birne",
                Farbe = "Grün",
                KCal = 55,
                Preis = 0.25m,
                HaltbarBis = DateTime.Now.AddDays(15)
            });
        }
        public void AddObst(Obst o)
        {
            db.Add(o);
        }

        public void DeleteObst(Obst o)
        {
            //db.Remove(o);
            db.Remove(db.First(x => x.Name == o.Name));
        }

        public IEnumerable<Obst> GetObst()
        {
            return db;
        }

        public void UpdateObst(Obst o)
        {
            DeleteObst(o);
            AddObst(o);
        }
    }
}
