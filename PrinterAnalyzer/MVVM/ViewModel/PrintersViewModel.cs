using PrinterAnalyzer.Communication.RP_E10;
using PrinterAnalyzer.Communication.RP_F10_G10;
using PrinterAnalyzer.Core;
using PrinterAnalyzer.Enums;
using PrinterAnalyzer.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Printing;
using System.Windows;
using System.Windows.Forms;
using PrinterAnalyzer.MVVM.Model.PrinterProperties;
using System.Threading;

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
            set { _printerList = value; OnPropertyChanged(); }
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

        public static DllFuncE10 m_DLLFuncE10;

        public static DllFuncF10G10 m_DLLFuncF10G10;

        public PrintersViewModel()
        {
            ActionList = new ObservableCollection<PrinterAction>();
            PrintersList = new ObservableCollection<Printer>();
            PrintersMainList = new List<Printer>();
            m_DLLFuncE10 = new DllFuncE10();
            m_DLLFuncE10.myCallbackEvent += new DllFuncE10.callbackEventHandler(AddMsgCBStatus);
            m_DLLFuncE10.CallbackSamp(false);
            m_DLLFuncF10G10 = new DllFuncF10G10();
            m_DLLFuncF10G10.MyCallbackEvent += new DllFuncF10G10.callbackEventHandler(AddMsgCBStatus);
            m_DLLFuncF10G10.CallbackStatusSamp(false);
            CreatePrinterList();
            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(3000);
                    GetPrintersSettings();
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }

        public delegate void Changes();

        public static event Changes SettingsChanges;



        private void CreatePrinterList()
        {
            for (int index = 0; index < System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count; index++)
            {
                string printerName = System.Drawing.Printing.PrinterSettings.InstalledPrinters[index];

                if (printerName.StartsWith("SII"))
                {
                    if (printerName.Contains("E10"))
                    {
                        PrintersMainList.Add(new Printer(printerName, PrinterType.SII_RP_E10, false));
                    }
                    else if (printerName.Contains("G10"))
                    {
                        PrintersMainList.Add(new Printer(printerName, PrinterType.SII_RP_F10_G10, false));
                    }
                }
            }
        }

        private void GetPrintersSettings()
        {
            for(int i=0;i<PrintersMainList.Count;i++) 
            {
                switch(PrintersMainList[i].printerType)
                {
                    case PrinterType.SII_RP_E10:
                        (PrintersMainList[i].properties).CurrentProperties = m_DLLFuncF10G10.GetCurrentPrinterSettings(PrintersMainList[i].properties, PrintersMainList[i].Name, PrintersMainList[i].printerType);
                        for (int j = 0; j < PrintersList.Count; j++)
                        {
                            if (PrintersMainList[i].Name == PrintersList[j].Name)
                            {
                                PrintersList[j].properties = PrintersMainList[i].properties;
                            }
                        }
                        break;
                    case PrinterType.SII_RP_F10_G10:
                        (PrintersMainList[i].properties as Properties_RP_F10_G10).CurrentProperties = m_DLLFuncF10G10.GetCurrentPrinterSettings(PrintersMainList[i].properties, PrintersMainList[i].Name, PrintersMainList[i].printerType);
                        for (int j = 0; j < PrintersList.Count; j++)
                        {
                            if (PrintersMainList[i].Name == PrintersList[j].Name)
                            {
                                PrintersList[j].properties = PrintersMainList[i].properties;
                            }
                        }
                        break;
                }
                /*if (PrintersMainList[i].printerType == PrinterType.SII_RP_F10_G10)
                {
                    (PrintersMainList[i].properties as Properties_RP_F10_G10).CurrentProperties = m_DLLFuncF10G10.GetCurrentPrinterSettings(PrintersMainList[i].properties, PrintersMainList[i].Name, PrintersMainList[i].printerType);
                    for (int j = 0; j < PrintersList.Count; j++) 
                    {
                        if (PrintersMainList[i].Name == PrintersList[j].Name)
                        {
                            PrintersList[j].properties = PrintersMainList[i].properties;
                        }
                    }
                }*/
            }
        }

        private void AddNewAction(string action)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                ActionList.Insert(0, new PrinterAction(action, "[" + DateTime.Now.ToString() + "]:  ", "Printer"));
            });
        }


        private void AddMsgCBStatus(Dictionary<string, string> msg)
        {
            PrintersList[0].Errors = msg;
        }

        public void GetNewPrinterData(PrinterType printerType)
        {
            PrintersList.Clear();
            ActionList.Clear();
            if (PrintersMainList.Count < 1)
                return;
            int count = 0;
            for (int i = 0; i < PrintersMainList.Count; i++)
            {
                switch(printerType)
                {
                    case PrinterType.SII_RP_E10:
                        if (PrintersMainList[i].Name.Contains("E10"))
                        {
                            PrintersList.Add(new Printer(PrintersMainList[i].Name, PrinterType.SII_RP_E10, true));
                            PrintersList[count].printerAction += AddNewAction;
                            count++;
                            m_DLLFuncE10.OpenSamp(PrintersMainList[i].Name);
                            m_DLLFuncE10.CallbackSamp(true);
                        }
                        break;
                    case PrinterType.SII_RP_F10_G10:
                        if (PrintersMainList[i].Name.Contains("F10") || PrintersMainList[i].Name.Contains("G10"))
                        {
                            PrintersList.Add(new Printer(PrintersMainList[i].Name, PrinterType.SII_RP_F10_G10, true));
                            PrintersList[count].printerAction += AddNewAction;
                            count++;
                            m_DLLFuncF10G10.OpenPrinterSamp(PrintersMainList[i].Name);
                            m_DLLFuncF10G10.CallbackStatusSamp(true);
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
