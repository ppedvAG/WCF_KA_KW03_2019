using System;

namespace WCF_ObstRESTe
{
    public class Obst
    {
        public string Name { get; set; }

        public int KCal { get; set; }

        public string Farbe { get; set; }

        public DateTime HaltbarBis { get; set; }

        public decimal Preis { get; set; }
    }
}
