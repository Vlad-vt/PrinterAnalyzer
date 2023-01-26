﻿using PrinterAnalyzer.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace PrinterAnalyzer.MVVM.Model
{
    public class Printer : ObservableObject
    {
        public string MachineName { get; set; }

        public string Name { get; set; }

        public delegate void PrinterAction(string action);

        public event PrinterAction printerAction;

        private Dictionary<string, string> _errors;
        public Dictionary<string, string> Errors
        {
            get
            {
                return _errors;
            }
            set
            {
                if (_errors == null)
                {
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
                        WorkingColor = "#FF47FF3E";
                        NoResponseVisibility = "Collapsed";
                    }

                    #region VoltageChecking
                    if (_errors.GetValueOrDefault("* Voltage error : ") == "Yes")
                    {
                        printerAction?.Invoke($"{Name} has voltage error");
                        VoltageVisibility = "Visible";
                        VoltageError = "* Voltage error : " + _errors.GetValueOrDefault("* Voltage error : ");
                        VoltageColor = "#FFFF623E";
                    }
                    else if (_errors.GetValueOrDefault("* Voltage error : ") == "No")
                    {
                        VoltageVisibility = "Visible";
                        VoltageError = "* Voltage error : " + _errors.GetValueOrDefault("* Voltage error : ");
                        VoltageColor = "#FF47FF3E";
                    }
                    else
                    {
                        VoltageVisibility = "Collapsed";
                    }
                    #endregion

                    #region AutocutterChecking
                    if (_errors.GetValueOrDefault("* AutoCutter error : ") == "Yes")
                    {
                        printerAction?.Invoke($"{Name} has autocutter error");
                        AutocutterVisibility = "Visible";
                        AutocutterError = "* AutoCutter error : " + _errors.GetValueOrDefault("* AutoCutter error : ");
                        AutocutterColor = "#FFFF623E";
                    }
                    else if (_errors.GetValueOrDefault("* AutoCutter error : ") == "No")
                    {
                        AutocutterVisibility = "Visible";
                        AutocutterError = "* AutoCutter error : " + _errors.GetValueOrDefault("* AutoCutter error : ");
                        AutocutterColor = "#FF47FF3E";
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
                        OutOfPaperError = "* Out-of-paper error : " + _errors.GetValueOrDefault("* Out-of-paper error : ");
                        OutOfPaperColor = "#FFFF623E";
                    }
                    else if (_errors.GetValueOrDefault("* Out-of-paper error : ") == "No")
                    {
                        OutOfPaperVisibility = "Visible";
                        OutOfPaperError = "* Out-of-paper error : " + _errors.GetValueOrDefault("* Out-of-paper error : ");
                        OutOfPaperColor = "#FF47FF3E";
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
                        PaperJamError = "* Mark paper jam error : " + _errors.GetValueOrDefault("* Mark paper jam error : ");
                        PaperJamColor = "#FFFF623E";
                    }
                    else if (_errors.GetValueOrDefault("* Mark paper jam error : ") == "No")
                    {
                        PaperJamVisibility = "Visible";
                        PaperJamError = "* Mark paper jam error : " + _errors.GetValueOrDefault("* Mark paper jam error : ");
                        PaperJamColor = "#FF47FF3E";
                    }
                    else
                    {
                        PaperJamVisibility = "Collapsed";
                    }
                    #endregion

                    #region Paper Feed Error
                    if (_errors.GetValueOrDefault("* Paper feed status : ") == "Off")
                    {
                        printerAction?.Invoke($"{Name} has paper feed status error");
                        PaperFeedStatusVisibility = "Visible";
                        PaperFeedStatusError = "* Paper feed status : " + _errors.GetValueOrDefault("* Paper feed status : ");
                        PaperFeedStatusErrorColor = "#FFFF623E";
                    }
                    else if (_errors.GetValueOrDefault("* Paper feed status : ") == "On")
                    {
                        PaperFeedStatusVisibility = "Visible";
                        PaperFeedStatusError = "* Paper feed status : " + _errors.GetValueOrDefault("* Paper feed status : ");
                        PaperFeedStatusErrorColor = "#FF47FF3E";
                    }
                    else
                    {
                        PaperFeedStatusVisibility = "Collapsed";
                    }
                    #endregion

                    #region Cover/Platen open
                    if (_errors.GetValueOrDefault("* Cover/Platen open error : ") == "Yes")
                    {
                        printerAction?.Invoke($"{Name} has cover/platen open error");
                        CoverPlatenOpenErrorVisibility = "Visible";
                        CoverPlatenOpenError = "* Cover/Platen open error : " + _errors.GetValueOrDefault("* Cover/Platen open error : ");
                        CoverPlatenOpenErrorColor = "#FFFF623E";
                    }
                    else if (_errors.GetValueOrDefault("* Cover/Platen open error : ") == "No")
                    {
                        CoverPlatenOpenErrorVisibility = "Visible";
                        CoverPlatenOpenError = "* Cover/Platen open error : " + _errors.GetValueOrDefault("* Cover/Platen open error : ");
                        CoverPlatenOpenErrorColor = "#FF47FF3E";
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
                        PaperNearEndError = "* Paper-near-end error : " + _errors.GetValueOrDefault("* Paper-near-end error : ");
                    }
                    else if (_errors.GetValueOrDefault("* Paper-near-end error : ") == "No")
                    {
                        PaperNearEndErrorVisibility = "Visible";
                        PaperNearEndError = "* Paper-near-end error : " + _errors.GetValueOrDefault("* Paper-near-end error : ");
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
                        DrawerSensorError = "* Drawer sensor status : " + _errors.GetValueOrDefault("* Drawer sensor status : ");
                        DrawerSensorErrorColor = "#FFFF623E";
                    }
                    else if (_errors.GetValueOrDefault("* Drawer sensor status : ") == "On")
                    {
                        DrawerSensorErrorVisibility = "Visible";
                        DrawerSensorError = "* Drawer sensor status : " + _errors.GetValueOrDefault("* Drawer sensor status : ");
                        DrawerSensorErrorColor = "#FF47FF3E";
                    }
                    else
                    {
                        DrawerSensorErrorVisibility = "Collapsed";
                    }
                    #endregion
                }
                else
                {
                    if (_errors.GetValueOrDefault("* Printer is offline") != value.GetValueOrDefault("* Printer is offline") && value.GetValueOrDefault("* Printer is offline") == "Yes")
                    {
                        printerAction?.Invoke($"{Name} is offline");
                        IsOnline = "Offline";
                        WorkingColor = "#FFFF623E";
                        NoResponseError = "Printer is offline";
                        NoResponseVisibility = "Visible";
                    }
                    else if(_errors.GetValueOrDefault("* Printer is offline") != value.GetValueOrDefault("* Printer is offline") && value.GetValueOrDefault("* Printer is offline") == "No")
                    {
                        printerAction?.Invoke($"SOLVED --{Name} is offline--");
                        IsOnline = "Online";
                        WorkingColor = "#FF47FF3E";
                        NoResponseVisibility = "Collapsed";
                    }

                    #region VoltageChecking
                    if (_errors.GetValueOrDefault("* Voltage error : ") != value.GetValueOrDefault("* Voltage error : ") && value.GetValueOrDefault("* Voltage error : ") == "Yes")
                    {
                        printerAction?.Invoke($"{Name} has voltage error");
                        VoltageVisibility = "Visible";
                        VoltageError = "* Voltage error : " + _errors.GetValueOrDefault("* Voltage error : ");
                        VoltageColor = "#FFFF623E";
                    }
                    else if (_errors.GetValueOrDefault("* Voltage error : ") != value.GetValueOrDefault("* Voltage error : ") && value.GetValueOrDefault("* Voltage error : ") == "No")
                    {
                        printerAction?.Invoke($"SOLVED --{Name} has voltage error--");
                        VoltageVisibility = "Visible";
                        VoltageError = "* Voltage error : " + _errors.GetValueOrDefault("* Voltage error : ");
                        VoltageColor = "#FF47FF3E";
                    }
                    else
                    {
                        VoltageVisibility = "Collapsed";
                    }
                    #endregion

                    #region AutocutterChecking
                    if (_errors.GetValueOrDefault("* AutoCutter error : ") == "Yes")
                    {
                        AutocutterVisibility = "Visible";
                        AutocutterError = "* AutoCutter error : " + _errors.GetValueOrDefault("* AutoCutter error : ");
                        AutocutterColor = "#FFFF623E";
                    }
                    else if (_errors.GetValueOrDefault("* AutoCutter error : ") == "No")
                    {
                        AutocutterVisibility = "Visible";
                        AutocutterError = "* AutoCutter error : " + _errors.GetValueOrDefault("* AutoCutter error : ");
                        AutocutterColor = "#FF47FF3E";
                    }
                    else
                    {
                        AutocutterVisibility = "Collapsed";
                    }
                    #endregion

                    #region OutOfPaperChecking
                    if (_errors.GetValueOrDefault("* Out-of-paper error : ") == "Yes")
                    {
                        OutOfPaperVisibility = "Visible";
                        OutOfPaperError = "* Out-of-paper error : " + _errors.GetValueOrDefault("* Out-of-paper error : ");
                        OutOfPaperColor = "#FFFF623E";
                    }
                    else if (_errors.GetValueOrDefault("* Out-of-paper error : ") == "No")
                    {
                        OutOfPaperVisibility = "Visible";
                        OutOfPaperError = "* Out-of-paper error : " + _errors.GetValueOrDefault("* Out-of-paper error : ");
                        OutOfPaperColor = "#FF47FF3E";
                    }
                    else
                    {
                        OutOfPaperVisibility = "Collapsed";
                    }
                    #endregion

                    #region PaperJamChecking
                    if (_errors.GetValueOrDefault("* Mark paper jam error : ") == "Yes")
                    {
                        PaperJamVisibility = "Visible";
                        PaperJamError = "* Mark paper jam error : " + _errors.GetValueOrDefault("* Mark paper jam error : ");
                        PaperJamColor = "#FFFF623E";
                    }
                    else if (_errors.GetValueOrDefault("* Mark paper jam error : ") == "No")
                    {
                        PaperJamVisibility = "Visible";
                        PaperJamError = "* Mark paper jam error : " + _errors.GetValueOrDefault("* Mark paper jam error : ");
                        PaperJamColor = "#FF47FF3E";
                    }
                    else
                    {
                        PaperJamVisibility = "Collapsed";
                    }
                    #endregion

                    #region Paper Feed Error
                    if (_errors.GetValueOrDefault("* Paper feed status : ") == "Off")
                    {
                        PaperFeedStatusVisibility = "Visible";
                        PaperFeedStatusError = "* Paper feed status : " + _errors.GetValueOrDefault("* Paper feed status : ");
                        PaperFeedStatusErrorColor = "#FFFF623E";
                    }
                    else if (_errors.GetValueOrDefault("* Paper feed status : ") == "On")
                    {
                        PaperFeedStatusVisibility = "Visible";
                        PaperFeedStatusError = "* Paper feed status : " + _errors.GetValueOrDefault("* Paper feed status : ");
                        PaperFeedStatusErrorColor = "#FF47FF3E";
                    }
                    else
                    {
                        PaperFeedStatusVisibility = "Collapsed";
                    }
                    #endregion

                    #region Cover/Platen open
                    if (_errors.GetValueOrDefault("* Cover/Platen open error : ") == "Yes")
                    {
                        CoverPlatenOpenErrorVisibility = "Visible";
                        CoverPlatenOpenError = "* Cover/Platen open error : " + _errors.GetValueOrDefault("* Cover/Platen open error : ");
                        CoverPlatenOpenErrorColor = "#FFFF623E";
                    }
                    else if (_errors.GetValueOrDefault("* Cover/Platen open error : ") == "No")
                    {
                        CoverPlatenOpenErrorVisibility = "Visible";
                        CoverPlatenOpenError = "* Cover/Platen open error : " + _errors.GetValueOrDefault("* Cover/Platen open error : ");
                        CoverPlatenOpenErrorColor = "#FF47FF3E";
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
                        PaperNearEndError = "* Paper-near-end error : " + _errors.GetValueOrDefault("* Paper-near-end error : ");
                        PaperNearEndErrorColor = "#FFFF623E";
                    }
                    else if (_errors.GetValueOrDefault("* Paper-near-end error : ") == "No")
                    {
                        PaperNearEndErrorVisibility = "Visible";
                        PaperNearEndError = "* Paper-near-end error : " + _errors.GetValueOrDefault("* Paper-near-end error : ");
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
                        DrawerSensorErrorVisibility = "Visible";
                        DrawerSensorError = "* Drawer sensor status : " + _errors.GetValueOrDefault("* Drawer sensor status : ");
                        DrawerSensorErrorColor = "#FFFF623E";
                    }
                    else if (_errors.GetValueOrDefault("* Drawer sensor status : ") == "On")
                    {
                        DrawerSensorErrorVisibility = "Visible";
                        DrawerSensorError = "* Drawer sensor status : " + _errors.GetValueOrDefault("* Drawer sensor status : ");
                        DrawerSensorErrorColor = "#FF47FF3E";
                    }
                    else
                    {
                        DrawerSensorErrorVisibility = "Collapsed";
                    }
                    #endregion
                }

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
                _paperJamError = value;
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
                _coverPlatenOpenError = value;
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

        #region Paper feed status Error

        private string _paperFeedStatusError;

        public string PaperFeedStatusError
        {
            get { return _paperFeedStatusError; }
            set { _paperFeedStatusError = value; OnPropertyChanged(); }
        }

        private string _paperFeedStatusErrorColor;

        public string PaperFeedStatusErrorColor
        {
            get
            {
                return _paperFeedStatusErrorColor;
            }
            set
            {
                _paperFeedStatusErrorColor = value;
                OnPropertyChanged();
            }
        }

        private string _paperFeedStatusVisibility;

        public string PaperFeedStatusVisibility
        {
            get
            {
                return _paperFeedStatusVisibility;
            }
            set
            {
                _paperFeedStatusVisibility = value;
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

        public Printer()
        {
            MachineName = Environment.MachineName;
        }

        public Printer(string name)
        {
            MachineName = Environment.MachineName;
            Name = name;
        }
    }
}
