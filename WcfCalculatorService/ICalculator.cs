using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfCalculatorService
{
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        [FaultContract(typeof(ComputingFault))]
        double Add(double a, double b);
        [OperationContract]
        [FaultContract(typeof(ComputingFault))]
        double Substract(double a, double b);
        [OperationContract]
        [FaultContract(typeof(ComputingFault))]
        double Multiply(double a, double b);
        [OperationContract]
        [FaultContract(typeof(ComputingFault))]
        double Divide(double a, double b);
        [OperationContract]
        [FaultContract(typeof(ComputingFault))]
        double Sqrt(double a);
    }
}
