using PrinterAnalyzer.Core;

namespace PrinterAnalyzer.MVVM.ViewModel
{
    internal class PrinterCardViewModel : ObservableObject
    {
        public PrinterF10G10SettingsViewModel PFG10VM { get; set; }

        private object _currentView;
        public object CurrentSettingsView
        {
            get
            {
                return _currentView;
            }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public PrinterCardViewModel()
        {
            CurrentSettingsView = PFG10VM;
        }
    }
}
