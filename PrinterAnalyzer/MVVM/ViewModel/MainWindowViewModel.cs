using PrinterAnalyzer.Core;
using System.Windows;

namespace PrinterAnalyzer.MVVM.ViewModel
{
    internal sealed class MainWindowViewModel : ObservableObject
    {
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

        #endregion

        private string _activeButtonStyle;
        public string ActiveButtonStyle
        {
            get { return _activeButtonStyle; }
            set { _activeButtonStyle = value; }
        }

        public MainWindowViewModel()
        {
            RPE10buttonStyle = Application.Current.FindResource("menuButton") as Style;
            RPF10G10buttonStyle = Application.Current.FindResource("menuButton") as Style;
            ActiveButtonStyle = "menuButtonActive";
        }
    }
}
