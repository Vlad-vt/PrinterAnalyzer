using PrinterAnalyzer.Core;
using PrinterAnalyzer.MVVM.Model;
using PrinterAnalyzer.MVVM.Model.PrinterProperties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        #region Page Start Logo
        public RelayCommand PageStartLogoNoneCommand { get; set; }
        public RelayCommand PageStartLogoLeftCommand { get; set; }
        public RelayCommand PageStartLogoCenterCommand { get; set; }
        public RelayCommand PageStartLogoRightCommand { get; set; }

        private string _pageStartLogoNoneColor;
        public string PageStartLogoNoneColor
        {
            get { return _pageStartLogoNoneColor; }
            set
            {
                _pageStartLogoNoneColor = value;
                OnPropertyChanged();
            }
        }

        private string _pageStartLogoLeftColor;
        public string PageStartLogoLeftColor
        {
            get { return _pageStartLogoLeftColor; }
            set
            {
                _pageStartLogoLeftColor = value;
                OnPropertyChanged();
            }
        }

        private string _pageStartLogoCenterColor;
        public string PageStartLogoCenterColor
        {
            get { return _pageStartLogoCenterColor; }
            set
            {
                _pageStartLogoCenterColor = value;
                OnPropertyChanged();
            }
        }

        private string _pageStartLogoRightColor;
        public string PageStartLogoRightColor
        {
            get { return _pageStartLogoRightColor; }
            set
            {
                _pageStartLogoRightColor = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Page End Logo
        public RelayCommand PageEndLogoNoneCommand { get; set; }
        public RelayCommand PageEndLogoLeftCommand { get; set; }
        public RelayCommand PageEndLogoCenterCommand { get; set; }
        public RelayCommand PageEndLogoRightCommand { get; set; }

        private string _pageEndLogoNoneColor;
        public string PageEndLogoNoneColor
        {
            get { return _pageEndLogoNoneColor; }
            set
            {
                _pageEndLogoNoneColor = value;
                OnPropertyChanged();
            }
        }

        private string _pageEndLogoLeftColor;
        public string PageEndLogoLeftColor
        {
            get { return _pageEndLogoLeftColor; }
            set
            {
                _pageEndLogoLeftColor = value;
                OnPropertyChanged();
            }
        }

        private string _pageEndLogoCenterColor;
        public string PageEndLogoCenterColor
        {
            get { return _pageEndLogoCenterColor; }
            set
            {
                _pageEndLogoCenterColor = value;
                OnPropertyChanged();
            }
        }

        private string _pageEndLogoRightColor;
        public string PageEndLogoRightColor
        {
            get { return _pageEndLogoRightColor; }
            set
            {
                _pageEndLogoRightColor = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Paper Size
        public RelayCommand LetterPS { get; set; }
        public RelayCommand A4PS { get; set; }
        public RelayCommand MM80PS { get; set; }
        public RelayCommand MM5854PS { get; set; }
        public RelayCommand MM7672PS { get; set; }
        public RelayCommand MM7670PS { get; set; }
        public RelayCommand MM5852PS { get; set; }

        private string _letterPSColor;
        public string LetterPSColor
        {
            get { return _letterPSColor; }
            set
            {
                _letterPSColor = value;
                OnPropertyChanged();
            }
        }

        private string _a4PSColor;
        public string A4PSColor
        {
            get { return _a4PSColor; }
            set
            {
                _a4PSColor = value;
                OnPropertyChanged();
            }
        }

        private string _mm80Color;
        public string MM80Color
        {
            get { return _mm80Color; }
            set
            {
                _mm80Color = value;
                OnPropertyChanged();
            }
        }

        private string _mm5854Color;
        public string MM5854Color
        {
            get { return _mm5854Color; }
            set
            {
                _mm5854Color = value;
                OnPropertyChanged();
            }
        }

        private string _mm7672Color;
        public string MM7672Color
        {
            get { return _mm7672Color; }
            set
            {
                _mm7672Color = value;
                OnPropertyChanged();
            }
        }

        private string _mm7670Color;
        public string MM7670Color
        {
            get { return _mm7670Color; }
            set
            {
                _mm7670Color = value;
                OnPropertyChanged();
            }
        }

        private string _mm5852Color;
        public string MM5852Color
        {
            get { return _mm5852Color; }
            set
            {
                _mm5852Color = value;
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
                while (true)
                {
                    GetChanges();
                    Thread.Sleep(2000);
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }

        private void CommandsInit()
        {
            #region Speed Commands Init

            SpeedStandard = new RelayCommand(async o => await ChangeSpeedAsync(0));
            SpeedQuality1 = new RelayCommand(async o => await ChangeSpeedAsync(1));
            SpeedQuality2 = new RelayCommand(async o => await ChangeSpeedAsync(2));

            #endregion

            #region Margin Commands Init

            MinMarg = new RelayCommand(async o => await ChangeMarginAsync(0));
            MinTopMarg = new RelayCommand(async o => await ChangeMarginAsync(1));
            MinBottomMarg = new RelayCommand(async o => await ChangeMarginAsync(2));
            MaxMarg = new RelayCommand(async o => await ChangeMarginAsync(3));

            #endregion

            #region Direction Commands Init

            DirectionForwardCommand = new RelayCommand(async o => await ChangeDirectionAsync(0));
            DirectionBackwardCommand = new RelayCommand(async o => await ChangeDirectionAsync(1));

            #endregion

            #region Orientation Commands Init

            OrientationPortraitCommand = new RelayCommand(async o => await ChangeOrientationAsync(0));
            OrientationLandscapeCommand = new RelayCommand(async o => await ChangeOrientationAsync(1));

            #endregion

            #region Feed position commands init

            FeedEnabled = new RelayCommand(async o => await ChangeFeedAsync(0));
            FeedDisabled = new RelayCommand(async o => await ChangeFeedAsync(1));

            #endregion

            #region Preset commands init

            MM58PresCommand = new RelayCommand(async o => await ChangePresetAsync(1));
            MM58GapFormPresCommand = new RelayCommand(async o => await ChangePresetAsync(3));
            MM58GapFormLabelPresCommand = new RelayCommand(async o => await ChangePresetAsync(118));
            A458PresCommand = new RelayCommand(async o => await ChangePresetAsync(5));
            MM76ReseiptPresCommand = new RelayCommand(async o => await ChangePresetAsync(152));
            MM76GapFormPresCommand = new RelayCommand(async o => await ChangePresetAsync(153));
            MM76GapFormLabelPresCommand = new RelayCommand(async o => await ChangePresetAsync(154));
            A476PresCommand = new RelayCommand(async o => await ChangePresetAsync(155));
            MM80ReseiptPresCommand = new RelayCommand(async o => await ChangePresetAsync(0));
            MM80GapFormPresCommand = new RelayCommand(async o => await ChangePresetAsync(2));
            MM80GapFormLabelPresCommand = new RelayCommand(async o => await ChangePresetAsync(162));
            A480PresCommand = new RelayCommand(async o => await ChangePresetAsync(4));
            UserSettingPresCommand = new RelayCommand(async o => await ChangePresetAsync(6));

            #endregion

            #region Watermark Commands Init

            WatermarkNoneCommand = new RelayCommand(async o => await ChangeWatermarkAsync(0));
            WatermarkCenterCommand = new RelayCommand(async o => await ChangeWatermarkAsync(1));
            WatermarkLeftCommand = new RelayCommand(async o => await ChangeWatermarkAsync(2));
            WatermarkUpperLeftCommand = new RelayCommand(async o => await ChangeWatermarkAsync(3));
            WatermarkTopCenterCommand = new RelayCommand(async o => await ChangeWatermarkAsync(4));
            WatermarkUpperRightCommand = new RelayCommand(async o => await ChangeWatermarkAsync(5));
            WatermarkRightCommand = new RelayCommand(async o => await ChangeWatermarkAsync(6));
            WatermarkLowerLeftCommand = new RelayCommand(async o => await ChangeWatermarkAsync(7));
            WatermarkBottomCenterCommand = new RelayCommand(async o => await ChangeWatermarkAsync(8));
            WatermarkLowerRightCommand = new RelayCommand(async o => await ChangeWatermarkAsync(9));

            #endregion

            #region Marked Paper Form Feed Command Initialization

            NoFormFeed = new RelayCommand(async o => await ChangeMarkedPaperFormFeedAsync(0));
            ByPages = new RelayCommand(async o => await ChangeMarkedPaperFormFeedAsync(1));
            ByJob = new RelayCommand(async o => await ChangeMarkedPaperFormFeedAsync(2));

            #endregion

            #region Page Start Logo Command Initialization

            PageStartLogoNoneCommand = new RelayCommand(async o => await ChangePageStartLogoAsync(0));
            PageStartLogoLeftCommand = new RelayCommand(async o => await ChangePageStartLogoAsync(1));
            PageStartLogoCenterCommand = new RelayCommand(async o => await ChangePageStartLogoAsync(2));
            PageStartLogoRightCommand = new RelayCommand(async o => await ChangePageStartLogoAsync(3));

            #endregion

            #region Page End Logo Command Initialization

            PageEndLogoNoneCommand = new RelayCommand(async o => await ChangePageEndLogoAsync(0));
            PageEndLogoLeftCommand = new RelayCommand(async o => await ChangePageEndLogoAsync(1));
            PageEndLogoCenterCommand = new RelayCommand(async o => await ChangePageEndLogoAsync(2));
            PageEndLogoRightCommand = new RelayCommand(async o => await ChangePageEndLogoAsync(3));

            #endregion

            #region Paper Size Command Initialization

            LetterPS = new RelayCommand(async o => await ChangePaperSizeAsync(0));
            A4PS = new RelayCommand(async o => await ChangePaperSizeAsync(1));
            MM80PS = new RelayCommand(async o => await ChangePaperSizeAsync(2));
            MM5854PS = new RelayCommand(async o => await ChangePaperSizeAsync(3));
            MM7672PS = new RelayCommand(async o => await ChangePaperSizeAsync(5));
            MM7670PS = new RelayCommand(async o => await ChangePaperSizeAsync(6));
            MM5852PS = new RelayCommand(async o => await ChangePaperSizeAsync(7));

            #endregion

        }

        private void GetChanges()
        {
            try
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    var properties = _printer.properties as Properties_RP_F10_G10_B30;
                    var currentProperties = properties?.CurrentProperties;

                    if (currentProperties == null) 
                        return;

                    #region Speed property
                    try
                    {
                        ChangeSpeedButtonColor(currentProperties.GetValueOrDefault(PropertyType.Speed));
                    }
                    catch(Exception ex) 
                    {
                        Trace.WriteLine("Speed property error: " + ex.Message);
                    }
                    #endregion

                    #region Direction property
                    try
                    {
                        ChangeDirectionButtonColor(currentProperties.GetValueOrDefault(PropertyType.Direction));
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine("Speed property error: " + ex.Message);
                    }
                    #endregion

                    #region Margin property
                    try
                    {
                        ChangeMarginButtonColor(currentProperties.GetValueOrDefault(PropertyType.Margin));
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine("Speed property error: " + ex.Message);
                    }
                    #endregion

                    #region Orientation property
                    try
                    {
                        ChangeOrientationButtonColor(currentProperties.GetValueOrDefault(PropertyType.Orientation));
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine("Speed property error: " + ex.Message);
                    }
                    #endregion

                    #region Watermark property
                    try
                    {
                        ChangeWatermarkButtonColor(currentProperties.GetValueOrDefault(PropertyType.Watermark));
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine("Speed property error: " + ex.Message);
                    }
                    #endregion

                    #region Preset property
                    try
                    {
                        ChangePresetButtonColor(currentProperties.GetValueOrDefault(PropertyType.Preset));
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine("Speed property error: " + ex.Message);
                    }
                    #endregion

                    #region MarkFeed property
                    try
                    {
                        ChangeMarkedPaperFormFeedButtonColor(currentProperties.GetValueOrDefault(PropertyType.MarkFeed));
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine("Speed property error: " + ex.Message);
                    }
                    #endregion

                    #region Page start logo property
                    try
                    {
                        ChangePageStartLogoButtonColor(currentProperties.GetValueOrDefault(PropertyType.PageStartLogo));
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine("Speed property error: " + ex.Message);
                    }
                    #endregion

                    #region Page end logo property
                    try
                    {
                        ChangePageEndLogoButtonColor(currentProperties.GetValueOrDefault(PropertyType.PageEndLogo));
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine("Speed property error: " + ex.Message);
                    }
                    #endregion

                    #region Paper size property
                    try
                    {
                        ChangePaperSizeButtonColor(currentProperties.GetValueOrDefault(PropertyType.PaperSize));
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine("Speed property error: " + ex.Message);
                    }
                    #endregion

                    #region Feed position property
                    try
                    {
                        ChangeFeedButtonColor(currentProperties.GetValueOrDefault(PropertyType.FeedToCutPosition));
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine("Speed property error: " + ex.Message);
                    }
                    #endregion

                });
            }
            catch
            {
                // Handle exceptions as needed
            }
        }




        #region Speed Commands
        private void ChangeSpeed(int speedId)
        {
            PrintersViewModel.m_DLLFuncB30L.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.Speed, speedId);
            ChangeSpeedButtonColor(speedId);
        }

        private async Task ChangeSpeedAsync(int speedId)
        {
            await PrintersViewModel.m_DLLFuncB30L.ChangeParameterAsync(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.Speed, speedId);
            ChangeSpeedButtonColor(speedId);
        }

        private void ChangeSpeedButtonColor(int id)
        {
            // Set default color for all speed settings
            SpeedStandardColor = "#5e6366";
            SpeedQuality1Color = "#5e6366";
            SpeedQuality2Color = "#5e6366";

            // Highlight selected speed setting
            switch (id)
            {
                case 0:
                    SpeedStandardColor = "#f7941d";
                    break;
                case 1:
                    SpeedQuality1Color = "#f7941d";
                    break;
                case 2:
                    SpeedQuality2Color = "#f7941d";
                    break;
            }
        }
        #endregion

        #region Margin Commands
        private void ChangeMargin(int marginId)
        {
            PrintersViewModel.m_DLLFuncB30L.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.Margin, marginId);
            ChangeMarginButtonColor(marginId);
        }

        private async Task ChangeMarginAsync(int marginId)
        {
            await PrintersViewModel.m_DLLFuncB30L.ChangeParameterAsync(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.Margin, marginId);
            ChangeMarginButtonColor(marginId);
        }

        private void ChangeMarginButtonColor(int id)
        {
            // Set default color for all margin settings
            MinMargColor = "#5e6366";
            MinTopMargColor = "#5e6366";
            MinBottomMargColor = "#5e6366";
            MaxMargColor = "#5e6366";

            // Highlight selected margin setting
            switch (id)
            {
                case 0:
                    MinMargColor = "#f7941d";
                    break;
                case 1:
                    MinTopMargColor = "#f7941d";
                    break;
                case 2:
                    MinBottomMargColor = "#f7941d";
                    break;
                case 3:
                    MaxMargColor = "#f7941d";
                    break;
            }
        }
        #endregion

        #region DirectionCommands
        private void ChangeDirection(int directionId)
        {
            PrintersViewModel.m_DLLFuncB30L.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.Direction, directionId);
            ChangeDirectionButtonColor(directionId);
        }

        private async Task ChangeDirectionAsync(int directionId)
        {
            await PrintersViewModel.m_DLLFuncB30L.ChangeParameterAsync(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.Direction, directionId);
            ChangeDirectionButtonColor(directionId);
        }

        private void ChangeDirectionButtonColor(int id)
        {
            // Set default color for all directions
            DirectionForwardColor = "#5e6366";
            DirectionBackwardColor = "#5e6366";

            // Highlight selected direction
            switch (id)
            {
                case 0:
                    DirectionForwardColor = "#f7941d";
                    break;
                case 1:
                    DirectionBackwardColor = "#f7941d";
                    break;
            }
        }
        #endregion

        #region OrientationCommands
        private void ChangeOrientation(int orientationId)
        {
            PrintersViewModel.m_DLLFuncB30L.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.Orientation, orientationId);
            ChangeOrientationButtonColor(orientationId);
        }

        private async Task ChangeOrientationAsync(int orientationId)
        {
            await PrintersViewModel.m_DLLFuncB30L.ChangeParameterAsync(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.Orientation, orientationId);
            ChangeOrientationButtonColor(orientationId);
        }

        private void ChangeOrientationButtonColor(int id)
        {
            // Set default color for all orientations
            OrientationPortraitColor = "#5e6366";
            OrientationLandscapeColor = "#5e6366";

            // Highlight selected orientation
            switch (id)
            {
                case 0:
                    OrientationPortraitColor = "#f7941d";
                    break;
                case 1:
                    OrientationLandscapeColor = "#f7941d";
                    break;
            }
        }

        #endregion

        #region FeedPosition Commands
        private void ChangeFeed(int feedState)
        {
            PrintersViewModel.m_DLLFuncF10G10.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.FeedToCutPosition, feedState);
            ChangeFeedButtonColor(feedState);
        }

        private async Task ChangeFeedAsync(int feedState)
        {
            await PrintersViewModel.m_DLLFuncF10G10.ChangeParameterAsync(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.FeedToCutPosition, feedState);
            ChangeFeedButtonColor(feedState);
        }

        private void ChangeFeedButtonColor(int id)
        {
            FeedEnabledColor = "#5e6366";
            FeedDisabledColor = "#5e6366";
            switch (id)
            {
                case 0:
                    FeedEnabledColor = "#f7941d";
                    break;
                case 1:
                    FeedDisabledColor = "#f7941d";
                    break;
            }
        }
        #endregion

        #region Paper Size Commands
        private void ChangePaperSize(int sizeId)
        {
            PrintersViewModel.m_DLLFuncB30L.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.PaperSize, sizeId);
            ChangePaperSizeButtonColor(sizeId);
        }

        private async Task ChangePaperSizeAsync(int sizeId)
        {
            await PrintersViewModel.m_DLLFuncB30L.ChangeParameterAsync(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.PaperSize, sizeId);
            ChangePaperSizeButtonColor(sizeId);
        }

        private void ChangePaperSizeButtonColor(int id)
        {
            // Set default color for all paper sizes
            LetterPSColor = "#5e6366";
            A4PSColor = "#5e6366";
            MM80Color = "#5e6366";
            MM5854Color = "#5e6366";
            MM7672Color = "#5e6366";
            MM7670Color = "#5e6366";
            MM5852Color = "#5e6366";

            // Highlight selected paper size
            switch (id)
            {
                case 0:
                    LetterPSColor = "#f7941d";
                    break;
                case 1:
                    A4PSColor = "#f7941d";
                    break;
                case 2:
                    MM80Color = "#f7941d";
                    break;
                case 3:
                    MM5854Color = "#f7941d";
                    break;
                case 5:
                    MM7672Color = "#f7941d";
                    break;
                case 6:
                    MM7670Color = "#f7941d";
                    break;
                case 7:
                    MM5852Color = "#f7941d";
                    break;
            }
        }
        #endregion

        #region Preset Commands
        private void ChangePreset(int presetId)
        {
            PrintersViewModel.m_DLLFuncB30L.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.Preset, presetId);
            ChangePresetButtonColor(presetId);
        }

        private async Task ChangePresetAsync(int presetId)
        {
            await PrintersViewModel.m_DLLFuncB30L.ChangeParameterAsync(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.Preset, presetId);
            ChangePresetButtonColor(presetId);
        }

        private void ChangePresetButtonColor(int id)
        {
            // Set default color for all presets
            MM58PresColor = "#5e6366";
            MM58GapFormPresColor = "#5e6366";
            MM58GapFormLabelPresColor = "#5e6366";
            A458PresColor = "#5e6366";
            MM76ReseiptPresColor = "#5e6366";
            MM76GapFormPresColor = "#5e6366";
            MM76GapFormLabelPresColor = "#5e6366";
            A476PresColor = "#5e6366";
            MM80ReseiptPresColor = "#5e6366";
            MM80GapFormPresColor = "#5e6366";
            MM80GapFormLabelPresColor = "#5e6366";
            A480PresColor = "#5e6366";
            UserSettingPresColor = "#5e6366";

            // Highlight selected preset
            switch (id)
            {
                case 1:   // 58 mm Receipt Setting
                    MM58PresColor = "#f7941d";
                    break;
                case 3:   // 58 mm Mark or Gap Form Feed Setting
                    MM58GapFormPresColor = "#f7941d";
                    break;
                case 118: // 58 mm Mark or Gap Form Feed Setting (Label)
                    MM58GapFormLabelPresColor = "#f7941d";
                    break;
                case 5:   // A4->58 mm Reduction Setting
                    A458PresColor = "#f7941d";
                    break;
                case 152: // 76.2 mm Receipt Setting
                    MM76ReseiptPresColor = "#f7941d";
                    break;
                case 153: // 76.2 mm Mark or Gap Form Feed Setting
                    MM76GapFormPresColor = "#f7941d";
                    break;
                case 154: // 76.2 mm Mark or Gap Form Feed Setting (Label)
                    MM76GapFormLabelPresColor = "#f7941d";
                    break;
                case 155: // A4->76.2 mm Reduction Setting
                    A476PresColor = "#f7941d";
                    break;
                case 0:   // 80 mm Receipt Setting
                    MM80ReseiptPresColor = "#f7941d";
                    break;
                case 2:   // 80 mm Mark or Gap Form Feed Setting
                    MM80GapFormPresColor = "#f7941d";
                    break;
                case 162: // 80 mm Mark or Gap Form Feed Setting (Label)
                    MM80GapFormLabelPresColor = "#f7941d";
                    break;
                case 4:   // A4->80 mm Reduction Setting
                    A480PresColor = "#f7941d";
                    break;
                case 6:   // User setting
                    UserSettingPresColor = "#f7941d";
                    break;
            }
        }
        #endregion

        #region Watermark Commands
        private void ChangeWatermark(int watermarkId)
        {
            PrintersViewModel.m_DLLFuncB30L.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.Watermark, watermarkId);
            ChangeWatermarkButtonColor(watermarkId);
        }

        private async Task ChangeWatermarkAsync(int watermarkId)
        {
            await PrintersViewModel.m_DLLFuncB30L.ChangeParameterAsync(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.Watermark, watermarkId);
            ChangeWatermarkButtonColor(watermarkId);
        }

        private void ChangeWatermarkButtonColor(int id)
        {
            // Set default color for all watermarks
            WatermarkNoneColor = "#5e6366";
            WatermarkCenterColor = "#5e6366";
            WatermarkLeftColor = "#5e6366";
            WatermarkUpperLeftColor = "#5e6366";
            WatermarkTopCenterColor = "#5e6366";
            WatermarkUpperRightColor = "#5e6366";
            WatermarkRightColor = "#5e6366";
            WatermarkLowerLeftColor = "#5e6366";
            WatermarkBottomCenterColor = "#5e6366";
            WatermarkLowerRightColor = "#5e6366";

            // Highlight selected watermark
            switch (id)
            {
                case 0:
                    WatermarkNoneColor = "#f7941d";
                    break;
                case 1:
                    WatermarkCenterColor = "#f7941d";
                    break;
                case 2:
                    WatermarkLeftColor = "#f7941d";
                    break;
                case 3:
                    WatermarkUpperLeftColor = "#f7941d";
                    break;
                case 4:
                    WatermarkTopCenterColor = "#f7941d";
                    break;
                case 5:
                    WatermarkUpperRightColor = "#f7941d";
                    break;
                case 6:
                    WatermarkRightColor = "#f7941d";
                    break;
                case 7:
                    WatermarkLowerLeftColor = "#f7941d";
                    break;
                case 8:
                    WatermarkBottomCenterColor = "#f7941d";
                    break;
                case 9:
                    WatermarkLowerRightColor = "#f7941d";
                    break;
            }
        }
        #endregion

        #region Page Start Logo
        private void ChangePageStartLogo(int logoId)
        {
            PrintersViewModel.m_DLLFuncB30L.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.PageStartLogo, logoId);
            ChangePageStartLogoButtonColor(logoId);
        }

        private async Task ChangePageStartLogoAsync(int logoId)
        {
            await PrintersViewModel.m_DLLFuncB30L.ChangeParameterAsync(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.PageStartLogo, logoId);
            ChangePageStartLogoButtonColor(logoId);
        }

        private void ChangePageStartLogoButtonColor(int id)
        {
            // Set default color for all page start logos
            PageStartLogoNoneColor = "#5e6366";
            PageStartLogoLeftColor = "#5e6366";
            PageStartLogoCenterColor = "#5e6366";
            PageStartLogoRightColor = "#5e6366";

            // Highlight selected page start logo
            switch (id)
            {
                case 0:
                    PageStartLogoNoneColor = "#f7941d";
                    break;
                case 1:
                    PageStartLogoLeftColor = "#f7941d";
                    break;
                case 2:
                    PageStartLogoCenterColor = "#f7941d";
                    break;
                case 3:
                    PageStartLogoRightColor = "#f7941d";
                    break;
            }
        }
        #endregion

        #region Page End Logo
        private void ChangePageEndLogo(int logoId)
        {
            PrintersViewModel.m_DLLFuncB30L.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.PageEndLogo, logoId);
            ChangePageEndLogoButtonColor(logoId);
        }

        private async Task ChangePageEndLogoAsync(int logoId)
        {
            await PrintersViewModel.m_DLLFuncB30L.ChangeParameterAsync(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.PageEndLogo, logoId);
            ChangePageEndLogoButtonColor(logoId);
        }

        private void ChangePageEndLogoButtonColor(int id)
        {
            // Set default color for all page end logos
            PageEndLogoNoneColor = "#5e6366";
            PageEndLogoLeftColor = "#5e6366";
            PageEndLogoCenterColor = "#5e6366";
            PageEndLogoRightColor = "#5e6366";

            // Highlight selected page end logo
            switch (id)
            {
                case 0:
                    PageEndLogoNoneColor = "#f7941d";
                    break;
                case 1:
                    PageEndLogoLeftColor = "#f7941d";
                    break;
                case 2:
                    PageEndLogoCenterColor = "#f7941d";
                    break;
                case 3:
                    PageEndLogoRightColor = "#f7941d";
                    break;
            }
        }
        #endregion

        #region Marked paper form feed commands
        private void ChangeMarkedPaperFormFeed(int feedType)
        {
            PrintersViewModel.m_DLLFuncB30L.ChangeParameter(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.MarkFeed, feedType);
            ChangeMarkedPaperFormFeedButtonColor(feedType);
        }

        private async Task ChangeMarkedPaperFormFeedAsync(int feedType)
        {
            await PrintersViewModel.m_DLLFuncB30L.ChangeParameterAsync(_printer.properties, _printer.Name, Enums.PrinterType.SII_MP_B30L, Model.PrinterProperties.PropertyType.MarkFeed, feedType);
            ChangeMarkedPaperFormFeedButtonColor(feedType);
        }

        private void ChangeMarkedPaperFormFeedButtonColor(int id)
        {
            // Set default color for all feed types
            NoFormFeedColor = "#5e6366";
            ByPagesColor = "#5e6366";
            ByJobColor = "#5e6366";

            // Highlight selected feed type
            switch (id)
            {
                case 0:
                    NoFormFeedColor = "#f7941d";
                    break;
                case 1:
                    ByPagesColor = "#f7941d";
                    break;
                case 2:
                    ByJobColor = "#f7941d";
                    break;
            }
        }

        #endregion
    }
}
