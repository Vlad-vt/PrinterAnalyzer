using SII.SDK.PosPrinter;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrinterAnalyzer.Communication.RP_F10_G10
{
    internal class DllFuncF10G10
    {
        // Callback handler definition
        public delegate void callbackEventHandler(Dictionary<string,string> msg);
        public event callbackEventHandler MyCallbackEvent;

        // The property indicating whether to display barcode data as text
        public bool IsDataFormatText { get; set; }

        // Printer main control command definition
        private const byte ESC = 0x1b;
        private const byte SYN = 0x16;
        private const byte DC1 = 0x11;
        private const byte DC2 = 0x12;
        private const byte DC3 = 0x13;
        private const byte GS = 0x1d;

        // Sample test data definition
        // PrintData Header
        private byte[] HEADER_SAMP = new byte[] { ESC, (byte)'@', ESC, (byte)'R', 0x00, ESC, (byte)'t', 0x00 };
        // QRCode Command
        private byte[] BARCODE_SAMP = new byte[] { GS, (byte)'h', 0xA2, DC2, (byte)';', 0x06, GS, (byte)'p', 0x01, 0x02, 0x4C, 0x00, 0x4D, 0x07, 0x00, (byte)'A', (byte)'B', (byte)'C', (byte)'0', (byte)'1', (byte)'2', (byte)'3' };
        // Print and Feed Forward
        private byte[] FEED_SAMP = new byte[] { ESC, (byte)'J', 0x1C };
        // PrintData Footer
        private byte[] FOOTER_SAMP = new byte[] { GS, (byte)'V', 0x41, 0x00, DC2, (byte)'q', 0x00 };

        private const string RECEIPT_SAMP =
        "TestPrint by DirectIOEx\n" +
        "--------------------------------\n" +
        "GRILLED CHICKEN BREAST   $ 18.50\n" +
        "SIRLOIN STEAK            $ 32.00\n" +
        "ROAST LAMB               $ 20.00\n" +
        "SALAD                    $ 10.00\n" +
        "COKE                     $  3.50\n" +
        "COKE                     $  3.50\n" +
        "ICE CREAM                $  5.00\n" +
        "CHINESE NOODLE           $ 15.00\n" +
        "SUKIYAKI                 $ 30.00\n" +
        "SANDWICH                 $ 10.00\n" +
        "PIZZA                    $ 20.00\n" +
        "TEA                      $  3.50\n" +
        "COFFEE                   $  3.50\n\n" +
        "--------------------------------\n" +
        "       SUBTOTAL        $ 174.50\n" +
        "       SALES TAX       $   8.73\n" +
        "       TOTAL           $ 183.23\n\n" +
        "Thank you and see you again!\n";

        // DirectSendRead command file define.
        // This command file is installed under the 
        //	[%PROGRAMFILES(X86)%\SII\SDK\SamplePrograms].
        private const string cmdFileName = "CommandDefinitionFile.txt";

        // List of commands defined in the sample command file
        private string[] tblCmdFile = new string[] { "cmd1", "cmd2", "cmd3", "cmd4", "cmd5", "cmd6", "cmd7", "cmd8", "cmd9", "cmd10" };

        // Index of the table for ID of the GetPrinCapability function
        private uint indexCapability = 0;

        // .NET API class.
        internal StatusAPI m_StatusAPI;                       // For printer
        internal BarcodeScannerAPI m_BarcodeScannerAPI;       // For barcode scanner

        // Model dependent data class
        private DevInfoG10F10 m_DevInfo;

        public DllFuncF10G10()
        {
            m_DevInfo = new DevInfoG10F10();
            m_StatusAPI = new StatusAPI();
            m_StatusAPI.StatusCallback += new StatusAPI.StatusCallbackHandler(CbStatusFuncSampProc);
            m_BarcodeScannerAPI = new BarcodeScannerAPI();
            m_BarcodeScannerAPI.BarcodeDataCallback += new BarcodeScannerAPI.BarcodeDataCallbackHandler(CbBarcodeDataFuncSampProc);
        }

        //	Callback status function sample
        private void CbStatusFuncSampProc(ASB status)
        {
            Dictionary<string, string> errorStatus = new Dictionary<string, string>();
            if (status == ASB.ASB_NO_RESPONSE)
            {
                errorStatus.Add("* Printer is offline", "Yes");
                MyCallbackEvent(errorStatus);
                return;
            }
            else
                errorStatus.Add("* Printer is offline", "No");

            if (status == ASB.ASB_VP_ERR)
                errorStatus.Add("* Voltage error : ", "Yes");
            else
                errorStatus.Add("* Voltage error : ", "No");


            if (status == ASB.ASB_HEAD_TEMPERATUR_ERR)
                errorStatus.Add("* Head temp error : ", "Yes");
            else
                errorStatus.Add("* Head temp error : ", "No");

            if (status == ASB.ASB_AUTOCUTTER_ERR)
                errorStatus.Add("* AutoCutter error : ", "Yes");
            else
                errorStatus.Add("* AutoCutter error : ", "No");

            if (status == ASB.ASB_RECEIPT_END)
                errorStatus.Add("* Out-of-paper error : ", "Yes");
            else
                errorStatus.Add("* Out-of-paper error : ", "No");

            if (status == ASB.ASB_RECEIPT_NEAR_END)
                errorStatus.Add("* Paper-near-end error : ", "Yes");
            else
                errorStatus.Add("* Paper-near-end error : ", "No");

            if (status == ASB.ASB_MARK_PAPER_JAM_ERR)
                errorStatus.Add("* Mark paper jam error : ", "Yes");
            else
                errorStatus.Add("* Mark paper jam error : ", "No");

            if (status == ASB.ASB_COVER_OPEN)
                errorStatus.Add("* Cover/Platen open error : ", "Yes");
            else
                errorStatus.Add("* Cover/Platen open error : ", "No");

            if (status == ASB.ASB_PAPER_FEED)
                errorStatus.Add("* Paper feed status : ", "Off");
            else
                errorStatus.Add("* Paper feed status : ", "On");

            if (status == ASB.ASB_RETURN_WAITING)
                errorStatus.Add("* Return-waiting status : ", "Yes");
            else
                errorStatus.Add("* Return-waiting status : ", "No");

            if (status == ASB.ASB_NOW_PRINTING)
                errorStatus.Add("* Is printing now", "Yes");
            else
                errorStatus.Add("* Is printing now", "No");

            if (status == ASB.ASB_DRAWER_KICK)
                errorStatus.Add("* Drawer sensor status : ", "Off");
            else
                errorStatus.Add("* Drawer sensor status : ", "On");

            if (status == ASB.ASB_FLASH_MEMORY_REWRITING)
                errorStatus.Add("* FLASH memory rewriting : ", "Yes");
            else
                errorStatus.Add("* FLASH memory rewriting : ", "No");

            if (status == ASB.ASB_AUTORECOVER_ERR)
                errorStatus.Add("* Automatic recovery error : ", "No");
            else
                errorStatus.Add("* Automatic recovery error : ", "Yes");

            if (status == ASB.ASB_UNRECOVER_ERR)
                errorStatus.Add("* Unrecover error : ", "Yes");
            else
                errorStatus.Add("* Unrecover error : ", "No");

            MyCallbackEvent(errorStatus);
            return;
        }

        //	Callback barcode data function sample
        private void CbBarcodeDataFuncSampProc(BarcodeData barcodeData)
        {
            StringBuilder sb = new StringBuilder();

            //  If the data length is -1, it means that the connection status of the barcode scanner disconnected
            if (barcodeData.length == -1)
            {
                sb.Append("Barcode scanner\r\n*  Disconnect");
            }
            // If the data length is 0, it means that the connection status of the barcode scanner connected
            else if (barcodeData.length == 0)
            {
                sb.Append("Barcode scanner\r\n*  Connect");
            }
            // Detected scanned data
            else
            {
                sb.AppendFormat("Received data size : {0}\r\n", barcodeData.length);

                for (int i = 0; i < barcodeData.length; i++)
                {
                    byte scannedData = barcodeData.data[i];
                    if (i < 16)
                    {
                        if (this.IsDataFormatText == true)
                        {
                            sb.Append((scannedData < 0x20 || scannedData > 0x7E) ? '?' : (char)scannedData); // Text data format ( Replace control codes with '?' )
                        }
                        else
                        {
                            sb.AppendFormat("0x{0:x2} ", scannedData);                                       // Binary data format
                        }
                    }
                    else
                    {
                        // Omit the data to be displayed
                        sb.Append("...");
                        break;
                    }
                }
            }

            // Show the connection status of the barcode scanner or barcode data
            //MyCallbackEvent(sb.ToString());
            return;
        }

        //	Sample of open function for printer
        public bool OpenPrinterSamp(string printerName)
        {
            if (m_StatusAPI.IsValid == false) // Open the SDK for the printer if it closed
            {
                ErrorCode returnValue = m_StatusAPI.OpenMonPrinter(OpenType.TYPE_PRINTER, printerName);
                if (returnValue != ErrorCode.SUCCESS)
                {
                    return false;             // SDK open failure
                }
            }
            return true;
        }

        //	Sample of close function for printer
        public void ClosePrinterSamp()
        {
            if (m_StatusAPI.IsValid == true) // Close the SDK for the printer if it opened
            {
                m_StatusAPI.CloseMonPrinter();
            }
        }

        //	Sample of open function for barcode scanner
        public bool OpenScannerSamp(string printerName)
        {
            if (m_BarcodeScannerAPI.IsValid == false) // Open the SDK for the barcode scanner if it closed
            {
                ErrorCode returnValue = m_BarcodeScannerAPI.OpenMonPrinter(OpenType.TYPE_BARCODE_SCANNER, printerName);
                if (returnValue != ErrorCode.SUCCESS)
                {
                    return false;                     // SDK open failure
                }
            }
            return true;
        }

        //	Sample of close function for barcode scanner
        public void CloseScannerSamp()
        {
            if (m_BarcodeScannerAPI.IsValid == true) // Close the SDK for the barcode scanner if it opened
            {
                m_BarcodeScannerAPI.CloseMonPrinter();
            }
        }

        // Sample using bidirectional communication function
        public string DirectIOExSamp()
        {
            string msg;
            ErrorCode returnValue = ErrorCode.SUCCESS;
            bool readFlag = true;
            byte option = 0;
            byte[] readData = new byte[256];
            byte[] receiptData = Encoding.ASCII.GetBytes(RECEIPT_SAMP);

            // Lock Printer
            if ((returnValue = m_StatusAPI.LockPrinter(5000)) != ErrorCode.SUCCESS)
            {
                msg = string.Format("LockPrinter error!! : [ {0} ]\n", returnValue);
            }
            else if ((returnValue = m_StatusAPI.DirectIOEx(HEADER_SAMP, 5000)) != ErrorCode.SUCCESS)
            {
                msg = string.Format("DirectIOEx error!! : [ {0} ]\n", returnValue);
            }
            else if ((returnValue = m_StatusAPI.DirectIOEx(receiptData, 5000)) != ErrorCode.SUCCESS)
            {
                msg = string.Format("DirectIOEx error!! : [ {0} ]\n", returnValue);
            }
            else if ((returnValue = m_StatusAPI.DirectIOEx(BARCODE_SAMP, 5000)) != ErrorCode.SUCCESS)
            {
                msg = string.Format("DirectIOEx error!! : [ {0} ]\n", returnValue);
            }
            else if ((returnValue = m_StatusAPI.DirectIOEx(FEED_SAMP, 5000)) != ErrorCode.SUCCESS)
            {
                msg = string.Format("DirectIOEx error!! : [ {0} ]\n", returnValue);
            }
            else if ((returnValue = m_StatusAPI.DirectIOEx(FOOTER_SAMP, ref readData, 5000, readFlag, option)) != ErrorCode.SUCCESS)
            {
                msg = string.Format("DirectIOEx error!! : [ {0} ]\n", returnValue);
            }
            else
            {
                msg = "DirectIOEx done.\n";
            }
            // Unlock Printer
            m_StatusAPI.UnlockPrinter();
            return msg;
        }

        // Sample of status callback function
        public string CallbackStatusSamp(bool callbackStart)
        {
            string msg;
            ErrorCode returnValue = ErrorCode.SUCCESS;
            if (callbackStart == true)
            {
                if ((returnValue = m_StatusAPI.SetStatusBack()) != ErrorCode.SUCCESS)
                {
                    msg = string.Format("SetStatusBack error!! : [ {0} ]\n", returnValue);
                }
                else
                {
                    msg = "Printer status callback registration succeeded.\r\n\r\nThere is a status that does not correspond to each model.\r\n";
                }
            }
            else
            {
                if ((returnValue = m_StatusAPI.CancelStatusBack()) != ErrorCode.SUCCESS)
                {
                    msg = string.Format("CancelStatusBack error!! : [ {0} ]\n", returnValue);
                }
                else
                {
                    msg = "Printer status callback registration was canceled.\r\n";
                }
            }
            return msg;
        }

        // Sample of barcode data callback function
        public string CallbackBarcodeDataSamp(bool callbackStart)
        {
            string msg;
            ErrorCode returnValue = ErrorCode.SUCCESS;
            if (callbackStart == true)
            {
                if ((returnValue = m_BarcodeScannerAPI.SetBarcodeDataBack()) != ErrorCode.SUCCESS)
                {
                    msg = string.Format("SetBarcodeDataBack error!! : [ {0} ]\n", returnValue);
                }
                else
                {
                    msg = "Barcode data callback registration succeeded.\r\n";
                }
            }
            else
            {
                if ((returnValue = m_BarcodeScannerAPI.CancelBarcodeDataBack()) != ErrorCode.SUCCESS)
                {
                    msg = string.Format("CancelStatusBack error!! : [ {0} ]\n", returnValue);
                }
                else
                {
                    msg = "Barcode data callback registration was canceled.\r\n";
                }
            }
            return msg;
        }

        //	Sample of acquiring the printer information
        public string GetPrnCapabilitySamp()
        {
            byte[] readData;

            if (indexCapability == m_DevInfo.tblGetPrnCap.Length)
            {
                indexCapability = 0;
            }

            string msg = string.Format("GetPrnCapability\r\n\r\n{0} Received data\r\n\r\n", m_DevInfo.tblGetPrnCap[indexCapability].pName);

            ErrorCode returnValue = m_StatusAPI.GetPrnCapability(m_DevInfo.tblGetPrnCap[indexCapability].cmdparam, out readData);
            if (returnValue == ErrorCode.SUCCESS)
            {
                msg += DispMsg(readData, readData.Length);
            }
            else
            {
                msg = string.Format("Error ( {0} ) : [ GetPrnCapability : {1} ]",
                    returnValue, m_DevInfo.tblGetPrnCap[indexCapability].cmdparam);
            }

            indexCapability++;

            return msg;
        }

        // Get the ProgramFiles folder
        static string GetProgramFilesFolder()
        {
            string strArch = System.Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");

            if (strArch == null || strArch == "x86")
            {
                strArch = System.Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432");
                if (strArch == null || strArch == "x86")
                {
                    return Environment.GetEnvironmentVariable("ProgramFiles");
                }
            }

            return Environment.GetEnvironmentVariable("ProgramFiles(x86)");
        }

        //	Sample using command definition file
        public string SendfileSamp()
        {
            StringBuilder sb = new StringBuilder();
            ErrorCode returnValue;
            string strCmdDefFile = GetProgramFilesFolder() + "\\SII\\SDK\\SamplePrograms\\" + DevInfoG10F10.FOLDER_NAME + "\\" + cmdFileName;

            if ((returnValue = m_StatusAPI.SendDataFile(strCmdDefFile)) != ErrorCode.SUCCESS)
            {
                sb.Append(string.Format("SendDataFile error!! : [ {0} ]\r\n", returnValue));
            }
            else
            {
                foreach (string cmdName in tblCmdFile)
                {
                    if ((returnValue = m_StatusAPI.DirectSendRead(cmdName, "Other", 15000)) != ErrorCode.SUCCESS)
                    {
                        sb.Append(string.Format("DirectSendRead error!! : [ {0} : {1} ]\r\n", cmdName, returnValue));
                    }
                    else
                    {
                        sb.Append(string.Format("DirectSendRead({0}) done.\r\n", cmdName));
                    }
                }
            }
            return sb.ToString();
        }

        // Create a message for displaying binary data
        public string DispMsg(byte[] readData, int readLength)
        {
            StringBuilder sb = new StringBuilder();
            uint index = 0;

            if (readLength > 0)
            {
                while (readLength-- > 0)
                {
                    sb.Append(string.Format("0x{0,2:x2} ", readData[index++]));

                    if (index % 6 == 0)
                    {
                        sb.Append("\r\n");
                    }
                    else if (index > 30)
                    {
                        sb.Append("....");
                        break;
                    }
                }
            }
            else
            {
                sb.Append("NO DATA !!");
            }
            return sb.ToString();
        }
    }
}
