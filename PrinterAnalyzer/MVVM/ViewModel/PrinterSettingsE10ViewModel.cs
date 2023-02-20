using PrinterAnalyzer.Core;
using PrinterAnalyzer.MVVM.Model.PrinterProperties;
using PrinterAnalyzer.MVVM.Model;
using System.Collections.Generic;
using System.Threading;
using System.Windows;

namespace PrinterAnalyzer.MVVM.ViewModel
{
    internal class PrinterSettingsE10ViewModel : ObservableObject
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

        public PrinterSettingsE10ViewModel(ref Printer printer)
        {
            _printer = printer;
            SpeedHigh = new RelayCommand(o => SpeedToHigh());
            SpeedMidQuality = new RelayCommand(o => SpeedToMidQuality());
            SpeedMidSilence = new RelayCommand(o => SpeedToMidSilence());
            MinMarg = new RelayCommand(o => MarginToMin());
            MinTopMarg = new RelayCommand(o => MarginToTopMin());
            MinBottomMarg = new RelayCommand(o => MarginBottomMin());
            MaxMarg = new RelayCommand(o => MarginToMax());
            DirectionForwardCommand = new RelayCommand(o => DirectionForward());
            DirectionBackwardCommand = new RelayCommand(o => DirectionBackward());
            OrientationLandscapeCommand = new RelayCommand(o => SetOrientationLandscape());
            OrientationLandscapeCommand = new RelayCommand(o => SetOrientationPortrait());
            CutFullCutByPage = new RelayCommand(o => SetFullCutByPage());
            CutFullCutByJob = new RelayCommand(o => SetFullCutByJob());
            CutPartialCutByJobs = new RelayCommand(o => SetPartialCutByJobs());
            CutPartialCutByPage = new RelayCommand(o => SetPartialCutByPage());
            CutPartialCutBetweenPages = new RelayCommand(o => SetPartialCutBetweenPages());
            SpeedHighColor = "#f7941d";
            SpeedMidQualityColor = "#5e6366";
            SpeedMidSilenceColor = "#5e6366";
            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    GetChanges();
                    Thread.Sleep(2000);
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }

