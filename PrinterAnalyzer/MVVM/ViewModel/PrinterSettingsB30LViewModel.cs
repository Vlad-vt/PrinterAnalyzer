using PrinterAnalyzer.Core;
using PrinterAnalyzer.MVVM.Model;
using PrinterAnalyzer.MVVM.Model.PrinterProperties;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace PrinterAnalyzer.MVVM.ViewModel
{
    internal class PrinterSettingsB30LViewModel : ObservableObject
    {
        #region Speed
        public RelayCommand SpeedStandard { get; set; }
        public RelayCommand SpeedQuality1 { get; set; }
        public RelayCommand SpeedQuality2 { get; set; }

        private string _speedStandardColor;
        public string SpeedStandardColor
        {
            get
            {
                return _speedStandardColor;
            }
            set
            {
                _speedStandardColor = value;
                OnPropertyChanged();
            }
        }

        private string _speedQuality1Color;
        public string SpeedQuality1Color
        {
            get
            {
                return _speedQuality1Color;
            }
            set
            {
                _speedQuality1Color = value;
                OnPropertyChanged();
            }
        }

        private string _speedQuality2Color;
        public string SpeedQuality2Color
        {
            get
            {
                return _speedQuality2Color;
            }
            set
            {
                _speedQuality2Color = value;
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

        #region Preset
        public RelayCommand MM58PresCommand { get; set; }
        public RelayCommand MM58GapFormPresCommand { get; set; }
        public RelayCommand MM58GapFormLabelPresCommand { get; set; }
        public RelayCommand A458PresCommand { get; set; }
        public RelayCommand MM76ReseiptPresCommand { get; set; }
        public RelayCommand MM76GapFormPresCommand { get; set; }
        public RelayCommand MM76GapFormLabelPresCommand { get; set; }
        public RelayCommand A476PresCommand { get; set; }
        public RelayCommand MM80ReseiptPresCommand { get; set; }
        public RelayCommand MM80GapFormPresCommand { get; set; }
        public RelayCommand MM80GapFormLabelPresCommand { get; set; }
        public RelayCommand A480PresCommand { get; set; }
        public RelayCommand UserSettingPresCommand { get; set; }

        private string _MM58PresColor;
        public string MM58PresColor
        {
            get
            {
                return _MM58PresColor;
            }
            set
            {
                _MM58PresColor = value;
                OnPropertyChanged();
            }
        }

        private string _MM58GapFormPresColor;
        public string MM58GapFormPresColor
        {
            get
            {
                return _MM58GapFormPresColor;
            }
            set
            {
                _MM58GapFormPresColor = value;
                OnPropertyChanged();
            }
        }

        private string _MM58GapFormLabelPresColor;
        public string MM58GapFormLabelPresColor
        {
            get
            {
                return _MM58GapFormLabelPresColor;
            }
            set
            {
                _MM58GapFormLabelPresColor = value;
                OnPropertyChanged();
            }
        }

        private string _A458PresColor;
        public string A458PresColor
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

        private string _MM76ReseiptPresColor;
        public string MM76ReseiptPresColor
        {
            get
            {
                return _MM76ReseiptPresColor;
            }
            set
            {
                _MM76ReseiptPresColor = value;
                OnPropertyChanged();
            }
        }

        private string _MM76GapFormPresColor;
        public string MM76GapFormPresColor
        {
            get
            {
                return _MM76GapFormPresColor;
            }
            set
            {
                _MM76GapFormPresColor = value;
                OnPropertyChanged();
            }
        }

        private string _MM76GapFormLabelPresColor;
        public string MM76GapFormLabelPresColor
        {
            get
            {
                return _MM76GapFormLabelPresColor;
            }
            set
            {
                _MM76GapFormLabelPresColor = value;
                OnPropertyChanged();
            }
        }

        private string _A476PresColor;
        public string A476PresColor
        {
            get
            {
                return _A476PresColor;
            }
            set
            {
                _A476PresColor = value;
                OnPropertyChanged();
            }
        }

        private string _MM80ReseiptPresColor;
        public string MM80ReseiptPresColor
        {
            get
            {
                return _MM80ReseiptPresColor;
            }
            set
            {
                _MM80ReseiptPresColor = value;
                OnPropertyChanged();
            }
        }

        private string _MM80GapFormPresColor;
        public string MM80GapFormPresColor
        {
            get
            {
                return _MM80GapFormPresColor;
            }
            set
            {
                _MM80GapFormPresColor = value;
                OnPropertyChanged();
            }
        }

        private string _MM80GapFormLabelPresColor;
        public string MM80GapFormLabelPresColor
        {
            get
            {
                return _MM80GapFormLabelPresColor;
            }
            set
            {
                _MM80GapFormLabelPresColor = value;
                OnPropertyChanged();
            }
        }

        private string _A480PresColor;
        public string A480PresColor
        {
            get
            {
                return _A480PresColor;
            }
            set
            {
                _A480PresColor = value;
                OnPropertyChanged();
            }
        }

        private string _UserSettingPresColor;
        public string UserSettingPresColor
        {
            get
            {
                return _UserSettingPresColor;
            }
            set
            {
                _UserSettingPresColor = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Marked paper form feed
        public RelayCommand NoFormFeed { get; set; }
        public RelayCommand ByPages { get; set; }
        public RelayCommand ByJob { get; set; }

        private string _noFormFeedColor;
        public string NoFormFeedColor
        {
            get
            {
                return _noFormFeedColor;
            }
            set
            {
                _noFormFeedColor = value;
                OnPropertyChanged();
            }
        }

        private string _byPagesColor;
        public string ByPagesColor
        {
            get
            {
                return _byPagesColor;
            }
            set
            {
                _byPagesColor = value;
                OnPropertyChanged();
            }
        }

        private string _byJobColor;
        public string ByJobColor
        {
            get
            {
                return _byJobColor;
            }
            set
            {
                _byJobColor = value;
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

        public PrinterSettingsB30LViewModel(ref Printer printer)
        {
            _printer = printer;
            CommandsInit();
            Thread thread = new Thread(() =>
            {
                //while (true)
                //{
                    Thread.Sleep(3000);
                    GetChanges();
                    //Thread.Sleep(2000);
                //}
            });
            thread.IsBackground = true;
            thread.Start();
        }

        private void CommandsInit()
        {
            SpeedStandard = new RelayCommand(async o => await SpeedToStandardAsync());
            SpeedQuality1 = new RelayCommand(async o => await SpeedToQuality1Async());
            SpeedQuality2 = new RelayCommand(async o => await SpeedToQuality2Async());
            MinMarg = new RelayCommand(async o => await MarginToMinAsync());
            MinTopMarg = new RelayCommand(async o => await MarginToTopMinAsync());
            MinBottomMarg = new RelayCommand(async o => await MarginBottomMinAsync());
            MaxMarg = new RelayCommand(async o => await MarginToMaxAsync());
            DirectionForwardCommand = new RelayCommand(async o => await DirectionForwardAsync());
            DirectionBackwardCommand = new RelayCommand(async o => await DirectionBackwardAsync());
            OrientationLandscapeCommand = new RelayCommand(async o => await SetOrientationLandscapeAsync());
            OrientationPortraitCommand = new RelayCommand(async o => await SetOrientationPortraitAsync());
            FeedEnabled = new RelayCommand(async o => await EnableFeedAsync());
            FeedDisabled = new RelayCommand(async o => await DisableFeedAsync());
        }

        private void GetChanges()
        {
            try
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    switch ((_printer.properties as Properties_RP_F10_G10_B30).CurrentProperties.GetValueOrDefault(PropertyType.Speed))
                    {
                        case 0:
                            SpeedStandardColor = "#f7941d";
                            SpeedQuality1Color = "#5e6366";
                            SpeedQuality2Color = "#5e6366";
                            break;
                        case 1:
                            SpeedStandardColor = "#5e6366";
                            SpeedQuality1Color = "#f7941d";
                            SpeedQuality2Color = "#5e6366";
                            break;
                        case 2:
                            SpeedStandardColor = "#5e6366";
                            SpeedQuality1Color = "#5e6366";
                            SpeedQuality2Color = "#f7941d";
                            break;
                    }
                    switch ((_printer.properties as Properties_RP_F10_G10_B30).CurrentProperties.GetValueOrDefault(PropertyType.Direction))
                    {
                        case 0:
                            DirectionForwardColor = "#f7941d";
                            DirectionBackwardColor = "#5e6366";
                            break;
                        case 1:
                            DirectionForwardColor = "#5e6366";
                            DirectionBackwardColor = "#f7941d";
                            break;
                        case 3:
                            DirectionForwardColor = "#5e6366";
                            DirectionBackwardColor = "#f7941d";
                            break;
                    }
                    switch ((_printer.properties as Properties_RP_F10_G10_B30).CurrentProperties.GetValueOrDefault(PropertyType.Margin))
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
                    switch ((_printer.properties as Properties_RP_F10_G10_B30).CurrentProperties.GetValueOrDefault(PropertyType.FeedToCutPosition))
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
                    switch ((_printer.properties as Properties_RP_F10_G10_B30).CurrentProperties.GetValueOrDefault(PropertyType.PaperCut))
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
                });
            }
            catch { }
        }



        #region Speed Commands
        private void SpeedToStandard()
        {
            PrintersViewModel.m_DLLFuncB30L.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.Speed, 0);
            ChangeSpeedButtonColor(0);
        }

        private async Task SpeedToStandardAsync()
        {
            await PrintersViewModel.m_DLLFuncB30L.ChangeParameterAsync(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.Speed, 0);
            ChangeSpeedButtonColor(0);
        }

        private void SpeedToQuality1()
        {
            PrintersViewModel.m_DLLFuncB30L.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.Speed, 1);
            ChangeSpeedButtonColor(1);
        }

        private async Task SpeedToQuality1Async()
        {
            await PrintersViewModel.m_DLLFuncB30L.ChangeParameterAsync(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.Speed, 1);
            ChangeSpeedButtonColor(1);
        }

        private void SpeedToQuality2()
        {
            PrintersViewModel.m_DLLFuncB30L.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.Speed, 2);
            ChangeSpeedButtonColor(2);
        }

        private async Task SpeedToQuality2Async()
        {
            await PrintersViewModel.m_DLLFuncB30L.ChangeParameterAsync(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.Speed, 2);
            ChangeSpeedButtonColor(2);
        }

        private void ChangeSpeedButtonColor(int id)
        {
            switch (id)
            {
                case 0:
                    SpeedStandardColor = "#f7941d";
                    SpeedQuality1Color = "#5e6366";
                    SpeedQuality2Color = "#5e6366";
                    break;
                case 1:
                    SpeedStandardColor = "#5e6366";
                    SpeedQuality1Color = "#f7941d";
                    SpeedQuality2Color = "#5e6366";
                    break;
                case 2:
                    SpeedStandardColor = "#5e6366";
                    SpeedQuality1Color = "#5e6366";
                    SpeedQuality2Color = "#f7941d";
                    break;
            }
        }
        #endregion

        #region Margin Commands
        private void MarginToMin()
        {
            PrintersViewModel.m_DLLFuncB30L.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.Margin, 0);
            ChangeMarginButtonColor(0);
        }
        private async Task MarginToMinAsync()
        {
            await PrintersViewModel.m_DLLFuncB30L.ChangeParameterAsync(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.Margin, 0);
            ChangeMarginButtonColor(0);
        }
        private void MarginToTopMin()
        {
            PrintersViewModel.m_DLLFuncB30L.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.Margin, 1);
            ChangeMarginButtonColor(1);
        }
        private async Task MarginToTopMinAsync()
        {
            await PrintersViewModel.m_DLLFuncB30L.ChangeParameterAsync(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.Margin, 1);
            ChangeMarginButtonColor(1);
        }
        private void MarginBottomMin()
        {
            PrintersViewModel.m_DLLFuncB30L.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.Margin, 2);
            ChangeMarginButtonColor(2);
        }
        private async Task MarginBottomMinAsync()
        {
            await PrintersViewModel.m_DLLFuncB30L.ChangeParameterAsync(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.Margin, 2);
            ChangeMarginButtonColor(2);
        }
        private void MarginToMax()
        {
            PrintersViewModel.m_DLLFuncB30L.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.Margin, 3);
            ChangeMarginButtonColor(3);
        }
        private async Task MarginToMaxAsync()
        {
            await PrintersViewModel.m_DLLFuncB30L.ChangeParameterAsync(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.Margin, 3);
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
            PrintersViewModel.m_DLLFuncB30L.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.Direction, 0);
            ChangeDirectionButtonColor(0);
        }
        private async Task DirectionForwardAsync()
        {
            await PrintersViewModel.m_DLLFuncB30L.ChangeParameterAsync(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.Direction, 0);
            ChangeDirectionButtonColor(0);
        }
        private void DirectionBackward()
        {
            PrintersViewModel.m_DLLFuncB30L.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.Direction, 1);
            ChangeDirectionButtonColor(1);
        }
        private async Task DirectionBackwardAsync()
        {
            await PrintersViewModel.m_DLLFuncB30L.ChangeParameterAsync(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.Direction, 1);
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
            PrintersViewModel.m_DLLFuncB30L.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.Orientation, 0);
            ChangeOrientationButtonColor(0);
        }
        private async Task SetOrientationPortraitAsync()
        {
            await PrintersViewModel.m_DLLFuncB30L.ChangeParameterAsync(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.Orientation, 0);
            ChangeOrientationButtonColor(0);
        }

        private void SetOrientationLandscape()
        {
            PrintersViewModel.m_DLLFuncB30L.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.Orientation, 1);
            ChangeOrientationButtonColor(1);
        }
        private async Task SetOrientationLandscapeAsync()
        {
            await PrintersViewModel.m_DLLFuncB30L.ChangeParameterAsync(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.Orientation, 1);
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
            PrintersViewModel.m_DLLFuncF10G10.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.FeedToCutPosition, 0);
            ChangeFeedButtonColor(0);
        }
        private async Task EnableFeedAsync()
        {
            await PrintersViewModel.m_DLLFuncB30L.ChangeParameterAsync(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.FeedToCutPosition, 0);
            ChangeFeedButtonColor(0);
        }
        private void DisableFeed()
        {
            PrintersViewModel.m_DLLFuncF10G10.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.FeedToCutPosition, 1);
            ChangeFeedButtonColor(1);
        }
        private async Task DisableFeedAsync()
        {
            await PrintersViewModel.m_DLLFuncB30L.ChangeParameterAsync(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.FeedToCutPosition, 1);
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
            PrintersViewModel.m_DLLFuncB30L.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.PaperCut, 0);
            ChangeCutButtonColor(0);
        }
        private async Task SetCutNoCutAsync()
        {
            await PrintersViewModel.m_DLLFuncB30L.ChangeParameterAsync(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.PaperCut, 0);
            ChangeCutButtonColor(0);
        }
        private void SetFullCutByJob()
        {
            PrintersViewModel.m_DLLFuncB30L.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.PaperCut, 1);
            ChangeCutButtonColor(1);
        }
        private async Task SetFullCutByJobAsync()
        {
            await PrintersViewModel.m_DLLFuncB30L.ChangeParameterAsync(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.PaperCut, 1);
            ChangeCutButtonColor(1);
        }
        private void SetPartialCutByJobs()
        {
            PrintersViewModel.m_DLLFuncB30L.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.PaperCut, 2);
            ChangeCutButtonColor(2);
        }
        private async Task SetPartialCutByJobsAsync()
        {
            await PrintersViewModel.m_DLLFuncB30L.ChangeParameterAsync(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.PaperCut, 2);
            ChangeCutButtonColor(2);
        }
        private void SetFullCutByPage()
        {
            PrintersViewModel.m_DLLFuncB30L.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.PaperCut, 3);
            ChangeCutButtonColor(3);
        }
        private async Task SetFullCutByPageAsync()
        {
            await PrintersViewModel.m_DLLFuncB30L.ChangeParameterAsync(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.PaperCut, 3);
            ChangeCutButtonColor(3);
        }
        private void SetPartialCutByPage()
        {
            PrintersViewModel.m_DLLFuncB30L.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.PaperCut, 4);
            ChangeCutButtonColor(4);
        }
        private async Task SetPartialCutByPageAsync()
        {
            await PrintersViewModel.m_DLLFuncB30L.ChangeParameterAsync(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.PaperCut, 4);
            ChangeCutButtonColor(4);
        }

        private void SetPartialCutBetweenPages()
        {
            PrintersViewModel.m_DLLFuncB30L.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.PaperCut, 5);
            ChangeCutButtonColor(5);
        }
        private async Task SetPartialCutBetweenPagesAsync()
        {
            await PrintersViewModel.m_DLLFuncB30L.ChangeParameterAsync(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.PaperCut, 5);
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
