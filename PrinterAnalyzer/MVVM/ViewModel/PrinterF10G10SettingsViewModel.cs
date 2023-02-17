using PrinterAnalyzer.Communication.RP_F10_G10;
using PrinterAnalyzer.Core;
using System;

namespace PrinterAnalyzer.MVVM.ViewModel
{
    internal class PrinterF10G10SettingsViewModel : ObservableObject
    {
        #region SPEED
        public RelayCommand speedHigh { get; set; }
        public RelayCommand speedMiddleQuality { get; set; }
        public RelayCommand speedMiddleSilent { get; set; }
        #endregion

        public PrinterF10G10SettingsViewModel(ref DllFuncF10G10 dllFuncF10G10)
        {
            #region SPEED Commands
            speedHigh = new RelayCommand(obj => { ChangeSpeedToHigh();});
            speedMiddleQuality = new RelayCommand(obj => { ChangeSpeedToMidQuality(); });
            speedMiddleSilent = new RelayCommand(obj => { ChangeSpeedToMidSilent(); });
            #endregion
        }

        #region SPEED Methods
        private void ChangeSpeedToHigh()
        {
           
        }
        private void ChangeSpeedToMidQuality()
        {

        }
        private void ChangeSpeedToMidSilent()
        {

        }
        #endregion
    }
}
