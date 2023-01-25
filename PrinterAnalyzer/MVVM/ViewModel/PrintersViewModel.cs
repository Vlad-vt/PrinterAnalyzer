using PrinterAnalyzer.Communication.RP_E10;
using PrinterAnalyzer.Core;
using PrinterAnalyzer.Enums;
using PrinterAnalyzer.MVVM.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Printing;

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

        private DllFuncE10 m_DLLFunc;

        public PrintersViewModel()
        {
            ActionList = new ObservableCollection<PrinterAction>();
            PrintersList = new ObservableCollection<Printer>();
            PrintersMainList = new List<Printer>();
            m_DLLFunc = new DllFuncE10();
            m_DLLFunc.myCallbackEvent += new DllFuncE10.callbackEventHandler(AddMsgCBStatus);
            m_DLLFunc = new DllFuncE10();
            m_DLLFunc.myCallbackEvent += new DllFuncE10.callbackEventHandler(AddMsgCBStatus);
            m_DLLFunc.CallbackSamp(true);
            CreatePrinterList();
        }

        private void CreatePrinterList()
        {
            for (int index = 0; index < PrinterSettings.InstalledPrinters.Count; index++)
            {
                string printerName = PrinterSettings.InstalledPrinters[index];

                if (printerName.StartsWith("SII"))
                {
                    PrintersMainList.Add(new Printer(printerName));
                }
            }
        }


        private void AddMsgCBStatus(string msg)
        {
            System.Windows.MessageBox.Show(msg);
        }

        public void GetNewPrinterData(PrinterType printerType)
        {
            for (int i = 0; i < PrintersMainList.Count; i++)
            {
                switch(printerType)
                {
                    case PrinterType.SII_RP_E10:
                        if (PrintersMainList[i].Name.Contains("E10"))
                        {
                            PrintersList.Add(new Printer(PrintersMainList[i].Name));
                        }
                        break;
                    case PrinterType.SII_RP_F10_G10:
                        if (PrintersMainList[i].Name.Contains("F10") || PrintersMainList[i].Name.Contains("G10"))
                        {
                            PrintersList.Add(new Printer(PrintersMainList[i].Name));
                        }
                        break;
                }
            }
            PrintersCount = PrintersList.Count.ToString();
        }

        public void PrinterChanged(PrinterType printerType)
        {
            switch(printerType)
            {
                case PrinterType.SII_RP_E10:
                    PrinterTypeName = "SII RP-E10 type printers data";
                    break;
                case PrinterType.SII_RP_F10_G10:
                    PrinterTypeName = "SII RP-F10, RP-G10 types printers data";
                    break;
            }
            GetNewPrinterData(printerType);
        }
    }
}
