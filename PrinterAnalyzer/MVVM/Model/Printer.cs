using PrinterAnalyzer.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using PrinterAnalyzer.MVVM.Model.PrinterProperties;
using PrinterAnalyzer.Enums;
using PrinterAnalyzer.MVVM.ViewModel;
using Windows.ApplicationModel.Activation;

namespace PrinterAnalyzer.MVVM.Model
{
    public class Printer : ObservableObject
    {
        public string MachineName { get; set; }

        public string Name { get; set; }

        public PrinterType printerType { get; set; }

        public delegate void PrinterAction(string action);

        public event PrinterAction printerAction;

        public Properties properties { get; set; }

        private Dictionary<string, string> _errors;
        public Dictionary<string, string> Errors
        {
            get
            {
                return _errors;
            }
            set
            {
                ErrorsList = "";
                    printerAction?.Invoke($"{Name} succesfully initiated!");
                    _errors = value;
                if (_errors.GetValueOrDefault("* Printer is offline") == "Yes")
                {
                    printerAction?.Invoke($"{Name} is offline");
                    IsOnline = "Offline";
                    WorkingColor = "#FFFF623E";
                    NoResponseError = "Printer is offline";
                    NoResponseVisibility = "Visible";
                }
                else
                {
                    IsOnline = "Online";
                    WorkingColor = "#00a310";
                    NoResponseVisibility = "Collapsed";
                }

                #region Battery Checking
                switch (_errors.GetValueOrDefault("Battery"))
                {
                    case "Full":
                        BatteryStatus = "BatteryHigh";
                        BatteryColor = "#f7941d";
                        break;
                    case "Medium":
                        BatteryStatus = "BatteryMedium";
                        BatteryColor = "#f7941d";
                        break;
                    case "Low":
                        BatteryStatus = "BatteryLow";
                        BatteryColor = "#f7941d";
                        break;
                    default:
                        BatteryStatus = "BatteryHigh";
                        BatteryColor = "#f7941d";
                        break;
                }
                #endregion

                #region VoltageChecking
                if (_errors.GetValueOrDefault("* Voltage error : ") == "Yes")
                {
                    printerAction?.Invoke($"{Name} has voltage error");
                    VoltageVisibility = "Visible";
                    VoltageError = "Error";
                    VoltageColor = "#FFFF623E";
                    IsOnline = "Errors";
                    WorkingColor = "#FFFF623E";
                    errorsList.Add($"Voltage error\n");
                }
                else if (_errors.GetValueOrDefault("* Voltage error : ") == "No")
                {
                    VoltageVisibility = "Visible";
                    VoltageError = "OK";
                    VoltageColor = "#00a310";
                }
                else
                {
                    VoltageVisibility = "Collapsed";
                }
                #endregion

                #region HeadTemperature
                if (_errors.GetValueOrDefault("* Head temp error : ") == "Yes")
                {
                    printerAction?.Invoke($"{Name} has temperature error");
                    HeadTemperatureVisibility = "Visible";
                    HeadTemperatureError = "Error";
                    HeadTemperatureColor = "#FFFF623E";
                    IsOnline = "Errors";
                    WorkingColor = "#FFFF623E";
                    errorsList.Add($"Temperature error\n");
                }
                else if (_errors.GetValueOrDefault("* Voltage error : ") == "No")
                {
                    HeadTemperatureVisibility = "Visible";
                    HeadTemperatureError = "OK";
                    HeadTemperatureColor = "#00a310";
                }
                else
                {
                    HeadTemperatureVisibility = "Collapsed";
                }
                #endregion

                #region FeedSwitchState
                if (_errors.GetValueOrDefault("* Paper feed status : ") == "Off")
                {
                    printerAction?.Invoke($"{Name} has feed error error");
                    FeedSwitchStateVisibility = "Visible";
                    FeedSwitchStateError = "Error";
                    FeedSwitchStateColor = "#FFFF623E";
                    IsOnline = "Errors";
                    WorkingColor = "#FFFF623E";
                    errorsList.Add($"Feed error error\n");
                }
                else if (_errors.GetValueOrDefault("* Paper feed status : ") == "On")
                {
                    FeedSwitchStateVisibility = "Visible";
                    FeedSwitchStateError = "OK";
                    FeedSwitchStateColor = "#00a310";
                }
                else
                {
                    FeedSwitchStateVisibility = "Collapsed";
                }
                #endregion

                #region AutocutterChecking
                if (_errors.GetValueOrDefault("* AutoCutter error : ") == "Yes")
                {
                    printerAction?.Invoke($"{Name} has autocutter error");
                    AutocutterVisibility = "Visible";
                    AutocutterError = "Error";
                    AutocutterColor = "#FFFF623E";
                    IsOnline = "Errors";
                    WorkingColor = "#FFFF623E";
                    errorsList.Add($"Autocutter error\n");
                }
                else if (_errors.GetValueOrDefault("* AutoCutter error : ") == "No")
                {
                    AutocutterVisibility = "Visible";
                    AutocutterError = "OK";
                    AutocutterColor = "#00a310";
                }
                else
                {
                    AutocutterVisibility = "Collapsed";
                }
                #endregion

                #region OutOfPaperChecking
                if (_errors.GetValueOrDefault("* Out-of-paper error : ") == "Yes")
                {
                    printerAction?.Invoke($"{Name} has out of paper error");
                    OutOfPaperVisibility = "Visible";
                    OutOfPaperError = "Error";
                    OutOfPaperColor = "#FFFF623E";
                    IsOnline = "Errors";
                    WorkingColor = "#FFFF623E";
                    errorsList.Add($"Out of paper error\n");
                }
                else if (_errors.GetValueOrDefault("* Out-of-paper error : ") == "No")
                {
                    OutOfPaperVisibility = "Visible";
                    OutOfPaperError = "OK";
                    OutOfPaperColor = "#00a310";
                }
                else
                {
                    OutOfPaperVisibility = "Collapsed";
                }
                #endregion

                #region PaperJamChecking
                if (_errors.GetValueOrDefault("* Mark paper jam error : ") == "Yes")
                {
                    printerAction?.Invoke($"{Name} has paper jam error");
                    PaperJamVisibility = "Visible";
                    PaperJamError = "Error";
                    PaperJamColor = "#FFFF623E";
                    IsOnline = "Errors";
                    WorkingColor = "#FFFF623E";
                    errorsList.Add($"Paper jam error\n");
                }
                else if (_errors.GetValueOrDefault("* Mark paper jam error : ") == "No")
                {
                    PaperJamVisibility = "Visible";
                    PaperJamError = "OK";
                    PaperJamColor = "#00a310";
                }
                else
                {
                    PaperJamVisibility = "Collapsed";
                }
                #endregion

                #region Cover/Platen open
                if (_errors.GetValueOrDefault("* Cover/Platen open error : ") == "Yes")
                {
                    printerAction?.Invoke($"{Name} has cover/platen open error");
                    CoverPlatenOpenErrorVisibility = "Visible";
                    CoverPlatenOpenError = "Error";
                    CoverPlatenOpenErrorColor = "#FFFF623E";
                    IsOnline = "Errors";
                    WorkingColor = "#FFFF623E";
                    errorsList.Add($"Cover/platen open error\n");
                }
                else if (_errors.GetValueOrDefault("* Cover/Platen open error : ") == "No")
                {
                    CoverPlatenOpenErrorVisibility = "Visible";
                    CoverPlatenOpenError = "OK";
                    CoverPlatenOpenErrorColor = "#00a310";
                }
                else
                {
                    CoverPlatenOpenErrorVisibility = "Collapsed";
                }
                #endregion

                #region Paper Near End
                if (_errors.GetValueOrDefault("* Paper-near-end error : ") == "Yes")
                {
                    PaperNearEndErrorVisibility = "Visible";
                    PaperNearEndError = "Warning";
                    PaperNearEndErrorColor = "#f7941d";
                }
                else if (_errors.GetValueOrDefault("* Paper-near-end error : ") == "No")
                {
                    PaperNearEndErrorVisibility = "Visible";
                    PaperNearEndError = "OK";
                    PaperNearEndErrorColor = "#FF47FF3E";
                }
                else
                {
                    PaperNearEndErrorVisibility = "Collapsed";
                }
                #endregion

                #region Drawer Sensor Error
                if (_errors.GetValueOrDefault("* Drawer sensor status : ") == "Off")
                {
                    printerAction?.Invoke($"{Name} has drawer sensor error");
                    DrawerSensorErrorVisibility = "Visible";
                    DrawerSensorError = "Error";
                    DrawerSensorErrorColor = "#FFFF623E";
                    IsOnline = "Errors";
                    WorkingColor = "#FFFF623E";
                    errorsList.Add($"Drawer sensor error\n");
                }
                else if (_errors.GetValueOrDefault("* Drawer sensor status : ") == "On")
                {
                    DrawerSensorErrorVisibility = "Visible";
                    DrawerSensorError = "OK";
                    DrawerSensorErrorColor = "#00a310";
                }
                else
                {
                    DrawerSensorErrorVisibility = "Collapsed";
                }
                #endregion

                if (IsOnline == "Errors")
                {
                    ErrorsListVisibility = "Visible";
                    for (int i = 0; i < errorsList.Count; i++)
                    {
                        ErrorsList += errorsList[i];
                    }
                    errorsList.Clear();
                    if (CurrentSettingsView == null)
                    {
                        NetworkData.GetInstance().SendStatus(printerType, IsOnline, ErrorsList);
                    }
                }
                else
                {
                    ErrorsListVisibility = "Collapsed";
                    //if (CurrentSettingsView == null)
                    //{
                        NetworkData.GetInstance().SendStatus(printerType, IsOnline, "-");
                    //}
                }
                

                OnPropertyChanged();
            }
        }

