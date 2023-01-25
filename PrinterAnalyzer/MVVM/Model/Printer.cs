using PrinterAnalyzer.Core;
using Newtonsoft.Json;
using System;

namespace PrinterAnalyzer.MVVM.Model
{
    public class Printer : ObservableObject
    {
        public string MachineName { get; set; }

        public string Name { get; set; }

        public string Errors { get; set; }

        private string _isOnline;
        public string IsOnline
        {
            get
            {
                return _isOnline;
            }
            set
            {
                _isOnline = value;
                OnPropertyChanged();
            }
        }

        private string _workingColor;

        [JsonIgnore]
        public string WorkingColor
        {
            get
            {
                return _workingColor;
            }
            set
            {
                _workingColor = value;
                OnPropertyChanged();
            }
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
