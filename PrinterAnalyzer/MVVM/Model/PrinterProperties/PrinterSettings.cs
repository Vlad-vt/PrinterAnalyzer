using SII.SDK.PosPrinter;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using Windows.ApplicationModel;

namespace PrinterAnalyzer.MVVM.Model.PrinterProperties
{
    [StructLayout(LayoutKind.Sequential)]
    struct PRINTER_DEFAULTS
    {
        public IntPtr pDatatype;
        public IntPtr pDevMode;
        public int DesiredAccess;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct PRINTER_INFO_2
    {
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pServerName;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pPrinterName;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pShareName;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pPortName;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pDriverName;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pComment;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pLocation;
        public IntPtr pDevMode;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pSepFile;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pPrintProcessor;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pDatatype;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pParameters;
        public IntPtr pSecurityDescriptor;
        public uint Attributes;
        public uint Priority;
        public uint DefaultPriority;
        public uint StartTime;
        public uint UntilTime;
        public uint Status;
        public uint cJobs;
        public uint AveragePPM;
    }

    struct POINTL
    {
        public Int32 x;
        public Int32 y;
    }

    [Flags()]
    enum DM : int
    {
        Orientation = 0x1,
        PaperSize = 0x2,
        PaperLength = 0x4,
        PaperWidth = 0x8,
        Scale = 0x10,
        Position = 0x20,
        NUP = 0x40,
        DisplayOrientation = 0x80,
        Copies = 0x100,
        DefaultSource = 0x200,
        PrintQuality = 0x400,
        Color = 0x800,
        Duplex = 0x1000,
        YResolution = 0x2000,
        TTOption = 0x4000,
        Collate = 0x8000,
        FormName = 0x10000,
        LogPixels = 0x20000,
        BitsPerPixel = 0x40000,
        PelsWidth = 0x80000,
        PelsHeight = 0x100000,
        DisplayFlags = 0x200000,
        DisplayFrequency = 0x400000,
        ICMMethod = 0x800000,
        ICMIntent = 0x1000000,
        MediaType = 0x2000000,
        DitherType = 0x4000000,
        PanningWidth = 0x8000000,
        PanningHeight = 0x10000000,
        DisplayFixedOutput = 0x20000000
    }


    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi)]
    struct DEVMODE
    {
        public const int CCHDEVICENAME = 32;
        public const int CCHFORMNAME = 32;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHDEVICENAME)]
        [FieldOffset(0)]
        public string dmDeviceName;
        [FieldOffset(32)]
        public Int16 dmSpecVersion;
        [FieldOffset(34)]
        public Int16 dmDriverVersion;
        [FieldOffset(36)]
        public Int16 dmSize;
        [FieldOffset(38)]
        public Int16 dmDriverExtra;
        [FieldOffset(40)]
        public DM dmFields;

        [FieldOffset(44)]
        Int16 dmOrientation;
        [FieldOffset(46)]
        Int16 dmPaperSize;
        [System.Runtime.InteropServices.FieldOffset(48)]
        Int16 dmPaperLength;
        [System.Runtime.InteropServices.FieldOffset(50)]
        Int16 dmPaperWidth;
        [System.Runtime.InteropServices.FieldOffset(52)]
        Int16 dmScale;
        [System.Runtime.InteropServices.FieldOffset(54)]
        Int16 dmCopies;
        [System.Runtime.InteropServices.FieldOffset(56)]
        Int16 dmDefaultSource;
        [System.Runtime.InteropServices.FieldOffset(58)]
        Int16 dmPrintQuality;

        [System.Runtime.InteropServices.FieldOffset(44)]
        public POINTL dmPosition;
        [System.Runtime.InteropServices.FieldOffset(52)]
        public Int32 dmDisplayOrientation;
        [System.Runtime.InteropServices.FieldOffset(56)]
        public Int32 dmDisplayFixedOutput;

        [System.Runtime.InteropServices.FieldOffset(60)]
        public short dmColor;
        [System.Runtime.InteropServices.FieldOffset(62)]
        public short dmDuplex;
        [System.Runtime.InteropServices.FieldOffset(64)]
        public short dmYResolution;
        [System.Runtime.InteropServices.FieldOffset(66)]
        public short dmTTOption;
        [System.Runtime.InteropServices.FieldOffset(68)]
        public short dmCollate;
        [System.Runtime.InteropServices.FieldOffset(72)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHFORMNAME)]
        public string dmFormName;
        [System.Runtime.InteropServices.FieldOffset(102)]
        public Int16 dmLogPixels;
        [System.Runtime.InteropServices.FieldOffset(104)]
        public Int32 dmBitsPerPel;
        [System.Runtime.InteropServices.FieldOffset(108)]
        public Int32 dmPelsWidth;
        [System.Runtime.InteropServices.FieldOffset(112)]
        public Int32 dmPelsHeight;
        [System.Runtime.InteropServices.FieldOffset(116)]
        public Int32 dmDisplayFlags;
        [System.Runtime.InteropServices.FieldOffset(116)]
        public Int32 dmNup;
        [System.Runtime.InteropServices.FieldOffset(120)]
        public Int32 dmDisplayFrequency;
    }

    public static class PrinterSettings
    {
        private static IntPtr gPrinter = new System.IntPtr();
        private static PRINTER_DEFAULTS gPrinterValues = new PRINTER_DEFAULTS();
        private static PRINTER_INFO_2 gPInfo = new PRINTER_INFO_2();
        private static DEVMODE gDevMode;
        private static IntPtr gPtrDevMode;
        private static IntPtr gPtrPrinterInfo;
        private static int gSizeOfDevMode = 0;
        private static int gLastError;
        private static int gNBytesNeeded;
        private static long gNRet;
        private static int gIntError;
        private static int gNTemporary;
        private static IntPtr gDevModeData;

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true,
        ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "DocumentPropertiesA", SetLastError = true,
        ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern int DocumentProperties(IntPtr hwnd, IntPtr hPrinter,
         [MarshalAs(UnmanagedType.LPStr)] string pDeviceName,
        IntPtr pDevModeOutput, IntPtr pDevModeInput, int fMode);

        [DllImport("winspool.drv", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool GetPrinter(IntPtr hPrinter, Int32 dwLevel, IntPtr pPrinter, Int32 dwBuf, out Int32 dwNeeded);

        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA",
            SetLastError = true, CharSet = CharSet.Ansi,
            ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter,
            out IntPtr hPrinter, ref PRINTER_DEFAULTS pd);

        [DllImport("winspool.drv", CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern bool SetPrinter(IntPtr hPrinter, int Level,
                                           IntPtr pPrinter, int Command);

        private const int DM_DUPLEX = 4096; //0x1000
        private const int DM_IN_BUFFER = 8;
        private const int DM_OUT_BUFFER = 2;
        private const int PRINTER_ACCESS_ADMINISTER = 4; //0x4
        private const int STANDARD_RIGHTS_REQUIRED = 983040; //0xF0000
        private const int PRINTER_ALL_ACCESS = STANDARD_RIGHTS_REQUIRED | PRINTER_ACCESS_ADMINISTER | PRINTER_ACCESS_USE;
        private const int PRINTER_ACCESS_USE = 8; //0x8


        public static Dictionary<PropertyType, int> GetCurrentProperties(string iPrinterName, ref SII.SDK.PosPrinter.StatusAPI statusAPI)
        {
            try
            {
                #region DEVMODE Structure
                gDevMode = GetPrinterSettings(iPrinterName);
                Marshal.StructureToPtr(gDevMode, gDevModeData, true);
                gPInfo.pDevMode = gDevModeData;
                gPInfo.pSecurityDescriptor = IntPtr.Zero;
                #endregion

                Dictionary<PropertyType, int> properties = new Dictionary<PropertyType, int>();
                byte[] bytes = new byte[256];
                uint size = 10;
                foreach (PropertyType propertyType in Enum.GetValues(typeof(PropertyType)))
                {
                    switch (propertyType)
                    {
                        case PropertyType.Speed:
                            if(statusAPI.GetProperty(gDevModeData, PropertyId.SPEED, bytes, ref size) == ErrorCode.SUCCESS);
                            {
                                properties.Add(PropertyType.Speed, BitConverter.ToInt32(bytes, 0));
                            }
                            break;
                        case PropertyType.Direction:
                            statusAPI.GetProperty(gDevModeData, PropertyId.DIRECTION, bytes, ref size);
                            properties.Add(PropertyType.Direction, BitConverter.ToInt32(bytes, 0));
                            break;
                        case PropertyType.FeedToCutPosition:
                            statusAPI.GetProperty(gDevModeData, PropertyId.CUT_FEED, bytes, ref size);
                            properties.Add(PropertyType.FeedToCutPosition, BitConverter.ToInt32(bytes, 0));
                            break;
                        case PropertyType.Margin:
                            statusAPI.GetProperty(gDevModeData, PropertyId.MARGIN, bytes, ref size);
                            properties.Add(PropertyType.Margin, BitConverter.ToInt32(bytes, 0));
                            break;
                        case PropertyType.PaperCut:
                            statusAPI.GetProperty(gDevModeData, PropertyId.CUT, bytes, ref size);
                            properties.Add(PropertyType.PaperCut, BitConverter.ToInt32(bytes, 0));
                            break;
                        case PropertyType.Orientation:
                            statusAPI.GetProperty(gDevModeData, PropertyId.ORIENTATION, bytes, ref size);
                            properties.Add(PropertyType.Orientation, BitConverter.ToInt32(bytes, 0));
                            break;
                        case PropertyType.Watermark:
                            statusAPI.GetProperty(gDevModeData, PropertyId.WATERMARK, bytes, ref size);
                            properties.Add(PropertyType.Watermark, BitConverter.ToInt32(bytes, 0));
                            break;
                    }
                }
                return properties;
            }
            catch(Exception e)
            {
                //System.Windows.MessageBox.Show(e.Message);
                return null;
            }
        }

        public static Dictionary<PropertyType, int> GetCurrentProperties(string iPrinterName, ref SiiPrinterSdk.StatusAPI statusAPI)
        {
            try
            {
                #region DEVMODE Structure
                gDevMode = GetPrinterSettings(iPrinterName);
                Marshal.StructureToPtr(gDevMode, gDevModeData, true);
                gPInfo.pDevMode = gDevModeData;
                gPInfo.pSecurityDescriptor = IntPtr.Zero;
                #endregion

                Dictionary<PropertyType, int> properties = new Dictionary<PropertyType, int>();
                byte[] bytes = new byte[256];
                uint size = 10;
                foreach (PropertyType propertyType in Enum.GetValues(typeof(PropertyType)))
                {
                    switch (propertyType)
                    {
                        case PropertyType.Speed:
                            if (statusAPI.GetProperty(gDevModeData, (byte)PropertyId.SPEED, bytes, ref size) == SiiPrinterSdk.ErrorCode.SUCCESS)
                            {
                                properties.Add(PropertyType.Speed, BitConverter.ToInt32(bytes, 0));
                            }
                            break;
                        case PropertyType.Direction:
                            if (statusAPI.GetProperty(gDevModeData, (byte)PropertyId.DIRECTION, bytes, ref size) == SiiPrinterSdk.ErrorCode.SUCCESS)
                            {
                                properties.Add(PropertyType.Direction, BitConverter.ToInt32(bytes, 0));
                            }
                            break;
                        case PropertyType.FeedToCutPosition:
                            if (statusAPI.GetProperty(gDevModeData, (byte)PropertyId.CUT_FEED, bytes, ref size) == SiiPrinterSdk.ErrorCode.SUCCESS)
                            {
                                properties.Add(PropertyType.FeedToCutPosition, BitConverter.ToInt32(bytes, 0));
                            }
                            break;
                        case PropertyType.Margin:
                            statusAPI.GetProperty(gDevModeData, (byte)PropertyId.MARGIN, bytes, ref size);
                            properties.Add(PropertyType.Margin, BitConverter.ToInt32(bytes, 0));
                            break;
                        case PropertyType.PaperCut:
                            statusAPI.GetProperty(gDevModeData, 7, bytes, ref size);
                            properties.Add(PropertyType.PaperCut, BitConverter.ToInt32(bytes, 0));
                            break;
                        case PropertyType.Orientation:
                            statusAPI.GetProperty(gDevModeData, (byte)PropertyId.ORIENTATION, bytes, ref size);
                            properties.Add(PropertyType.Orientation, BitConverter.ToInt32(bytes, 0));
                            break;
                        case PropertyType.Watermark:
                            statusAPI.GetProperty(gDevModeData, (byte)PropertyId.WATERMARK, bytes, ref size);
                            properties.Add(PropertyType.Watermark, BitConverter.ToInt32(bytes, 0));
                            break;
                        case PropertyType.Preset:
                            statusAPI.GetProperty(gDevModeData, (byte)PropertyId.PRESET, bytes, ref size);
                            properties.Add(PropertyType.Preset, BitConverter.ToInt32(bytes, 0));
                            break;
                        case PropertyType.MarkFeed:
                            statusAPI.GetProperty(gDevModeData, (byte)PropertyId.MARK_FEED, bytes, ref size);
                            properties.Add(PropertyType.MarkFeed, BitConverter.ToInt32(bytes, 0));
                            break;
                        case PropertyType.PageStartLogo:
                            statusAPI.GetProperty(gDevModeData, (byte)PropertyId.START_PAGE_LOGO, bytes, ref size);
                            properties.Add(PropertyType.PageStartLogo, BitConverter.ToInt32(bytes, 0));
                            break;
                        case PropertyType.PageEndLogo:
                            statusAPI.GetProperty(gDevModeData, (byte)PropertyId.END_PAGE_LOGO, bytes, ref size);
                            properties.Add(PropertyType.PageEndLogo, BitConverter.ToInt32(bytes, 0));
                            break;
                        case PropertyType.PaperSize:
                            statusAPI.GetProperty(gDevModeData, (byte)PropertyId.PAPER_SIZE, bytes, ref size);
                            properties.Add(PropertyType.PaperSize, BitConverter.ToInt32(bytes, 0));
                            break;
                    }
                }
                return properties;
            }
            catch (Exception e)
            {
                //System.Windows.MessageBox.Show(e.Message);
                return null;
            }
        }
        public static bool ChangePrinterSetting(string iPrinterName, ref SiiPrinterSdk.StatusAPI statusAPI, PropertyType propertyType, int id)
        {
            #region DEVMODE Structure
            gDevMode = GetPrinterSettings(iPrinterName);
            Marshal.StructureToPtr(gDevMode, gDevModeData, true);
            gPInfo.pDevMode = gDevModeData;
            gPInfo.pSecurityDescriptor = IntPtr.Zero;
            #endregion

            try
            {
                byte[] bytes = BitConverter.GetBytes(id);
                uint size = 1;
                switch(propertyType)
                {
                    case PropertyType.Speed:
                        statusAPI.SetProperty(gDevModeData, 2, bytes, size);
                        break;
                    case PropertyType.Direction:
                        statusAPI.SetProperty(gDevModeData, 5, bytes, size);
                        break;
                    case PropertyType.Margin:
                        statusAPI.SetProperty(gDevModeData, 3, bytes, size);
                        break;
                    case PropertyType.PaperCut:
                        statusAPI.SetProperty(gDevModeData, 7, bytes, size);
                        break;
                    case PropertyType.Orientation:
                        statusAPI.SetProperty(gDevModeData, 51, bytes, size);
                        break;
                    case PropertyType.FeedToCutPosition:
                        statusAPI.SetProperty(gDevModeData, 9, bytes, size);
                        break;
                }
                DocumentProperties(IntPtr.Zero, gPrinter, iPrinterName, gDevModeData, gPInfo.pDevMode, DM_IN_BUFFER | DM_OUT_BUFFER | 983040);
            }
            catch(Exception e)
            {

            }
            Marshal.StructureToPtr(gPInfo, gPtrPrinterInfo, false);
            gLastError = Marshal.GetLastWin32Error();
            gNRet = Convert.ToInt16(SetPrinter(gPrinter, 2, gPtrPrinterInfo, 0));
            Marshal.FreeHGlobal(gPtrPrinterInfo);
            if (gNRet == 0)
            {
                gLastError = Marshal.GetLastWin32Error();
            }
            if (gPrinter != IntPtr.Zero)
            {
                ClosePrinter(gPrinter);
            }
            return Convert.ToBoolean(gNRet);
        }

       /* public unsafe static bool ChangePrinterSetting(string iPrinterName, ref SII.SDK.PosPrinter.StatusAPI statusAPI, PropertyType propertyType, int id)
        {
            #region DEVMODE Structure
            gDevMode = GetPrinterSettings(iPrinterName);

            // Использование указателя для ускорения маршалинга структуры
            fixed (void* devModePtr = &gDevMode)
            {
                gDevModeData = (IntPtr)devModePtr;
                gPInfo.pDevMode = gDevModeData;
                gPInfo.pSecurityDescriptor = IntPtr.Zero;
            }
            #endregion

            try
            {
                // Используем массив байтов
                byte[] bytes = BitConverter.GetBytes(id);
                uint size = (uint)bytes.Length;

                switch (propertyType)
                {
                    case PropertyType.Speed:
                        statusAPI.SetProperty(gDevModeData, (byte)PropertyId.SPEED, bytes, size);
                        break;
                    case PropertyType.Direction:
                        statusAPI.SetProperty(gDevModeData, (byte)PropertyId.DIRECTION, bytes, size);
                        break;
                    case PropertyType.Margin:
                        statusAPI.SetProperty(gDevModeData, (byte)PropertyId.MARGIN, bytes, size);
                        break;
                    case PropertyType.PaperCut:
                        statusAPI.SetProperty(gDevModeData, (byte)PropertyId.CUT, bytes, size);
                        break;
                    case PropertyType.Orientation:
                        statusAPI.SetProperty(gDevModeData, (byte)PropertyId.ORIENTATION, bytes, size);
                        break;
                    case PropertyType.FeedToCutPosition:
                        statusAPI.SetProperty(gDevModeData, (byte)PropertyId.CUT_FEED, bytes, size);
                        break;
                }

                DocumentProperties(IntPtr.Zero, gPrinter, iPrinterName, gDevModeData, gPInfo.pDevMode, DM_IN_BUFFER | DM_OUT_BUFFER | 983040);
            }
            catch (Exception e)
            {
                // Обработка исключений
            }

            // Оптимизированное копирование структуры в неуправляемую память
            Marshal.StructureToPtr(gPInfo, gPtrPrinterInfo, false);

            gLastError = Marshal.GetLastWin32Error();
            gNRet = Convert.ToInt16(SetPrinter(gPrinter, 2, gPtrPrinterInfo, 0));

            if (gNRet == 0)
            {
                gLastError = Marshal.GetLastWin32Error();
            }

            if (gPrinter != IntPtr.Zero)
            {
                ClosePrinter(gPrinter);
            }

            return Convert.ToBoolean(gNRet);
        }*/



        public static bool ChangePrinterSetting(string iPrinterName, ref SII.SDK.PosPrinter.StatusAPI statusAPI, PropertyType propertyType, int id)
        {
            #region DEVMODE Structure
            gDevMode = GetPrinterSettings(iPrinterName);
            Marshal.StructureToPtr(gDevMode, gDevModeData, true);
            gPInfo.pDevMode = gDevModeData;
            gPInfo.pSecurityDescriptor = IntPtr.Zero;
            #endregion

            try
            {
                byte[] bytes = BitConverter.GetBytes(id);
                uint size = 1;
                switch (propertyType)
                {
                    case PropertyType.Speed:
                        statusAPI.SetProperty(gDevModeData, PropertyId.SPEED, bytes, size);
                        break;
                    case PropertyType.Direction:
                        statusAPI.SetProperty(gDevModeData, PropertyId.DIRECTION, bytes, size);
                        break;
                    case PropertyType.Margin:
                        statusAPI.SetProperty(gDevModeData, PropertyId.MARGIN, bytes, size);
                        break;
                    case PropertyType.PaperCut:
                        statusAPI.SetProperty(gDevModeData, PropertyId.CUT, bytes, size);
                        break;
                    case PropertyType.Orientation:
                        statusAPI.SetProperty(gDevModeData, PropertyId.ORIENTATION, bytes, size);
                        break;
                    case PropertyType.FeedToCutPosition:
                        statusAPI.SetProperty(gDevModeData, PropertyId.CUT_FEED, bytes, size);
                        break;
                }
                DocumentProperties(IntPtr.Zero, gPrinter, iPrinterName, gDevModeData, gPInfo.pDevMode, DM_IN_BUFFER | DM_OUT_BUFFER | 983040);
            }
            catch (Exception e)
            {

            }
            Marshal.StructureToPtr(gPInfo, gPtrPrinterInfo, false);
            gLastError = Marshal.GetLastWin32Error();
            gNRet = Convert.ToInt16(SetPrinter(gPrinter, 2, gPtrPrinterInfo, 0));
            Marshal.FreeHGlobal(gPtrPrinterInfo);
            if (gNRet == 0)
            {
                gLastError = Marshal.GetLastWin32Error();
            }
            if (gPrinter != IntPtr.Zero)
            {
                ClosePrinter(gPrinter);
            }
            return Convert.ToBoolean(gNRet);
        }

        public static async Task<bool> ChangePrinterSettingAsync(string iPrinterName, SII.SDK.PosPrinter.StatusAPI statusAPI, PropertyType propertyType, int id)
        {
            return await Task.Run(() =>
            {
                #region DEVMODE Structure
                gDevMode = GetPrinterSettings(iPrinterName);
                Marshal.StructureToPtr(gDevMode, gDevModeData, true);
                gPInfo.pDevMode = gDevModeData;
                gPInfo.pSecurityDescriptor = IntPtr.Zero;
                #endregion

                try
                {
                    byte[] bytes = BitConverter.GetBytes(id);
                    uint size = 1;

                    // Параллельное выполнение нескольких операций изменения свойств
                    var tasks = new List<Task>();

                    switch (propertyType)
                    {
                        case PropertyType.Speed:
                            tasks.Add(Task.Run(() => statusAPI.SetProperty(gDevModeData, PropertyId.SPEED, bytes, size)));
                            break;
                        case PropertyType.Direction:
                            tasks.Add(Task.Run(() => statusAPI.SetProperty(gDevModeData, PropertyId.DIRECTION, bytes, size)));
                            break;
                        case PropertyType.Margin:
                            tasks.Add(Task.Run(() => statusAPI.SetProperty(gDevModeData, PropertyId.MARGIN, bytes, size)));
                            break;
                        case PropertyType.PaperCut:
                            tasks.Add(Task.Run(() => statusAPI.SetProperty(gDevModeData, PropertyId.CUT, bytes, size)));
                            break;
                        case PropertyType.Orientation:
                            tasks.Add(Task.Run(() => statusAPI.SetProperty(gDevModeData, PropertyId.ORIENTATION, bytes, size)));
                            break;
                        case PropertyType.FeedToCutPosition:
                            tasks.Add(Task.Run(() => statusAPI.SetProperty(gDevModeData, PropertyId.CUT_FEED, bytes, size)));
                            break;
                        case PropertyType.Watermark:
                            tasks.Add(Task.Run(() => statusAPI.SetProperty(gDevModeData, PropertyId.WATERMARK, bytes, size)));
                            break;
                        case PropertyType.Preset:
                            tasks.Add(Task.Run(() => statusAPI.SetProperty(gDevModeData, PropertyId.PRESET, bytes, size)));
                            break;
                        case PropertyType.PaperSize:
                            tasks.Add(Task.Run(() => statusAPI.SetProperty(gDevModeData, PropertyId.PAPER_SIZE, bytes, size)));
                            break;
                        case PropertyType.PageStartLogo:
                            tasks.Add(Task.Run(() => statusAPI.SetProperty(gDevModeData, PropertyId.START_PAGE_LOGO, bytes, size)));
                            break;
                        case PropertyType.PageEndLogo:
                            tasks.Add(Task.Run(() => statusAPI.SetProperty(gDevModeData, PropertyId.END_PAGE_LOGO, bytes, size)));
                            break;
                        case PropertyType.MarkFeed:
                            tasks.Add(Task.Run(() => statusAPI.SetProperty(gDevModeData, PropertyId.MARK_FEED, bytes, size)));
                            break;
                    }

                    // Ожидаем выполнения всех задач
                    Task.WaitAll(tasks.ToArray());

                    // Применение настроек через DocumentProperties
                    DocumentProperties(IntPtr.Zero, gPrinter, iPrinterName, gDevModeData, gPInfo.pDevMode, DM_IN_BUFFER | DM_OUT_BUFFER | 983040);
                }
                catch (Exception e)
                {
                    // Логгирование ошибки
                    return false;
                }

                Marshal.StructureToPtr(gPInfo, gPtrPrinterInfo, false);
                gLastError = Marshal.GetLastWin32Error();
                gNRet = Convert.ToInt16(SetPrinter(gPrinter, 2, gPtrPrinterInfo, 0));
                Marshal.FreeHGlobal(gPtrPrinterInfo);

                if (gNRet == 0)
                {
                    gLastError = Marshal.GetLastWin32Error();
                }

                if (gPrinter != IntPtr.Zero)
                {
                    ClosePrinter(gPrinter);
                }

                return Convert.ToBoolean(gNRet);
            });
        }


        public static bool ChangePrinterSettings(string iPrinterName, ref SII.SDK.PosPrinter.StatusAPI statusAPI, Dictionary<PropertyType, int> settingsList)
        {
            #region DEVMODE Structure
            gDevMode = GetPrinterSettings(iPrinterName);
            Marshal.StructureToPtr(gDevMode, gDevModeData, true);
            gPInfo.pDevMode = gDevModeData;
            gPInfo.pSecurityDescriptor = IntPtr.Zero;
            #endregion

            try
            {
                byte[] bytes;
                uint size = 1;
                foreach (PropertyType propertyType in Enum.GetValues(typeof(PropertyType)))
                {
                    switch (propertyType)
                    {
                        case PropertyType.Speed:
                            bytes = BitConverter.GetBytes(settingsList.GetValueOrDefault(PropertyType.Speed));
                            statusAPI.SetProperty(gDevModeData, PropertyId.SPEED, bytes, size);
                            break;
                        case PropertyType.Direction:
                            bytes = BitConverter.GetBytes(settingsList.GetValueOrDefault(PropertyType.Direction));
                            statusAPI.SetProperty(gDevModeData, PropertyId.DIRECTION, bytes, size);
                            break;
                        case PropertyType.Margin:
                            bytes = BitConverter.GetBytes(settingsList.GetValueOrDefault(PropertyType.Margin));
                            statusAPI.SetProperty(gDevModeData, PropertyId.MARGIN, bytes, size);
                            break;
                        case PropertyType.PaperCut:
                            bytes = BitConverter.GetBytes(settingsList.GetValueOrDefault(PropertyType.PaperCut));
                            statusAPI.SetProperty(gDevModeData, PropertyId.CUT, bytes, size);
                            break;
                        case PropertyType.Orientation:
                            bytes = BitConverter.GetBytes(settingsList.GetValueOrDefault(PropertyType.Orientation));
                            statusAPI.SetProperty(gDevModeData, PropertyId.ORIENTATION, bytes, size);
                            break;
                        case PropertyType.FeedToCutPosition:
                            bytes = BitConverter.GetBytes(settingsList.GetValueOrDefault(PropertyType.FeedToCutPosition));
                            statusAPI.SetProperty(gDevModeData, PropertyId.CUT_FEED, bytes, size);
                            break;
                    }
                }
                DocumentProperties(IntPtr.Zero, gPrinter, iPrinterName, gDevModeData, gPInfo.pDevMode, DM_IN_BUFFER | DM_OUT_BUFFER | 983040);
            }
            catch (Exception e)
            {

            }
            Marshal.StructureToPtr(gPInfo, gPtrPrinterInfo, false);
            gLastError = Marshal.GetLastWin32Error();
            gNRet = Convert.ToInt16(SetPrinter(gPrinter, 2, gPtrPrinterInfo, 0));
            Marshal.FreeHGlobal(gPtrPrinterInfo);
            if (gNRet == 0)
            {
                gLastError = Marshal.GetLastWin32Error();
            }
            if (gPrinter != IntPtr.Zero)
            {
                ClosePrinter(gPrinter);
            }
            return Convert.ToBoolean(gNRet);
        }

        public static bool ChangePrinterSettings(string iPrinterName, ref SiiPrinterSdk.StatusAPI statusAPI, Dictionary<PropertyType, int> settingsList)
        {
            #region DEVMODE Structure
            gDevMode = GetPrinterSettings(iPrinterName);
            Marshal.StructureToPtr(gDevMode, gDevModeData, true);
            gPInfo.pDevMode = gDevModeData;
            gPInfo.pSecurityDescriptor = IntPtr.Zero;
            #endregion

            try
            {
                byte[] bytes;
                uint size = 1;
                foreach (PropertyType propertyType in Enum.GetValues(typeof(PropertyType)))
                {
                    switch (propertyType)
                    {
                        case PropertyType.Speed:
                            bytes = BitConverter.GetBytes(settingsList.GetValueOrDefault(PropertyType.Speed));
                            statusAPI.SetProperty(gDevModeData, 2, bytes, size);
                            break;
                        case PropertyType.Direction:
                            bytes = BitConverter.GetBytes(settingsList.GetValueOrDefault(PropertyType.Direction));
                            statusAPI.SetProperty(gDevModeData, 5, bytes, size);
                            break;
                        case PropertyType.Margin:
                            bytes = BitConverter.GetBytes(settingsList.GetValueOrDefault(PropertyType.Margin));
                            statusAPI.SetProperty(gDevModeData, 3, bytes, size);
                            break;
                        case PropertyType.PaperCut:
                            bytes = BitConverter.GetBytes(settingsList.GetValueOrDefault(PropertyType.PaperCut));
                            statusAPI.SetProperty(gDevModeData, 7, bytes, size);
                            break;
                        case PropertyType.Orientation:
                            bytes = BitConverter.GetBytes(settingsList.GetValueOrDefault(PropertyType.Orientation));
                            statusAPI.SetProperty(gDevModeData, 51, bytes, size);
                            break;
                        case PropertyType.FeedToCutPosition:
                            bytes = BitConverter.GetBytes(settingsList.GetValueOrDefault(PropertyType.FeedToCutPosition));
                            statusAPI.SetProperty(gDevModeData, 9, bytes, size);
                            break;
                    }
                }
                DocumentProperties(IntPtr.Zero, gPrinter, iPrinterName, gDevModeData, gPInfo.pDevMode, DM_IN_BUFFER | DM_OUT_BUFFER | 983040);
            }
            catch (Exception e)
            {

            }
            Marshal.StructureToPtr(gPInfo, gPtrPrinterInfo, false);
            gLastError = Marshal.GetLastWin32Error();
            gNRet = Convert.ToInt16(SetPrinter(gPrinter, 2, gPtrPrinterInfo, 0));
            Marshal.FreeHGlobal(gPtrPrinterInfo);
            if (gNRet == 0)
            {
                gLastError = Marshal.GetLastWin32Error();
            }
            if (gPrinter != IntPtr.Zero)
            {
                ClosePrinter(gPrinter);
            }
            return Convert.ToBoolean(gNRet);
        }

        private static DEVMODE GetPrinterSettings(string PrinterName)
        {
            DEVMODE lDevMode;
            gPrinterValues.pDatatype = IntPtr.Zero;
            gPrinterValues.pDevMode = IntPtr.Zero;
            gPrinterValues.DesiredAccess = PRINTER_ALL_ACCESS;

            // HERE CRASHES
            gNRet = Convert.ToInt32(OpenPrinter(PrinterName, out gPrinter, ref gPrinterValues));

            if (gNRet == 0)
            {
                gLastError = Marshal.GetLastWin32Error();
                //throw new Win32Exception(gLastError);
            }

            GetPrinter(gPrinter, 2, IntPtr.Zero, 0, out gNBytesNeeded);
            if (gNBytesNeeded <= 0)
                throw new System.Exception("Unable to allocate memory");
            else
            {
                // Allocate enough space for PRINTER_INFO_2... 
                gPtrPrinterInfo = Marshal.AllocCoTaskMem(gNBytesNeeded);
                gPtrPrinterInfo = Marshal.AllocHGlobal(gNBytesNeeded);
                //The second GetPrinter fills in all the current settings, so all you 
                //need to do is modify what youre interested in...
                gNRet = Convert.ToInt32(GetPrinter(gPrinter, 2,
                    gPtrPrinterInfo, gNBytesNeeded, out gNTemporary));
                if (gNRet == 0)
                {
                    gLastError = Marshal.GetLastWin32Error();
                   //throw new Win32Exception(gLastError);
                }
                gPInfo = (PRINTER_INFO_2)Marshal.PtrToStructure(gPtrPrinterInfo, typeof(PRINTER_INFO_2));
                IntPtr lTempBuffer = new IntPtr();
                if (gPInfo.pDevMode == IntPtr.Zero)
                {
                    //if GetPrinter didnt fill in the DEVMODE, try to get it by calling
                    //DocumentProperties...
                    IntPtr ptrZero = IntPtr.Zero;
                    //get the size of the devmode struct
                    gSizeOfDevMode = DocumentProperties(IntPtr.Zero, gPrinter,
                                       PrinterName, ptrZero, ptrZero, 0);
                    gPtrDevMode = Marshal.AllocCoTaskMem(gSizeOfDevMode);
                    int i = DocumentProperties(IntPtr.Zero, gPrinter, PrinterName, gPtrDevMode,
                    ptrZero, DM_OUT_BUFFER);
                    if (i < 0 || gPtrDevMode != IntPtr.Zero)
                    {
                        //Cannot get the DEVMODE struct.
                        throw new System.Exception("Cannot get DEVMODE data");
                    }
                    gPInfo.pDevMode = gPtrDevMode;
                }
                gIntError = DocumentProperties(IntPtr.Zero, gPrinter,
                          PrinterName, IntPtr.Zero, lTempBuffer, 0);
                gDevModeData = Marshal.AllocHGlobal(gIntError);
                gIntError = DocumentProperties(IntPtr.Zero, gPrinter,
                         PrinterName, gDevModeData, lTempBuffer, 2);
                lDevMode = (DEVMODE)Marshal.PtrToStructure(gDevModeData, typeof(DEVMODE));
                if (gNRet == 0 || gPrinter == IntPtr.Zero)
                {
                    gLastError = Marshal.GetLastWin32Error();
                    //throw new Win32Exception(gLastError);
                }
                return lDevMode;
            }
        }
    }
}
