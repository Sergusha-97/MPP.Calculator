using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfCalculatorService;

namespace WpfCalculator
{
    class ApplicationViewModel : INotifyPropertyChanged
    {
        private ICalculator _calculator;
        private ILogger _logger;
        private string _errorText;
        private double _paramA;
        private double _paramB;
        private double _result;

        public ApplicationViewModel(ICalculator calculator, ILogger logger)
        {
            if (calculator == null)
            {
                throw new ArgumentNullException(nameof(calculator));
            }
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            _calculator = calculator;
            _logger = logger;
            CommandClear = new RelayCommand(Clear, null);
            CommandAdd = new RelayCommand(Add,null);
            CommandSubstract = new RelayCommand(Substract, null);
            CommandMultiply = new RelayCommand(Multiply, null);
            CommandDivide = new RelayCommand(Divide, null);
            CommandSqrt = new RelayCommand(Sqrt, null);

        }

        public double ParamA
        {
            get { return _paramA; }
            set
            {
                _paramA = value;
                OnPropertyChanged(nameof(ParamA));
            }
        }

        public double ParamB
        {
            get { return _paramB; }
            set
            {
                _paramB = value;
                OnPropertyChanged(nameof(ParamB));
            }
        }

        public double Result
        {
            get { return _result; }
            private set
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        public string ErrorText
        {
            get { return _errorText; }
            private set
            {
                _logger.Error(value);
                _errorText += $"\n Fault: {value}";
                OnPropertyChanged(nameof(ErrorText));
            }
        }
        public RelayCommand CommandAdd { get; set; }
        public RelayCommand CommandSubstract { get; set; }
        public RelayCommand CommandMultiply { get; set; }
        public RelayCommand CommandDivide { get; set; }
        public RelayCommand CommandSqrt { get; set; }
        public RelayCommand CommandClear { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string prop)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(prop));
        }

        private void Clear(object obj)
        {
            Result = 0;
            ParamA = 0;
            ParamB = 0;
        }

        private void Add(object obj)
        {
            try
            {
                Result = _calculator.Add(_paramA, _paramB);
            }
            catch (FaultException<ComputingFault> e)
            {
                ErrorText = e.Detail.ComputingError;
            }
        }
        private void Substract(object obj)
        {
            try
            {
                Result = _calculator.Substract(_paramA, _paramB);
            }
            catch (FaultException<ComputingFault> e)
            {
                ErrorText = e.Detail.ComputingError;
            }
        }
        private void Multiply(object obj)
        {
            try
            {
                Result = _calculator.Multiply(_paramA, _paramB);
            }
            catch (FaultException<ComputingFault> e)
            {
                ErrorText = e.Detail.ComputingError;
            }
        }
        private void Divide(object obj)
        {
            try
            {
                Result = _calculator.Divide(_paramA, _paramB);
            }
            catch (FaultException<ComputingFault> e)
            {
                ErrorText = e.Detail.ComputingError;
            }
        }
        private void Sqrt(object obj)
        {
            try
            {
                Result = _calculator.Sqrt(_paramA);
            }
            catch (FaultException<ComputingFault> e)
            {
                ErrorText = e.Detail.ComputingError;
            }
        }

    }
}
