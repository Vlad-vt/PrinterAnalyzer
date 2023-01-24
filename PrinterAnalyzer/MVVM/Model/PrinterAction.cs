namespace PrinterAnalyzer.MVVM.Model
{
    internal class PrinterAction
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                if (_name.Length > 23)
                {
                    _name = _name.Substring(0, 23);
                    _name += "...";
                }
            }
        }

        public string Date { get; set; }

        public string DeviceType { get; set; }

        public PrinterAction()
        {

        }

        public PrinterAction(string name, string date, string deviceType)
        {
            Name = name;
            Date = date;
            DeviceType = deviceType;
        }
    }
}
