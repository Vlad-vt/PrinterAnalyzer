using PrinterAnalyzer.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PrinterAnalyzer.MVVM.Model
{
    public class Printer : ObservableObject
    {
        public string MachineName { get; set; }

        public string Name { get; set; }

        private Dictionary<string, string> _errors;
        public Dictionary<string, string> Errors
        {
            get
            {
                return _errors;
            }
            set
            {
                _errors = value;
                for(int i = 0; i < _errors.Count; i++)
                {
                    try
                    {
                        VoltageError = _errors.GetValueOrDefault("* Voltage error : ");
                    }
                    catch
                    {

                    }
                }
            }
        }

        private string _workingStatus;
        public string WorkingStatus
        {
            get
            {
                return _workingStatus;
            }
            set
            {
                _workingStatus = value;
                OnPropertyChanged();
            }
        }

        private string _workingIcon;

        [JsonIgnore]
        public string WorkingIcon
        {
            get
            {
                return _workingIcon;
            }
            set
            {
                _workingIcon = value;
                OnPropertyChanged();
            }
        }

        private string _voltageError;

        public string VoltageError
        {
            get { return _voltageError; }
            set { _voltageError = value; OnPropertyChanged(); }
        }


        public Printer()
        {
            MachineName = Environment.MachineName;
        }

        public Printer(string name)
        {
            MachineName = Environment.MachineName;
            Name = name;
        }
    }
}
