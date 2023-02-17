using PrinterAnalyzer.Communication.RP_F10_G10;
using PrinterAnalyzer.Core;
using PrinterAnalyzer.MVVM.Model;

namespace PrinterAnalyzer.MVVM.ViewModel
{
    internal class PrinterSettingsF10G10ViewModel : ObservableObject
    {
        #region Speed
        public RelayCommand SpeedHigh { get; set; }
        public RelayCommand SpeedMidQuality { get; set; }
        public RelayCommand SpeedMidSilence { get; set; }

        private string _speedHighColor;
        public string SpeedHighColor
        {
            get
            {
                return _speedHighColor;
            }
            set
            {
                _speedHighColor = value;
                OnPropertyChanged();
            }    
        }

        private string _speedMidQualityColor;
        public string SpeedMidQualityColor
        {
            get
            {
                return _speedMidQualityColor;
            }
            set
            {
                _speedMidQualityColor = value;
                OnPropertyChanged();
            }
        }

        private string _speedMidSilenceColor;
        public string SpeedMidSilenceColor
        {
            get
            {
                return _speedMidSilenceColor;
            }
            set
            {
                _speedMidSilenceColor = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Margin
        public RelayCommand MinMarg { get; set; }
        public RelayCommand MinTopMarg { get; set; }
        public RelayCommand MinBottomMarg { get; set; }
        public RelayCommand MaxMarg { get; set; }

        private string _minMargColor;
        public string MinMargColor
        {
            get
            {
                return _minMargColor;
            }
            set
            {
                _minMargColor = value;
                OnPropertyChanged();
            }
        }

        private string _minTopMargColor;
        public string MinTopMargColor
        {
            get
            {
                return _minTopMargColor;
            }
            set
            {
                _minTopMargColor = value;
                OnPropertyChanged();
            }
        }

        private string _minBottomMarg;
        public string MinBottomMargColor
        {
            get
            {
                return _minBottomMarg;
            }
            set
            {
                _minBottomMarg = value;
                OnPropertyChanged();
            }
        }

        private string _maxMarg;
        public string MaxMargColor
        {
            get
            {
                return _maxMarg;
            }
            set
            {
                _maxMarg = value;
                OnPropertyChanged();
            }
        }
        #endregion

        private Printer _printer;


        /// # f7941d            #5e6366

        public PrinterSettingsF10G10ViewModel(ref Printer printer)
        {
            _printer = printer;
            SpeedHigh = new RelayCommand(o => SpeedToHigh());
            SpeedMidQuality = new RelayCommand(o => SpeedToMidQuality());
            SpeedMidSilence = new RelayCommand(o => SpeedToMidSilence());
            MinMarg = new RelayCommand(o => MarginToMin());
            MinTopMarg = new RelayCommand(o => MarginToTopMin());
            MinBottomMarg = new RelayCommand(o => MarginBottomMin());
            MaxMarg = new RelayCommand(o => MarginToMax());
        }

        #region Speed Commands
        private void SpeedToHigh()
        {
            PrintersViewModel.m_DLLFuncF10G10.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_RP_F10_G10, Model.PrinterProperties.PropertyType.Speed, 0);
            ChangeSpeedButtonColor(0);
        }
        private void SpeedToMidQuality()
        {
            PrintersViewModel.m_DLLFuncF10G10.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_RP_F10_G10, Model.PrinterProperties.PropertyType.Speed, 1);
            ChangeSpeedButtonColor(1);
        }
        private void SpeedToMidSilence()
        {
            PrintersViewModel.m_DLLFuncF10G10.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_RP_F10_G10, Model.PrinterProperties.PropertyType.Speed, 3);
            ChangeSpeedButtonColor(2);
        }
        private void ChangeSpeedButtonColor(int id)
        {
            switch(id)
            {
                case 0:
                    SpeedHighColor = "#f7941d";
                    SpeedMidQualityColor = "#5e6366";
                    SpeedMidSilenceColor = "#5e6366";
                    break;
                case 1:
                    SpeedHighColor = "#5e6366";
                    SpeedMidQualityColor = "#f7941d";
                    SpeedMidSilenceColor = "#5e6366";
                    break;
                case 2:
                    SpeedHighColor = "#5e6366";
                    SpeedMidQualityColor = "#5e6366";
                    SpeedMidSilenceColor = "#f7941d";
                    break;
            }
        }
        #endregion

        #region Margin Commands
        private void MarginToMin()
        {
            PrintersViewModel.m_DLLFuncF10G10.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_RP_F10_G10, Model.PrinterProperties.PropertyType.Speed, 0);
            ChangeMarginButtonColor(0);
        }
        private void MarginToTopMin()
        {
            PrintersViewModel.m_DLLFuncF10G10.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_RP_F10_G10, Model.PrinterProperties.PropertyType.Speed, 1);
            ChangeMarginButtonColor(1);
        }
        private void MarginBottomMin()
        {
            PrintersViewModel.m_DLLFuncF10G10.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_RP_F10_G10, Model.PrinterProperties.PropertyType.Speed, 3);
            ChangeMarginButtonColor(2);
        }
        private void MarginToMax()
        {
            PrintersViewModel.m_DLLFuncF10G10.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_RP_F10_G10, Model.PrinterProperties.PropertyType.Speed, 3);
            ChangeMarginButtonColor(3);
        }
        private void ChangeMarginButtonColor(int id)
        {
            switch (id)
            {
                case 0:
                    MinMargColor = "#f7941d";
                    MinTopMargColor = "#5e6366";
                    MinBottomMargColor = "#5e6366";
                    MaxMargColor = "#5e6366";
                    break;
                case 1:
                    MinMargColor = "#5e6366";
                    MinTopMargColor = "#f7941d";
                    MinBottomMargColor = "#5e6366";
                    MaxMargColor = "#5e6366";
                    break;
                case 2:
                    MinMargColor = "#5e6366";
                    MinTopMargColor = "#5e6366";
                    MinBottomMargColor = "#f7941d";
                    MaxMargColor = "#5e6366";
                    break;
                case 3:
                    MinMargColor = "#5e6366";
                    MinTopMargColor = "#5e6366";
                    MinBottomMargColor = "#5e6366";
                    MaxMargColor = "#f7941d";
                    break;
            }
        }
        #endregion

    }
}
