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
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

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

        public static DllFuncF10G10 m_DLLFuncB30L;

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
            m_DLLFuncB30L = new DllFuncF10G10();
            m_DLLFuncB30L.MyCallbackEvent += new DllFuncF10G10.callbackEventHandler(AddMsgCBStatus);
            CreatePrinterList();
            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(1000);
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
            var num = 0;
            for (int index = 0; index < System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count; index++)
            {
                string printerName = System.Drawing.Printing.PrinterSettings.InstalledPrinters[index];

                if (printerName.StartsWith("SII"))
                {
                    if (printerName.Contains("E10"))
                    {
                        PrintersMainList.Add(new Printer(printerName, PrinterType.SII_RP_E10, false));
                        m_DLLFuncE10.OpenSamp(PrintersMainList[num].Name);
                        m_DLLFuncE10.CallbackSamp(true);
                        num++;
                    }
                    else if (printerName.Contains("G10"))
                    {
                        PrintersMainList.Add(new Printer(printerName, PrinterType.SII_RP_F10, false));
                        m_DLLFuncF10G10.OpenPrinterSamp(PrintersMainList[num].Name);
                        m_DLLFuncF10G10.CallbackStatusSamp(true);
                        num++;
                    }
                    else if(printerName.Contains("B30"))
                    {
                        PrintersMainList.Add(new Printer(printerName, PrinterType.SII_MP_B30L, false));
                        m_DLLFuncF10G10.OpenPrinterSamp(PrintersMainList[num].Name);
                        m_DLLFuncF10G10.CallbackStatusSamp(true);
                        num++;
                    }
                }
            }
        }

        private void GetPrintersSettings()
        {
            for (int i = 0; i < PrintersMainList.Count; i++) 
            {
                switch(PrintersMainList[i].printerType)
                {
                    case PrinterType.SII_RP_E10:
                        (PrintersMainList[i].properties as Properties_RP_E10).CurrentProperties = m_DLLFuncE10.GetCurrentPrinterSettings(PrintersMainList[i].properties, PrintersMainList[i].Name, PrintersMainList[i].printerType);
                        for (int j = 0; j < PrintersList.Count; j++)
                        {
                            if (PrintersMainList[i].Name == PrintersList[j].Name)
                            {
                                PrintersList[j].properties = PrintersMainList[i].properties;
                            }
                        }
                        NetworkData.GetInstance().SendDefaultSettings(PrinterType.SII_RP_E10, (PrintersMainList[i].properties as Properties_RP_E10).GetDefaultPrinterSettings());
                        if (NetworkData.GetInstance().GetCommands(PrinterType.SII_RP_E10).Result != "ok")
                        {
                            JObject jObject = JObject.Parse(NetworkData.GetInstance().GetCommands(PrinterType.SII_RP_E10).Result);
                            NetworkData.GetInstance().printersId.Add(PrinterType.SII_RP_E10, (string)jObject["internalID"]);

                            if (jObject.ContainsKey("Print") && NetworkData.GetInstance().CanPrintPage == 0)
                            {
                                NetworkData.GetInstance().CanPrintPage++;
                                PrintDocument printDoc = new PrintDocument();
                                printDoc.PrinterSettings.PrinterName = PrintersMainList[i].Name;
                                printDoc.Print();
                                NetworkData.GetInstance().SendInfoAboutPrint(PrinterType.SII_RP_E10, NetworkData.GetInstance().printersId.GetValueOrDefault(PrinterType.SII_RP_E10));
                                NetworkData.GetInstance().printersId.Remove(PrinterType.SII_RP_E10);
                            }
                            else
                            {
                                string settings = (string)jObject["settings"];
                                Dictionary<PropertyType, int> settingsList = JsonConvert.DeserializeObject<Dictionary<PropertyType, int>>(settings);
                                m_DLLFuncE10.ChangeParameters(PrintersMainList[i].properties, settingsList, PrintersMainList[i].Name, PrinterType.SII_RP_E10);
                            }
                        }
                        else
                        {
                            NetworkData.GetInstance().CanPrintPage = 0;
                        }
                        if ((PrintersMainList[i].properties as Properties_RP_E10).ChangesDone)
                        {
                            if (NetworkData.GetInstance().printersId.Count > 0 && NetworkData.GetInstance().printersId.ContainsKey(PrinterType.SII_RP_E10))
                            {
                                var printersID = NetworkData.GetInstance().printersId.GetValueOrDefault(PrinterType.SII_RP_E10);
                                NetworkData.GetInstance().printersId.Remove(PrinterType.SII_RP_E10);
                                NetworkData.GetInstance().SendInfoAboutChanges(PrinterType.SII_RP_E10, printersID);
                            }
                            else
                                NetworkData.GetInstance().SendSettings(PrinterType.SII_RP_E10, (PrintersMainList[i].properties as Properties_RP_E10).CurrentProperties);
                        }






                       // if ((PrintersMainList[i].properties as Properties_RP_E10).ChangesDone)
                       // {
                       //     NetworkData.GetInstance().SendSettings(PrinterType.SII_RP_E10, (PrintersMainList[i].properties as Properties_RP_E10).CurrentProperties);
                       // }
                        break;
                    case PrinterType.SII_RP_F10:
                        (PrintersMainList[i].properties as Properties_RP_F10_G10).CurrentProperties = m_DLLFuncF10G10.GetCurrentPrinterSettings(PrintersMainList[i].properties, PrintersMainList[i].Name, PrintersMainList[i].printerType);
                        for (int j = 0; j < PrintersList.Count; j++)
                        {
                            if (PrintersMainList[i].Name == PrintersList[j].Name)
                            {
                                PrintersList[j].properties = PrintersMainList[i].properties;
                            }
                        }
                        NetworkData.GetInstance().SendDefaultSettings(PrinterType.SII_RP_F10, (PrintersMainList[i].properties as Properties_RP_F10_G10).GetDefaultPrinterSettings());
                        if (NetworkData.GetInstance().GetCommands(PrinterType.SII_RP_F10).Result != "ok")
                        {
                            JObject jObject = JObject.Parse(NetworkData.GetInstance().GetCommands(PrinterType.SII_RP_F10).Result);
                            NetworkData.GetInstance().printersId.Add(PrinterType.SII_RP_F10,(string)jObject["internalID"]);

                            if (jObject.ContainsKey("Print") && NetworkData.GetInstance().CanPrintPage == 0)
                            {
                                NetworkData.GetInstance().CanPrintPage++;
                                PrintDocument printDoc = new PrintDocument();
                                printDoc.PrinterSettings.PrinterName = PrintersMainList[i].Name;
                                printDoc.Print();
                                NetworkData.GetInstance().SendInfoAboutPrint(PrinterType.SII_RP_F10, NetworkData.GetInstance().printersId.GetValueOrDefault(PrinterType.SII_RP_F10));
                                NetworkData.GetInstance().printersId.Remove(PrinterType.SII_RP_F10);
                            }
                            else
                            {
                                string settings = (string)jObject["settings"];
                                Dictionary<PropertyType, int> settingsList = JsonConvert.DeserializeObject<Dictionary<PropertyType, int>>(settings);
                                m_DLLFuncF10G10.ChangeParameters(PrintersMainList[i].properties, settingsList, PrintersMainList[i].Name, PrinterType.SII_RP_F10);
                            }
                        }
                        else
                        {
                            NetworkData.GetInstance().CanPrintPage = 0;
                        }
                        if ((PrintersMainList[i].properties as Properties_RP_F10_G10).ChangesDone)
                        {
                            if(NetworkData.GetInstance().printersId.Count > 0 && NetworkData.GetInstance().printersId.ContainsKey(PrinterType.SII_RP_F10)) 
                            {
                                var printersID = NetworkData.GetInstance().printersId.GetValueOrDefault(PrinterType.SII_RP_F10);
                                NetworkData.GetInstance().printersId.Remove(PrinterType.SII_RP_F10);
                                NetworkData.GetInstance().SendInfoAboutChanges(PrinterType.SII_RP_F10, printersID);
                            }
                            else
                                NetworkData.GetInstance().SendSettings(PrinterType.SII_RP_F10, (PrintersMainList[i].properties as Properties_RP_F10_G10).CurrentProperties);
                        }
                        break;


                    case PrinterType.SII_MP_B30L:
                        break;
                }
            }
        }

        private void AddNewAction(string action)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                ActionList.Insert(0, new PrinterAction(action, "[" + DateTime.Now.ToString() + "]:  ", "Printer"));
            });
        }


        private void AddMsgCBStatus(Dictionary<string, string> msg, PrinterType printerType)
        {
            for (int i = 0; i < PrintersMainList.Count; i++) 
            {
                if (PrintersMainList[i].printerType == printerType)
                {
                    PrintersMainList[i].Errors = msg;
                    for(int j=0;j<PrintersList.Count;j++) 
                    {
                        if (PrintersMainList[i].Name == PrintersList[j].Name) 
                        {
                            PrintersList[j].Errors = PrintersMainList[i].Errors;
                        }
                    }
                }
            }
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
                            PrintersList[count].Errors = PrintersMainList[i].Errors;
                            count++;
                        }
                        break;
                    case PrinterType.SII_RP_F10:
                        if (PrintersMainList[i].Name.Contains("F10") || PrintersMainList[i].Name.Contains("G10"))
                        {
                            PrintersList.Add(new Printer(PrintersMainList[i].Name, PrinterType.SII_RP_F10, true));
                            PrintersList[count].printerAction += AddNewAction;
                            PrintersList[count].Errors = PrintersMainList[i].Errors;
                            count++;
                        }
                        break;
                    case PrinterType.SII_MP_B30L:
                        if (PrintersMainList[i].Name.Contains("B30"))
                        {
                            PrintersList.Add(new Printer(PrintersMainList[i].Name, PrinterType.SII_MP_B30L, true));
                            PrintersList[count].printerAction += AddNewAction;
                            PrintersList[count].Errors = PrintersMainList[i].Errors;
                            count++;
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
                case PrinterType.SII_RP_F10:
                    PrinterTypeName = "SII RP-F10, RP-G10 types printers data";
                    break;
                case PrinterType.SII_MP_B30L:
                    PrinterTypeName = "SII MP-B30L types printers data";
                    break;
            }
            GetNewPrinterData(printerType);
        }
    }
}
