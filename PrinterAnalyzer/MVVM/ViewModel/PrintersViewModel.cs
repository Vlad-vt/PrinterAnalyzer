using PrinterAnalyzer.Core;
using PrinterAnalyzer.Enums;
using PrinterAnalyzer.MVVM.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PrinterAnalyzer.MVVM.ViewModel
{
    internal class PrintersViewModel : ObservableObject
    {
        private ObservableCollection<PrinterAction> _actionList;
        public ObservableCollection<PrinterAction> ActionList
        {
            get
            {
                return _actionList;
            }
            set
            {
                _actionList = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Printer> _printerList;

        public ObservableCollection<Printer> PrintersList
        {
            get { return _printerList; }
            set { _printerList = value; }
        }

        private string _printersCount;

        public string PrintersCount
        {
            get { return _printersCount; }
            set { _printersCount = value; OnPropertyChanged(); }
        }

        private string _printerTypeName;
        public string PrinterTypeName
        {
            get
            {
                return _printerTypeName;
            }
            set
            {
                _printerTypeName = value;
                OnPropertyChanged();
            }
        }

        private List<Printer> PrintersMainList;

        public PrintersViewModel()
        {
            ActionList = new ObservableCollection<PrinterAction>();
            PrintersList = new ObservableCollection<Printer>();
            PrintersMainList.Add(new Printer());
            PrintersList.Add(new Printer());
        }

        public void GetNewPrinterData(PrinterType printerType)
        {

        }

        public void PrinterChanged(PrinterType printerType)
        {
            switch(printerType)
            {
                case PrinterType.SII_RP_E10:
                    PrinterTypeName = "SII RP-E10 type printers data";
                    break;
                case PrinterType.SII_RP_F10_G10:
                    PrinterTypeName = "SII RP-E10, RP-G10 types printers data";
                    break;
            }
            GetNewPrinterData(printerType);
        }
    }
}
