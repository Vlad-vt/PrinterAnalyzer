﻿using System;
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
    }
}