        private void GetChanges()
        {
            try
            {
                switch ((_printer.properties as Properties_RP_F10_G10).CurrentProperties.GetValueOrDefault(PropertyType.Speed))
                {
                    case 0:
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            SpeedHighColor = "#f7941d";
                            SpeedMidQualityColor = "#5e6366";
                            SpeedMidSilenceColor = "#5e6366";
                        });
                        break;
                    case 1:
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            SpeedHighColor = "#5e6366";
                            SpeedMidQualityColor = "#f7941d";
                            SpeedMidSilenceColor = "#5e6366";
                        });
                        break;
                    case 3:
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            SpeedHighColor = "#5e6366";
                            SpeedMidQualityColor = "#5e6366";
                            SpeedMidSilenceColor = "#f7941d";
                        });
                        break;
                }
                switch ((_printer.properties as Properties_RP_F10_G10).CurrentProperties.GetValueOrDefault(PropertyType.Direction))
                {
                    case 0:
                        App.Current.Dispatcher.Invoke(() =>
                        {
                            DirectionForwardColor = "#f7941d";
                            DirectionBackwardColor = "#5e6366";
                        });
                        break;
                    case 1:
                        App.Current.Dispatcher.Invoke(() =>
                        {
                            DirectionForwardColor = "#5e6366";
                            DirectionBackwardColor = "#f7941d";
                        });
                        break;
                    case 3:
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            DirectionForwardColor = "#5e6366";
                            DirectionBackwardColor = "#f7941d";
                        });
                        break;
                }
                switch ((_printer.properties as Properties_RP_F10_G10).CurrentProperties.GetValueOrDefault(PropertyType.Margin))
                {
                    case 0:
                        {
                            MinMargColor = "#f7941d";
                            MinTopMargColor = "#5e6366";
                            MinBottomMargColor = "#5e6366";
                            MaxMargColor = "#5e6366";
                            break;
                        }
                    case 1:
                        {
                            MinMargColor = "#5e6366";
                            MinTopMargColor = "#f7941d";
                            MinBottomMargColor = "#5e6366";
                            MaxMargColor = "#5e6366";
                            break;
                        }
                    case 2:
                        {
                            MinMargColor = "#5e6366";
                            MinTopMargColor = "#5e6366";
                            MinBottomMargColor = "#f7941d";
                            MaxMargColor = "#5e6366";
                            break;
                        }
                    case 3:
                        {
                            MinMargColor = "#5e6366";
                            MinTopMargColor = "#5e6366";
                            MinBottomMargColor = "#5e6366";
                            MaxMargColor = "#f7941d";
                            break;
                        }
                }
                switch ((_printer.properties as Properties_RP_F10_G10).CurrentProperties.GetValueOrDefault(PropertyType.FeedToCutPosition))
                {
                    case 0:
                        {
                            FeedEnabledColor = "#f7941d";
                            FeedDisabledColor = "#5e6366";
                            break;
                        }
                    case 1:
                        {
                            FeedEnabledColor = "#5e6366";
                            FeedDisabledColor = "#f7941d";
                            break;
                        }
                    case 3:
                        {
                            FeedEnabledColor = "#5e6366";
                            FeedDisabledColor = "#f7941d";
                            break;
                        }
                }
                switch ((_printer.properties as Properties_RP_F10_G10).CurrentProperties.GetValueOrDefault(PropertyType.PaperCut))
                {
                    case 0:
                        {
                            CutNoCutColor = "#f7941d";
                            CutFullCutByJobColor = "#5e6366";
                            CutPartialCutByJobsColor = "#5e6366";
                            CutFullCutByPageColor = "#5e6366";
                            CutPartialCutByPageColor = "#5e6366";
                            CutPartialCutBetweenPagesColor = "#5e6366";
                            break;
                        }
                    case 1:
                        {
                            CutNoCutColor = "#5e6366";
                            CutFullCutByJobColor = "#f7941d";
                            CutPartialCutByJobsColor = "#5e6366";
                            CutFullCutByPageColor = "#5e6366";
                            CutPartialCutByPageColor = "#5e6366";
                            CutPartialCutBetweenPagesColor = "#5e6366";
                            break;
                        }
                    case 2:
                        {
                            CutNoCutColor = "#5e6366";
                            CutFullCutByJobColor = "#5e6366";
                            CutPartialCutByJobsColor = "#f7941d";
                            CutFullCutByPageColor = "#5e6366";
                            CutPartialCutByPageColor = "#5e6366";
                            CutPartialCutBetweenPagesColor = "#5e6366";
                            break;
                        }
                    case 3:
                        {
                            CutNoCutColor = "#5e6366";
                            CutFullCutByJobColor = "#5e6366";
                            CutPartialCutByJobsColor = "#5e6366";
                            CutFullCutByPageColor = "#f7941d";
                            CutPartialCutByPageColor = "#5e6366";
                            CutPartialCutBetweenPagesColor = "#5e6366";
                            break;
                        }
                    case 4:
                        {
                            CutNoCutColor = "#5e6366";
                            CutFullCutByJobColor = "#5e6366";
                            CutPartialCutByJobsColor = "#5e6366";
                            CutFullCutByPageColor = "#5e6366";
                            CutPartialCutByPageColor = "#f7941d";
                            CutPartialCutBetweenPagesColor = "#5e6366";
                            break;
                        }
                    case 5:
                        {
                            CutNoCutColor = "#5e6366";
                            CutFullCutByJobColor = "#5e6366";
                            CutPartialCutByJobsColor = "#5e6366";
                            CutFullCutByPageColor = "#5e6366";
                            CutPartialCutByPageColor = "#5e6366";
                            CutPartialCutBetweenPagesColor = "#f7941d";
                            break;
                        }
                }
            }
            catch { }
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
            switch (id)
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
            PrintersViewModel.m_DLLFuncF10G10.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_RP_F10_G10, Model.PrinterProperties.PropertyType.Margin, 0);
            ChangeMarginButtonColor(0);
        }
        private void MarginToTopMin()
        {
            PrintersViewModel.m_DLLFuncF10G10.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_RP_F10_G10, Model.PrinterProperties.PropertyType.Margin, 1);
            ChangeMarginButtonColor(1);
        }
        private void MarginBottomMin()
        {
            PrintersViewModel.m_DLLFuncF10G10.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_RP_F10_G10, Model.PrinterProperties.PropertyType.Margin, 2);
            ChangeMarginButtonColor(2);
        }
        private void MarginToMax()
        {
            PrintersViewModel.m_DLLFuncF10G10.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_RP_F10_G10, Model.PrinterProperties.PropertyType.Margin, 3);
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

        #region DirectionCommands
        private void DirectionForward()
        {
            PrintersViewModel.m_DLLFuncF10G10.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_RP_F10_G10, Model.PrinterProperties.PropertyType.Direction, 0);
            ChangeDirectionButtonColor(0);
        }
        private void DirectionBackward()
        {
            PrintersViewModel.m_DLLFuncF10G10.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_RP_F10_G10, Model.PrinterProperties.PropertyType.Direction, 1);
            ChangeDirectionButtonColor(1);
        }
        private void ChangeDirectionButtonColor(int id)
        {
            switch (id)
            {
                case 0:
                    DirectionForwardColor = "#f7941d";
                    DirectionBackwardColor = "#5e6366";
                    break;
                case 1:
                    DirectionForwardColor = "#5e6366";
                    DirectionBackwardColor = "#f7941d";
                    break;
            }
        }
        #endregion

        #region OrientationCommands
        private void SetOrientationPortrait()
        {
            PrintersViewModel.m_DLLFuncF10G10.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_RP_F10_G10, Model.PrinterProperties.PropertyType.Orientation, 0);
            ChangeOrientationButtonColor(0);
        }

        private void SetOrientationLandscape()
        {
            PrintersViewModel.m_DLLFuncF10G10.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_RP_F10_G10, Model.PrinterProperties.PropertyType.Orientation, 1);
            ChangeOrientationButtonColor(1);
        }

        private void ChangeOrientationButtonColor(int id)
        {
            switch (id)
            {
                case 0:
                    OrientationPortraitColor = "#f7941d";
                    OrientationLandscapeColor = "#5e6366";
                    break;
                case 1:
                    OrientationPortraitColor = "#5e6366";
                    OrientationLandscapeColor = "#f7941d";
                    break;
            }
        }
        #endregion

        #region FeedPosition Commands
        private void EnableFeed()
        {
            PrintersViewModel.m_DLLFuncF10G10.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_RP_F10_G10, Model.PrinterProperties.PropertyType.FeedToCutPosition, 0);
            ChangeFeedButtonColor(0);
        }
        private void DisableFeed()
        {
            PrintersViewModel.m_DLLFuncF10G10.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_RP_F10_G10, Model.PrinterProperties.PropertyType.FeedToCutPosition, 1);
            ChangeFeedButtonColor(1);
        }
        private void ChangeFeedButtonColor(int id)
        {
            switch (id)
            {
                case 0:
                    FeedEnabledColor = "#f7941d";
                    FeedDisabledColor = "#5e6366";
                    break;
                case 1:
                    FeedEnabledColor = "#5e6366";
                    FeedDisabledColor = "#f7941d";
                    break;
            }
        }
        #endregion

        #region PaperCut
        private void SetCutNoCut()
        {
            PrintersViewModel.m_DLLFuncF10G10.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_RP_F10_G10, Model.PrinterProperties.PropertyType.PaperCut, 0);
            ChangeCutButtonColor(0);
        }

        private void SetFullCutByJob()
        {
            PrintersViewModel.m_DLLFuncF10G10.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_RP_F10_G10, Model.PrinterProperties.PropertyType.PaperCut, 1);
            ChangeCutButtonColor(1);
        }

        private void SetPartialCutByJobs()
        {
            PrintersViewModel.m_DLLFuncF10G10.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_RP_F10_G10, Model.PrinterProperties.PropertyType.PaperCut, 2);
            ChangeCutButtonColor(2);
        }

        private void SetFullCutByPage()
        {
            PrintersViewModel.m_DLLFuncF10G10.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_RP_F10_G10, Model.PrinterProperties.PropertyType.PaperCut, 3);
            ChangeCutButtonColor(3);
        }

        private void SetPartialCutByPage()
        {
            PrintersViewModel.m_DLLFuncF10G10.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_RP_F10_G10, Model.PrinterProperties.PropertyType.PaperCut, 4);
            ChangeCutButtonColor(4);
        }

        private void SetPartialCutBetweenPages()
        {
            PrintersViewModel.m_DLLFuncF10G10.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_RP_F10_G10, Model.PrinterProperties.PropertyType.PaperCut, 5);
            ChangeCutButtonColor(5);
        }

        private void ChangeCutButtonColor(int id)
        {
            switch (id)
            {
                case 0:
                    CutNoCutColor = "#f7941d";
                    CutFullCutByJobColor = "#5e6366";
                    CutPartialCutByJobsColor = "#5e6366";
                    CutFullCutByPageColor = "#5e6366";
                    CutPartialCutByPageColor = "#5e6366";
                    CutPartialCutBetweenPagesColor = "#5e6366";
                    break;
                case 1:
                    CutNoCutColor = "#5e6366";
                    CutFullCutByJobColor = "#f7941d";
                    CutPartialCutByJobsColor = "#5e6366";
                    CutFullCutByPageColor = "#5e6366";
                    CutPartialCutByPageColor = "#5e6366";
                    CutPartialCutBetweenPagesColor = "#5e6366";
                    break;
                case 2:
                    CutNoCutColor = "#5e6366";
                    CutFullCutByJobColor = "#5e6366";
                    CutPartialCutByJobsColor = "#f7941d";
                    CutFullCutByPageColor = "#5e6366";
                    CutPartialCutByPageColor = "#5e6366";
                    CutPartialCutBetweenPagesColor = "#5e6366";
                    break;
                case 3:
                    CutNoCutColor = "#5e6366";
                    CutFullCutByJobColor = "#5e6366";
                    CutPartialCutByJobsColor = "#5e6366";
                    CutFullCutByPageColor = "#f7941d";
                    CutPartialCutByPageColor = "#5e6366";
                    CutPartialCutBetweenPagesColor = "#5e6366";
                    break;
                case 4:
                    CutNoCutColor = "#5e6366";
                    CutFullCutByJobColor = "#5e6366";
                    CutPartialCutByJobsColor = "#5e6366";
                    CutFullCutByPageColor = "#5e6366";
                    CutPartialCutByPageColor = "#f7941d";
                    CutPartialCutBetweenPagesColor = "#5e6366";
                    break;
                case 5:
                    CutNoCutColor = "#5e6366";
                    CutFullCutByJobColor = "#5e6366";
                    CutPartialCutByJobsColor = "#5e6366";
                    CutFullCutByPageColor = "#5e6366";
                    CutPartialCutByPageColor = "#5e6366";
                    CutPartialCutBetweenPagesColor = "#f7941d";
                    break;

            }
        }
        #endregion
    }
}
