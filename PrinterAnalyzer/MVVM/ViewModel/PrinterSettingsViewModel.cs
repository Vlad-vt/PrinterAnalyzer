using PrinterAnalyzer.Core;
using System;

namespace PrinterAnalyzer.MVVM.ViewModel
{
    internal class PrinterSettingsViewModel : ObservableObject
    {
        #region SPEED
        public RelayCommand speedHigh { get; set; }
        public RelayCommand speedMiddleQuality { get; set; }
        public RelayCommand speedMiddleSilent { get; set; }
        #endregion

        public PrinterSettingsViewModel()
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
