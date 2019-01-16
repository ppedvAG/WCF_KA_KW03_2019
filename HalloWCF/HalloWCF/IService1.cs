using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace HalloWCF
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        int GetData();

        [OperationContract]
        void SetData(int value);

        [OperationContract]
        int Verdoppeln(int value);

        [OperationContract]
        IEnumerable<Obst> GetObst();
    }

    [DataContract]
    public class Obst
    {
        [DataMember(Order = 1)]
        public string Name { get; set; }

        [DataMember]
        public int KCal { get; set; }

        [DataMember]
        public string Farbe { get; set; }

        [DataMember]
        public DateTime HaltbarBis { get; set; }

        [DataMember]
        public decimal Preis { get; set; }
    }

}