        private List<string> errorsList;

        private string _errorsList;
        public string ErrorsList
        {
            get
            {
                return _errorsList;
            }
            set
            {
                _errorsList = value;
                OnPropertyChanged();
            }
        }

        private string _errorsListVisibility;
        public string ErrorsListVisibility
        {
            get
            {
                return _errorsListVisibility;
            }
            set
            {
                _errorsListVisibility = value;
                OnPropertyChanged();
            }
        }

        private string _isOnline;
        public string IsOnline
        {
            get
            {
                return _isOnline;
            }
            set
            {
                _isOnline = value;
                OnPropertyChanged();
            }
        }

        private string _workingColor;

        [JsonIgnore]
        public string WorkingColor
        {
            get
            {
                return _workingColor;
            }
            set
            {
                _workingColor = value;
                OnPropertyChanged();
            }
        }

        #region NoResponse Error

        private string _noResponseError;

        public string NoResponseError
        {
            get { return _noResponseError; }
            set { _noResponseError = value; OnPropertyChanged(); }
        }

        private string _noResponseVisibility;

        public string NoResponseVisibility
        {
            get
            {
                return _noResponseVisibility;
            }
            set
            {
                _noResponseVisibility = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Battery Status

        private string _batteryStatus;

        public string BatteryStatus
        {
            get { return _batteryStatus; }
            set { _batteryStatus = value; OnPropertyChanged(); }
        }

        private string _batteryColor;

        public string BatteryColor
        {
            get
            {
                return _batteryColor;
            }
            set
            {
                _batteryColor = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Voltage Error

        private string _voltageError;

        public string VoltageError
        {
            get { return _voltageError; }
            set { _voltageError = value; OnPropertyChanged(); }
        }

        private string _voltageColor;

        public string VoltageColor
        {
            get
            {
                return _voltageColor;
            }
            set
            {
                _voltageColor = value;
                OnPropertyChanged();
            }
        }

        private string _voltageVisibility;

        public string VoltageVisibility
        {
            get
            {
                return _voltageVisibility;
            }
            set
            {
                _voltageVisibility = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Feed switch state Error

        private string _feedSwitchStateError;

        public string FeedSwitchStateError
        {
            get { return _feedSwitchStateError; }
            set { _feedSwitchStateError = value; OnPropertyChanged(); }
        }

        private string _feedSwitchStateColor;

        public string FeedSwitchStateColor
        {
            get
            {
                return _feedSwitchStateColor;
            }
            set
            {
                _feedSwitchStateColor = value;
                OnPropertyChanged();
            }
        }

        private string _feedSwitchStateVisibility;

        public string FeedSwitchStateVisibility
        {
            get
            {
                return _feedSwitchStateVisibility;
            }
            set
            {
                _feedSwitchStateVisibility = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Autocutter Error

        private string _autocutterError;

        public string AutocutterError
        {
            get { return _autocutterError; }
            set { _autocutterError = value; OnPropertyChanged(); }
        }

        private string _autocutterColor;

        public string AutocutterColor
        {
            get
            {
                return _autocutterColor;
            }
            set
            {
                _autocutterColor = value;
                OnPropertyChanged();
            }
        }

        private string _autocutterVisibility;

        public string AutocutterVisibility
        {
            get
            {
                return _autocutterVisibility;
            }
            set
            {
                _autocutterVisibility = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region HeadTemperature Error

        private string _headTemperatureError;

        public string HeadTemperatureError
        {
            get { return _headTemperatureError; }
            set { _headTemperatureError = value; OnPropertyChanged(); }
        }

        private string _headTemperatureColor;

        public string HeadTemperatureColor
        {
            get
            {
                return _headTemperatureColor;
            }
            set
            {
                _headTemperatureColor = value;
                OnPropertyChanged();
            }
        }

        private string _headTemperatureVisibility;

        public string HeadTemperatureVisibility
        {
            get
            {
                return _headTemperatureVisibility;
            }
            set
            {
                _headTemperatureVisibility = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Out Of Paper Error

        private string _outOfPaperError;

        public string OutOfPaperError
        {
            get { return _outOfPaperError; }
            set { _outOfPaperError = value; OnPropertyChanged(); }
        }

        private string _outOfPaperColor;

        public string OutOfPaperColor
        {
            get
            {
                return _outOfPaperColor;
            }
            set
            {
                _outOfPaperColor = value;
                OnPropertyChanged();
            }
        }

        private string _outOfPaperVisibility;

        public string OutOfPaperVisibility
        {
            get
            {
                return _outOfPaperVisibility;
            }
            set
            {
                _outOfPaperVisibility = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Paper Jam Error

        private string _paperJamError;

        public string PaperJamError
        {
            get { return _paperJamError; }
            set { _paperJamError = value; OnPropertyChanged(); }
        }

        private string _paperJamColor;

        public string PaperJamColor
        {
            get
            {
                return _paperJamColor;
            }
            set
            {
                _paperJamColor = value;
                OnPropertyChanged();
            }
        }

        private string _paperJamErrorVisibility;

        public string PaperJamVisibility
        {
            get
            {
                return _paperJamErrorVisibility;
            }
            set
            {
                _paperJamErrorVisibility = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Cover/Platen Open Error

        private string _coverPlatenOpenError;

        public string CoverPlatenOpenError
        {
            get { return _coverPlatenOpenError; }
            set { _coverPlatenOpenError = value; OnPropertyChanged(); }
        }

        private string _coverPlatenOpenErrorColor;

        public string CoverPlatenOpenErrorColor
        {
            get
            {
                return _coverPlatenOpenErrorColor;
            }
            set
            {
                _coverPlatenOpenErrorColor = value;
                OnPropertyChanged();
            }
        }

        private string _coverPlatenOpenErrorVisibility;

        public string CoverPlatenOpenErrorVisibility
        {
            get
            {
                return _coverPlatenOpenErrorVisibility;
            }
            set
            {
                _coverPlatenOpenErrorVisibility = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Paper Near End Error

        private string _paperNearEndError;

        public string PaperNearEndError
        {
            get { return _paperNearEndError; }
            set { _paperNearEndError = value; OnPropertyChanged(); }
        }

        private string _paperNearEndErrorColor;

        public string PaperNearEndErrorColor
        {
            get
            {
                return _paperNearEndErrorColor;
            }
            set
            {
                _paperNearEndError = value;
                OnPropertyChanged();
            }
        }

        private string _paperNearEndErrorVisibility;

        public string PaperNearEndErrorVisibility
        {
            get
            {
                return _paperNearEndErrorVisibility;
            }
            set
            {
                _paperNearEndErrorVisibility = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Drawer Sensor Error

        private string _drawerSensorError;

        public string DrawerSensorError
        {
            get { return _drawerSensorError; }
            set { _drawerSensorError = value; OnPropertyChanged(); }
        }

        private string _drawerSensorErrorColor;

        public string DrawerSensorErrorColor
        {
            get
            {
                return _drawerSensorErrorColor;
            }
            set
            {
                _drawerSensorErrorColor = value;
                OnPropertyChanged();
            }
        }

        private string _drawerSensorErrorVisibility;

        public string DrawerSensorErrorVisibility
        {
            get
            {
                return _drawerSensorErrorVisibility;
            }
            set
            {
                _drawerSensorErrorVisibility = value;
                OnPropertyChanged();
            }
        }

        #endregion



        private object _settingsView;

        public object CurrentSettingsView
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
        public Printer()
        {
            MachineName = Environment.MachineName;
        }

        public Printer(string name, PrinterType printerType, bool viewModelInit)
        {
            MachineName = Environment.MachineName;
            Name = name;
            errorsList = new List<string>();
            Errors = new Dictionary<string, string>();
            this.printerType = printerType;
            switch(printerType)
            {
                case PrinterType.SII_RP_F10:
                    if (viewModelInit)
                    {
                        var printer = this;
                        CurrentSettingsView = new PrinterSettingsF10G10ViewModel(ref printer);
                    }
                    properties = new Properties_RP_F10_G10();
                    break;
                case PrinterType.SII_RP_E10:
                    if (viewModelInit)
                    {
                        var printer = this;
                        CurrentSettingsView = new PrinterSettingsE10ViewModel(ref printer);
                    }
                    properties = new Properties_RP_E10();
                    break;
            }
        }
    }
}
