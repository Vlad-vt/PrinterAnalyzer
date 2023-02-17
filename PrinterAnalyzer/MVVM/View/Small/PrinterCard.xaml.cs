using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrinterAnalyzer.MVVM.View.Small
{
    /// <summary>
    /// Interaction logic for PrinterCard.xaml
    /// </summary>
    public partial class PrinterCard : UserControl
    {
        public PrinterCard()
        {
            InitializeComponent();
        }

        #region Battery Charge
        public string BatteryChargeStatus
        {
            get
            {
                return (string)GetValue(BatteryChargeStatusProperty);
            }
            set
            {
                SetValue(BatteryChargeStatusProperty, value);
            }
        }
        public static readonly DependencyProperty BatteryChargeStatusProperty = DependencyProperty.Register("BatteryChargeStatus", typeof(string), typeof(PrinterCard));

        public string BatteryChargeColor
        {
            get
            {
                return (string)GetValue(BatteryChargeColorProperty);
            }
            set
            {
                SetValue(BatteryChargeColorProperty, value);
            }
        }
        public static readonly DependencyProperty BatteryChargeColorProperty = DependencyProperty.Register("BatteryChargeColor", typeof(string), typeof(PrinterCard));

        #endregion

        #region Default Properties
        public string Title
        {
            get
            {
                return (string)GetValue(TitleProperty);
            }
            set
            {
                SetValue(TitleProperty, value);
            }
        }
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(PrinterCard));

        public string NetworkData
        {
            get
            {
                return (string)GetValue(NetworkDataProperty);
            }
            set
            {
                SetValue(NetworkDataProperty, value);
            }
        }
        public static readonly DependencyProperty NetworkDataProperty = DependencyProperty.Register("NetworkData", typeof(string), typeof(PrinterCard));

        public string WorkingStatus
        {
            get
            {
                return (string)GetValue(WorkingStatusProperty);
            }
            set
            {
                SetValue(WorkingStatusProperty, value);
            }
        }
        public static readonly DependencyProperty WorkingStatusProperty = DependencyProperty.Register("WorkingStatus", typeof(string), typeof(PrinterCard));

        public string WorkingIcon
        {
            get
            {
                return (string)GetValue(WorkingIconProperty);
            }
            set
            {
                SetValue(WorkingIconProperty, value);
            }
        }
        public static readonly DependencyProperty WorkingIconProperty = DependencyProperty.Register("WorkingIcon", typeof(string), typeof(PrinterCard));

        public string Number
        {
            get
            {
                return (string)GetValue(NumberProperty);
            }
            set
            {
                SetValue(NumberProperty, value);
            }
        }
        public static readonly DependencyProperty NumberProperty = DependencyProperty.Register("Number", typeof(string), typeof(PrinterCard));

        #endregion

        #region Voltage
        public string VoltageError
        {
            get
            {
                return (string)GetValue(VoltageProperty);
            }
            set
            {
                SetValue(VoltageProperty, value);
            }
        }
        public static readonly DependencyProperty VoltageProperty = DependencyProperty.Register("VoltageError", typeof(string), typeof(PrinterCard));

        public string VoltageForeground
        {
            get
            {
                return (string)GetValue(VoltageForegroundProperty);
            }
            set
            {
                SetValue(VoltageForegroundProperty, value);
            }
        }
        public static readonly DependencyProperty VoltageForegroundProperty = DependencyProperty.Register("VoltageForeground", typeof(string), typeof(PrinterCard));

        public string VoltageVisibility
        {
            get
            {
                return (string)GetValue(VoltageVisibilityProperty);
            }
            set
            {
                SetValue(VoltageVisibilityProperty, value);
            }
        }
        public static readonly DependencyProperty VoltageVisibilityProperty = DependencyProperty.Register("VoltageVisibility", typeof(string), typeof(PrinterCard));

        #endregion

        #region HeadError
        public string HeadError
        {
            get
            {
                return (string)GetValue(HeadErrorProperty);
            }
            set
            {
                SetValue(HeadErrorProperty, value);
            }
        }
        public static readonly DependencyProperty HeadErrorProperty = DependencyProperty.Register("HeadError", typeof(string), typeof(PrinterCard));

        public string HeadErrorForeground
        {
            get
            {
                return (string)GetValue(HeadErrorForegroundProperty);
            }
            set
            {
                SetValue(HeadErrorForegroundProperty, value);
            }
        }
        public static readonly DependencyProperty HeadErrorForegroundProperty = DependencyProperty.Register("HeadErrorForeground", typeof(string), typeof(PrinterCard));

        public string HeadErrorVisibility
        {
            get
            {
                return (string)GetValue(HeadErrorVisibilityProperty);
            }
            set
            {
                SetValue(HeadErrorVisibilityProperty, value);
            }
        }
        public static readonly DependencyProperty HeadErrorVisibilityProperty = DependencyProperty.Register("HeadErrorVisibility", typeof(string), typeof(PrinterCard));

        #endregion

        #region Autocutter
        public string AutocutterError
        {
            get
            {
                return (string)GetValue(AutocutterErrorProperty);
            }
            set
            {
                SetValue(AutocutterErrorProperty, value);
            }
        }
        public static readonly DependencyProperty AutocutterErrorProperty = DependencyProperty.Register("AutocutterError", typeof(string), typeof(PrinterCard));

        public string AutocutterForeground
        {
            get
            {
                return (string)GetValue(AutocutterForegroundProperty);
            }
            set
            {
                SetValue(AutocutterForegroundProperty, value);
            }
        }
        public static readonly DependencyProperty AutocutterForegroundProperty = DependencyProperty.Register("AutocutterForeground", typeof(string), typeof(PrinterCard));

        public string AutocutterVisibility
        {
            get
            {
                return (string)GetValue(AutocutterVisibilityProperty);
            }
            set
            {
                SetValue(AutocutterVisibilityProperty, value);
            }
        }
        public static readonly DependencyProperty AutocutterVisibilityProperty = DependencyProperty.Register("AutocutterVisibility", typeof(string), typeof(PrinterCard));


        #endregion

        #region Out-Of-Paper
        public string OutOfPaperError
        {
            get
            {
                return (string)GetValue(OutOfPaperErrorProperty);
            }
            set
            {
                SetValue(OutOfPaperErrorProperty, value);
            }
        }
        public static readonly DependencyProperty OutOfPaperErrorProperty = DependencyProperty.Register("OutOfPaperError", typeof(string), typeof(PrinterCard));

        public string OutOfPaperForeground
        {
            get
            {
                return (string)GetValue(OutOfPaperForegroundProperty);
            }
            set
            {
                SetValue(OutOfPaperForegroundProperty, value);
            }
        }
        public static readonly DependencyProperty OutOfPaperForegroundProperty = DependencyProperty.Register("OutOfPaperForeground", typeof(string), typeof(PrinterCard));

        public string OutOfPaperVisibility
        {
            get
            {
                return (string)GetValue(OutOfPaperVisibilityProperty);
            }
            set
            {
                SetValue(OutOfPaperVisibilityProperty, value);
            }
        }
        public static readonly DependencyProperty OutOfPaperVisibilityProperty = DependencyProperty.Register("OutOfPaperVisibility", typeof(string), typeof(PrinterCard));

        #endregion

        #region PaperNearEndError
        public string PaperNearEndError
        {
            get
            {
                return (string)GetValue(PaperNearEndErrorProperty);
            }
            set
            {
                SetValue(PaperNearEndErrorProperty, value);
            }
        }
        public static readonly DependencyProperty PaperNearEndErrorProperty = DependencyProperty.Register("PaperNearEndError", typeof(string), typeof(PrinterCard));

        public string PaperNearEndForeground
        {
            get
            {
                return (string)GetValue(PaperNearEndForegroundProperty);
            }
            set
            {
                SetValue(PaperNearEndForegroundProperty, value);
            }
        }
        public static readonly DependencyProperty PaperNearEndForegroundProperty = DependencyProperty.Register("PaperNearEndForeground", typeof(string), typeof(PrinterCard));

        public string PaperNearEndVisibility
        {
            get
            {
                return (string)GetValue(PaperNearEndVisibilityProperty);
            }
            set
            {
                SetValue(PaperNearEndVisibilityProperty, value);
            }
        }
        public static readonly DependencyProperty PaperNearEndVisibilityProperty = DependencyProperty.Register("PaperNearEndVisibility", typeof(string), typeof(PrinterCard));


        #endregion

        #region PaperJam Error
        public string PaperJamError
        {
            get
            {
                return (string)GetValue(PaperJamErrorProperty);
            }
            set
            {
                SetValue(PaperJamErrorProperty, value);
            }
        }
        public static readonly DependencyProperty PaperJamErrorProperty = DependencyProperty.Register("PaperJamError", typeof(string), typeof(PrinterCard));

        public string PaperJamForeground
        {
            get
            {
                return (string)GetValue(PaperJamForegroundProperty);
            }
            set
            {
                SetValue(PaperJamForegroundProperty, value);
            }
        }
        public static readonly DependencyProperty PaperJamForegroundProperty = DependencyProperty.Register("PaperJamForeground", typeof(string), typeof(PrinterCard));

        public string PaperJamVisibility
        {
            get
            {
                return (string)GetValue(PaperJamVisibilityProperty);
            }
            set
            {
                SetValue(PaperJamVisibilityProperty, value);
            }
        }
        public static readonly DependencyProperty PaperJamVisibilityProperty = DependencyProperty.Register("PaperJamVisibility", typeof(string), typeof(PrinterCard));

        #endregion

        #region CoverOpenError
        public string CoverOpenError
        {
            get
            {
                return (string)GetValue(CoverOpenErrorProperty);
            }
            set
            {
                SetValue(CoverOpenErrorProperty, value);
            }
        }
        public static readonly DependencyProperty CoverOpenErrorProperty = DependencyProperty.Register("CoverOpenError", typeof(string), typeof(PrinterCard));

        public string CoverOpenForeground
        {
            get
            {
                return (string)GetValue(CoverOpenForegroundProperty);
            }
            set
            {
                SetValue(CoverOpenForegroundProperty, value);
            }
        }
        public static readonly DependencyProperty CoverOpenForegroundProperty = DependencyProperty.Register("CoverOpenForeground", typeof(string), typeof(PrinterCard));

        public string CoverOpenVisibility
        {
            get
            {
                return (string)GetValue(CoverOpenVisibilityProperty);
            }
            set
            {
                SetValue(CoverOpenVisibilityProperty, value);
            }
        }
        public static readonly DependencyProperty CoverOpenVisibilityProperty = DependencyProperty.Register("CoverOpenVisibility", typeof(string), typeof(PrinterCard));

        #endregion

        #region Drawer Sensor
        public string DrawerSensorError
        {
            get
            {
                return (string)GetValue(DrawerSensorErrorProperty);
            }
            set
            {
                SetValue(DrawerSensorErrorProperty, value);
            }
        }
        public static readonly DependencyProperty DrawerSensorErrorProperty = DependencyProperty.Register("DrawerSensorError", typeof(string), typeof(PrinterCard));

        public string DrawerSensorForeground
        {
            get
            {
                return (string)GetValue(DrawerSensorForegroundProperty);
            }
            set
            {
                SetValue(DrawerSensorForegroundProperty, value);
            }
        }
        public static readonly DependencyProperty DrawerSensorForegroundProperty = DependencyProperty.Register("DrawerSensorForeground", typeof(string), typeof(PrinterCard));

        public string DrawerSensorVisibility
        {
            get
            {
                return (string)GetValue(DrawerSensorVisibilityProperty);
            }
            set
            {
                SetValue(DrawerSensorVisibilityProperty, value);
            }
        }
        public static readonly DependencyProperty DrawerSensorVisibilityProperty = DependencyProperty.Register("DrawerSensorVisibility", typeof(string), typeof(PrinterCard));
        #endregion

        #region ErrorsList
        public string ErrorsList
        {
            get
            {
                return (string)GetValue(ErrorsListProperty);
            }
            set
            {
                SetValue(ErrorsListProperty, value);
            }
        }
        public static readonly DependencyProperty ErrorsListProperty = DependencyProperty.Register("ErrorsList", typeof(string), typeof(PrinterCard));

        public string ErrorsListVisibility
        {
            get
            {
                return (string)GetValue(ErrorsListVisibilityProperty);
            }
            set
            {
                SetValue(ErrorsListVisibilityProperty, value);
            }
        }
        public static readonly DependencyProperty ErrorsListVisibilityProperty = DependencyProperty.Register("ErrorsListVisibility", typeof(string), typeof(PrinterCard));

        #endregion
        public string UnrecoverableError
        {
            get
            {
                return (string)GetValue(UnrecoverableErrorProperty);
            }
            set
            {
                SetValue(UnrecoverableErrorProperty, value);
            }
        }
        public static readonly DependencyProperty UnrecoverableErrorProperty = DependencyProperty.Register("UnrecoverableError", typeof(string), typeof(PrinterCard));

        public object SettingsView
        {
            get
            {
                return (object)GetValue(SettingsViewProperty);
            }
            set
            {
                SetValue(SettingsViewProperty, value);
            }
        }
        public static readonly DependencyProperty SettingsViewProperty = DependencyProperty.Register("SettingsView", typeof(object), typeof(PrinterCard));

        #region FeedSwitchState
        public string FeedSwitchStateError
        {
            get
            {
                return (string)GetValue(FeedSwitchStateErrorProperty);
            }
            set
            {
                SetValue(FeedSwitchStateErrorProperty, value);
            }
        }
        public static readonly DependencyProperty FeedSwitchStateErrorProperty = DependencyProperty.Register("FeedSwitchStateError", typeof(string), typeof(PrinterCard));

        public string FeedSwitchStateForeground
        {
            get
            {
                return (string)GetValue(FeedSwitchStateForegroundProperty);
            }
            set
            {
                SetValue(FeedSwitchStateForegroundProperty, value);
            }
        }
        public static readonly DependencyProperty FeedSwitchStateForegroundProperty = DependencyProperty.Register("FeedSwitchStateForeground", typeof(string), typeof(PrinterCard));

        public string FeedSwitchStateVisibility
        {
            get
            {
                return (string)GetValue(FeedSwitchStateVisibilityProperty);
            }
            set
            {
                SetValue(FeedSwitchStateVisibilityProperty, value);
            }
        }
        public static readonly DependencyProperty FeedSwitchStateVisibilityProperty = DependencyProperty.Register("FeedSwitchStateVisibility", typeof(string), typeof(PrinterCard));

        #endregion

        #region NoResponse Error
        public string NoResponseError
        {
            get
            {
                return (string)GetValue(NoResponseErrorProperty);
            }
            set
            {
                SetValue(NoResponseErrorProperty, value);
            }
        }
        public static readonly DependencyProperty NoResponseErrorProperty = DependencyProperty.Register("NoResponseError", typeof(string), typeof(PrinterCard));

        public string NoResponseForeground
        {
            get
            {
                return (string)GetValue(NoResponseForegroundProperty);
            }
            set
            {
                SetValue(NoResponseForegroundProperty, value);
            }
        }
        public static readonly DependencyProperty NoResponseForegroundProperty = DependencyProperty.Register("NoResponseForeground", typeof(string), typeof(PrinterCard));

        public string NoResponseVisibility
        {
            get
            {
                return (string)GetValue(NoResponseVisibilityProperty);
            }
            set
            {
                SetValue(NoResponseVisibilityProperty, value);
            }
        }
        public static readonly DependencyProperty NoResponseVisibilityProperty = DependencyProperty.Register("NoResponseVisibility", typeof(string), typeof(PrinterCard));


        #endregion

        #region Default Properties
        public string Icon
        {
            get
            {
                return (string)GetValue(IconProperty);
            }
            set
            {
                SetValue(IconProperty, value);
            }
        }
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(string), typeof(PrinterCard));

        public Color Background1
        {
            get
            {
                return (Color)GetValue(Background1Property);
            }
            set
            {
                SetValue(Background1Property, value);
            }
        }
        public static readonly DependencyProperty Background1Property = DependencyProperty.Register("Background1", typeof(Color), typeof(PrinterCard));

        public Color Background2
        {
            get
            {
                return (Color)GetValue(Background2Property);
            }
            set
            {
                SetValue(Background2Property, value);
            }
        }
        public static readonly DependencyProperty Background2Property = DependencyProperty.Register("Background2", typeof(Color), typeof(PrinterCard));

        public Color EllipseBackground1
        {
            get
            {
                return (Color)GetValue(EllipseBackground1Property);
            }
            set
            {
                SetValue(EllipseBackground1Property, value);
            }
        }
        public static readonly DependencyProperty EllipseBackground1Property = DependencyProperty.Register("EllipseBackground1", typeof(Color), typeof(PrinterCard));

        public Color EllipseBackground2
        {
            get
            {
                return (Color)GetValue(EllipseBackground2Property);
            }
            set
            {
                SetValue(EllipseBackground2Property, value);
            }
        }
        public static readonly DependencyProperty EllipseBackground2Property = DependencyProperty.Register("EllipseBackground2", typeof(Color), typeof(PrinterCard));

        #endregion

        #region Settings

   

        #endregion
    }
}
