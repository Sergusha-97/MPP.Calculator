using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfCalculatorService
{
    public class Calculator : ICalculator
    {
        public double Add(double a, double b)
        {
            try
            {
                double result = a + b;
                return result;
            }
            catch (Exception e)
            {
                throw new FaultException<ComputingFault>(new ComputingFault(e.Message));
            }
        }

        public double Substract(double a, double b)
        {
            try
            {
                double result = a - b;
                return result;
            }
            catch (Exception e)
            {
                throw new FaultException<ComputingFault>(new ComputingFault(e.Message));
            }
        }

        public double Multiply(double a, double b)
        {
            try
            {
                double result = a * b;
                return result;
            }
            catch (Exception e)
            {
                throw new FaultException<ComputingFault>(new ComputingFault(e.Message));
            }
        }

        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new FaultException<ComputingFault>(new ComputingFault("Division by zero"));
            }
            try
            {
                double result = a / b;
                return result;
            }
            catch (Exception e)
            {
                throw new FaultException<ComputingFault>(new ComputingFault(e.Message));
            }
        }

        public double Sqrt(double a)
        {
            if (a < 0)
            {
                throw new FaultException<ComputingFault>(new ComputingFault("Argument is negative"));
            }
            try
            {
                double result = Math.Sqrt(a);
                return result;
            }
            catch (Exception e)
            {
                throw new FaultException<ComputingFault>(new ComputingFault(e.Message));
            }
        }
    }
}
