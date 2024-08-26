using PrinterAnalyzer.Core;
using PrinterAnalyzer.MVVM.Model;

namespace PrinterAnalyzer.MVVM.ViewModel
{
    internal class PrinterSettingsB30LViewModel : ObservableObject
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

        #region Direction
        public RelayCommand DirectionForwardCommand { get; set; }
        public RelayCommand DirectionBackwardCommand { get; set; }

        private string _directionForwardColor;
        public string DirectionForwardColor
        {
            get
            {
                return _directionForwardColor;
            }
            set
            {
                _directionForwardColor = value;
                OnPropertyChanged();
            }
        }

        private string _directionBackwardColor;
        public string DirectionBackwardColor
        {
            get
            {
                return _directionBackwardColor;
            }
            set
            {
                _directionBackwardColor = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Orientation
        public RelayCommand OrientationPortraitCommand { get; set; }
        public RelayCommand OrientationLandscapeCommand { get; set; }

        private string _orientationPortraitColor;
        public string OrientationPortraitColor
        {
            get
            {
                return _orientationPortraitColor;
            }
            set
            {
                _orientationPortraitColor = value;
                OnPropertyChanged();
            }
        }

        private string _orientationLandscapeColor;
        public string OrientationLandscapeColor
        {
            get
            {
                return _orientationLandscapeColor;
            }
            set
            {
                _orientationLandscapeColor = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Watermark
        public RelayCommand WatermarkNoneCommand { get; set; }
        public RelayCommand WatermarkCenterCommand { get; set; }
        public RelayCommand WatermarkLeftCommand { get; set; }
        public RelayCommand WatermarkUpperLeftCommand { get; set; }
        public RelayCommand WatermarkTopCenterCommand { get; set; }
        public RelayCommand WatermarkUpperRightCommand { get; set; }
        public RelayCommand WatermarkRightCommand { get; set; }
        public RelayCommand WatermarkLowerLeftCommand { get; set; }
        public RelayCommand WatermarkBottomCenterCommand { get; set; }
        public RelayCommand WatermarkLowerRightCommand { get; set; }

        private string _watermarkNoneColor;
        public string WatermarkNoneColor
        {
            get
            {
                return _watermarkNoneColor;
            }
            set
            {
                _watermarkNoneColor = value;
                OnPropertyChanged();
            }
        }

        private string _watermarkCenterColor;
        public string WatermarkCenterColor
        {
            get
            {
                return _watermarkCenterColor;
            }
            set
            {
                _watermarkCenterColor = value;
                OnPropertyChanged();
            }
        }

        private string _watermarkLeftColor;
        public string WatermarkLeftColor
        {
            get
            {
                return _watermarkLeftColor;
            }
            set
            {
                _watermarkLeftColor = value;
                OnPropertyChanged();
            }
        }

        private string _watermarkUpperLeftColor;
        public string WatermarkUpperLeftColor
        {
            get
            {
                return _watermarkUpperLeftColor;
            }
            set
            {
                _watermarkUpperLeftColor = value;
                OnPropertyChanged();
            }
        }

        private string _watermarkTopCenterColor;
        public string WatermarkTopCenterColor
        {
            get
            {
                return _watermarkTopCenterColor;
            }
            set
            {
                _watermarkTopCenterColor = value;
                OnPropertyChanged();
            }
        }

        private string _watermarkUpperRightColor;
        public string WatermarkUpperRightColor
        {
            get
            {
                return _watermarkUpperRightColor;
            }
            set
            {
                _watermarkUpperRightColor = value;
                OnPropertyChanged();
            }
        }

        private string _watermarkRightColor;
        public string WatermarkRightColor
        {
            get
            {
                return _watermarkRightColor;
            }
            set
            {
                _watermarkRightColor = value;
                OnPropertyChanged();
            }
        }

        private string _watermarkLowerLeftColor;
        public string WatermarkLowerLeftColor
        {
            get
            {
                return _watermarkLowerLeftColor;
            }
            set
            {
                _watermarkLowerLeftColor = value;
                OnPropertyChanged();
            }
        }

        private string _watermarkBottomCenterColor;
        public string WatermarkBottomCenterColor
        {
            get
            {
                return _watermarkBottomCenterColor;
            }
            set
            {
                _watermarkBottomCenterColor = value;
                OnPropertyChanged();
            }
        }

        private string _watermarkLowerRightColor;
        public string WatermarkLowerRightColor
        {
            get
            {
                return _watermarkLowerRightColor;
            }
            set
            {
                _watermarkLowerRightColor = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region PaperCut
        public RelayCommand CutNoCut { get; set; }
        public RelayCommand CutFullCutByJob { get; set; }
        public RelayCommand CutPartialCutByJobs { get; set; }
        public RelayCommand CutFullCutByPage { get; set; }
        public RelayCommand CutPartialCutByPage { get; set; }
        public RelayCommand CutPartialCutBetweenPages { get; set; }

        private string _cutNoCutColor;
        public string CutNoCutColor
        {
            get
            {
                return _cutNoCutColor;
            }
            set
            {
                _cutNoCutColor = value;
                OnPropertyChanged();
            }
        }

        private string _cutFullCutByJobColor;
        public string CutFullCutByJobColor
        {
            get
            {
                return _cutFullCutByJobColor;
            }
            set
            {
                _cutFullCutByJobColor = value;
                OnPropertyChanged();
            }
        }

        private string _cutPartialCutByJobsColor;
        public string CutPartialCutByJobsColor
        {
            get
            {
                return _cutPartialCutByJobsColor;
            }
            set
            {
                _cutPartialCutByJobsColor = value;
                OnPropertyChanged();
            }
        }

        private string _cutFullCutByPageColor;
        public string CutFullCutByPageColor
        {
            get
            {
                return _cutFullCutByPageColor;
            }
            set
            {
                _cutFullCutByPageColor = value;
                OnPropertyChanged();
            }
        }

        private string _cutPartialCutByPageColor;
        public string CutPartialCutByPageColor
        {
            get
            {
                return _cutPartialCutByPageColor;
            }
            set
            {
                _cutPartialCutByPageColor = value;
                OnPropertyChanged();
            }
        }

        private string _cutPartialCutBetweenPagesColor;
        public string CutPartialCutBetweenPagesColor
        {
            get
            {
                return _cutPartialCutBetweenPagesColor;
            }
            set
            {
                _cutPartialCutBetweenPagesColor = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region FeedPosition
        public RelayCommand FeedEnabled { get; set; }
        public RelayCommand FeedDisabled { get; set; }

        private string _feedEnabled;
        public string FeedEnabledColor
        {
            get
            {
                return _feedEnabled;
            }
            set
            {
                _feedEnabled = value;
                OnPropertyChanged();
            }
        }

        private string _feedDisabled;
        public string FeedDisabledColor
        {
            get
            {
                return _feedDisabled;
            }
            set
            {
                _feedDisabled = value;
                OnPropertyChanged();
            }
        }
        #endregion

        private Printer _printer;
    }
}
