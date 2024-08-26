using PrinterAnalyzer.Core;
using PrinterAnalyzer.Enums;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace PrinterAnalyzer.MVVM.ViewModel
{
    internal sealed class MainWindowViewModel : ObservableObject
    {

        public RelayCommand ExitProgram { get; set; }

        public RelayCommand HideProgram { get; set; }

        public RelayCommand MaximizeProgram { get; set; }

        public PrintersViewModel PVM { get; set; }

        #region MenuButtonsStyles
        private Style _RPE10buttonStyle;
        public Style RPE10buttonStyle
        {
            get
            {
                return _RPE10buttonStyle;
            }
            set
            {
                _RPE10buttonStyle = value;
                OnPropertyChanged();
            }
        }

        private Style _RPF10G10buttonStyle;
        public Style RPF10G10buttonStyle
        {
            get
            {
                return _RPF10G10buttonStyle;
            }
            set
            {
                _RPF10G10buttonStyle = value;
                OnPropertyChanged();
            }
        }

        private Style _MPB30LbuttonStyle;

        public Style MPB30LbuttonStyle
        {
            get 
            { 
                return _MPB30LbuttonStyle; 
            }
            set 
            { 
                _MPB30LbuttonStyle = value; 
                OnPropertyChanged();
            }
        }


        #endregion

        private string _activeButtonStyle;
        public string ActiveButtonStyle
        {
            get { return _activeButtonStyle; }
            set { _activeButtonStyle = value; }
        }

        private object _settingsView;

        public object CurrentView
        {
            get 
            { 
                return _settingsView; 
            }
            set 
            { 
                _settingsView = value;
                OnPropertyChanged();
            }
        }


        public RelayCommand ShowSII_RP_E10View { get; set; }

        public RelayCommand ShowSII_RP_F10_G10View { get; set; }

        public RelayCommand ShowSII_MP_B30LView { get; set; }

        private PrinterType _PrinterType;

        private Style _menuButtonStyle;

        private Style _menuButtonActiveStyle;

        public delegate void PrinterIsChanged(PrinterType menuButton);

        public event PrinterIsChanged PrinterChanged;

        public MainWindowViewModel()
        {
            #region DefaultButtons commands
            ExitProgram = new RelayCommand(o => { Application.Current.Shutdown(); });
            HideProgram = new RelayCommand(o => { Application.Current.MainWindow.WindowState = WindowState.Minimized; });
            MaximizeProgram = new RelayCommand(o =>
            {
                if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
                    Application.Current.MainWindow.WindowState = WindowState.Normal;
                else
                    Application.Current.MainWindow.WindowState = WindowState.Maximized;
            });
            #endregion

            #region Cached menu styles
            _menuButtonStyle = Application.Current.FindResource("menuButton") as Style;
            _menuButtonActiveStyle = Application.Current.FindResource("menuButtonActive") as Style;
            #endregion

            RPE10buttonStyle = Application.Current.FindResource("menuButtonActive") as Style;
            RPF10G10buttonStyle = Application.Current.FindResource("menuButton") as Style;
            ActiveButtonStyle = "menuButtonActive";
            PVM = new PrintersViewModel();
            PrinterChanged += PVM.PrinterChanged;
            PrinterChanged.Invoke(PrinterType.SII_RP_E10);

            #region MenuButtons Commands
            ShowSII_RP_E10View = new RelayCommand(async o =>
            {
                ResetButtonStyles(_PrinterType);

                _PrinterType = PrinterType.SII_RP_E10;

                RPE10buttonStyle = _menuButtonActiveStyle;

                await Task.Run(() =>
                {
                    CurrentView = PVM;
                });
                
                PrinterChanged.Invoke(PrinterType.SII_RP_E10);
            });
            ShowSII_RP_F10_G10View = new RelayCommand(async o => SII_RP_F10_G10_Click());
            ShowSII_MP_B30LView= new RelayCommand(async o =>
            {
                ResetButtonStyles(_PrinterType);

                _PrinterType = PrinterType.SII_RP_F10;

                MPB30LbuttonStyle = _menuButtonActiveStyle;
               
                await Task.Run(() =>
                {
                    CurrentView = PVM;
                });
                PrinterChanged.Invoke(PrinterType.SII_RP_F10);
            });
            #endregion

            CurrentView = PVM;
        }


        private async Task SII_RP_E10_Click()
        {
            ResetButtonStyles(_PrinterType);

            _PrinterType = PrinterType.SII_RP_F10;

            RPF10G10buttonStyle = _menuButtonActiveStyle;

            PrinterChanged.Invoke(PrinterType.SII_RP_F10);

            await Task.Run(() =>
            {
                CurrentView = PVM;
            });
        }

        private async Task SII_RP_F10_G10_Click()
        {
            ResetButtonStyles(_PrinterType);

            _PrinterType = PrinterType.SII_RP_F10;

            RPF10G10buttonStyle = _menuButtonActiveStyle;

            PrinterChanged.Invoke(PrinterType.SII_RP_F10);

            await Task.Run(() =>
            {
                CurrentView = PVM;
            });
        }

        private async Task SII_MP_B30L_Click()
        {
            ResetButtonStyles(_PrinterType);

            _PrinterType = PrinterType.SII_RP_F10;

            RPF10G10buttonStyle = _menuButtonActiveStyle;

            PrinterChanged.Invoke(PrinterType.SII_RP_F10);

            await Task.Run(() =>
            {
                CurrentView = PVM;
            });
        }

        /// <summary>
        /// Reset button styles to chenge menu active button
        /// </summary>
        private void ResetButtonStyles(PrinterType printerType)
        {
            switch (printerType)
            {
                case PrinterType.SII_RP_E10:
                    RPE10buttonStyle = _menuButtonStyle;
                    break;
                case PrinterType.SII_RP_F10:
                    RPF10G10buttonStyle = _menuButtonStyle;
                    break;
                case PrinterType.SII_MP_B30L:
                    MPB30LbuttonStyle = _menuButtonStyle;
                    break;
            }
        }

    }
}
