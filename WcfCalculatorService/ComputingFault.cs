using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfCalculatorService
{
    [DataContract]
    public class ComputingFault
    {
        [DataMember]
        public string ComputingError { get; private set; }

        public ComputingFault()
        {
            
        }

        public ComputingFault(string error)
        {
            ComputingError = error;
        }
    }
}