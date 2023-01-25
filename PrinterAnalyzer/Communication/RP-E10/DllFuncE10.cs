using SiiPrinterSdk;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PrinterAnalyzer.Communication.RP_E10
{
    public class DllFuncE10
    {
        public delegate void callbackEventHandler(string msg);
        public event callbackEventHandler myCallbackEvent;


        static uint indexCapability = 0;        // Index of the table for ID of the GetPrinCapability function. 
        static uint indexCounter = 0;           // Index of the table for ID of the GetCounter function.
        static uint callbackMsgNum = 0;         // Message number for the callback

        private string msg = "";
        internal StatusAPI m_StatusAPI;        // .NET API class

        public DllFuncE10()
        {
            m_StatusAPI = new StatusAPI();
            m_StatusAPI.StatusCallback += new StatusAPI.StatusCallbackHandler(CbFuncSampProc);
        }

        //	Callback status function sample
        private void CbFuncSampProc(ASB status)
        {
            Dictionary<string, string> errorStatus = new Dictionary<string, string>();
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
                errorStatus.Add("");
            else
                errorStatus.Add("");

            if (status == ASB.ASB_DRAWER_KICK)
                errorStatus.Add();
            else
                errorStatus.Add();

            if (status == ASB.ASB_FLASH_MEMORY_REWRITING)
                errorStatus.Add();
            else
                errorStatus.Add();

            if (status == ASB.ASB_AUTORECOVER_ERR)
                errorStatus.Add();
            else
                errorStatus.Add();

            if (status == ASB.ASB_UNRECOVER_ERR)
                errorStatus.Add("", "Yes");
            else
                errorStatus.Add("", "No");

            StringBuilder sb = new StringBuilder();
             sb.Append("* Voltage error : ");
                sb.Append(((status & ASB.ASB_VP_ERR) == 0) ? "No\r\n" : "Yes\r\n");
                sb.Append("* Head temp error : ");
                sb.Append(((status & ASB.ASB_HEAD_TEMPERATUR_ERR) == 0) ? "No\r\n" : "Yes\r\n");
                sb.Append("* AutoCutter error : ");
                sb.Append(((status & ASB.ASB_AUTOCUTTER_ERR) == 0) ? "No\r\n" : "Yes\r\n");
                sb.Append("* Out-of-paper error : ");
                sb.Append(((status & ASB.ASB_RECEIPT_END) == 0) ? "No\r\n" : "Yes\r\n");
                sb.Append("* Paper-near-end error : ");
                sb.Append(((status & ASB.ASB_RECEIPT_NEAR_END) == 0) ? "No\r\n" : "Yes\r\n");
                sb.Append("* Mark paper jam error : ");
                sb.Append(((status & ASB.ASB_MARK_PAPER_JAM_ERR) == 0) ? "No\r\n" : "Yes\r\n");
                sb.Append("* Cover/Platen open error : ");
                sb.Append(((status & ASB.ASB_COVER_OPEN) == 0) ? "No\r\n" : "Yes\r\n");
                sb.Append("* Feed switch status : ");
                sb.Append(((status & ASB.ASB_PAPER_FEED) == 0) ? "Off\r\n" : "On\r\n");
                sb.Append("* Paper feed status : ");
                sb.Append(((status & ASB.ASB_NOW_PRINTING) == 0) ? "Stop\r\n" : "Operating\r\n");
                sb.Append("* Return-waiting status : ");
                sb.Append(((status & ASB.ASB_RETURN_WAITING) == 0) ? "No\r\n" : "Yes\r\n");
                sb.Append("* Drawer sensor status : ");
                sb.Append(((status & ASB.ASB_DRAWER_KICK) == 0) ? "Off\r\n" : "On\r\n");
                sb.Append("* FLASH memory rewriting : ");
                sb.Append(((status & ASB.ASB_FLASH_MEMORY_REWRITING) == 0) ? "No\r\n" : "Yes\r\n");
                sb.Append("* Automatic recovery error : ");
                sb.Append(((status & ASB.ASB_AUTORECOVER_ERR) == 0) ? "No\r\n" : "Yes\r\n");
                sb.Append("* Unrecover error : ");
                sb.Append(((status & ASB.ASB_UNRECOVER_ERR) == 0) ? "No\r\n" : "Yes\r\n");
            msg = string.Format("[{0:D2}] {1}", callbackMsgNum++, status);
            myCallbackEvent(msg);

            return;
        }



        //	Sample of OpenMonPrinter
        public bool OpenSamp(string printerName)
        {
            if (m_StatusAPI.IsValid == true)
            {
                CloseSamp();
            }
            ErrorCode returnValue = m_StatusAPI.OpenMonPrinter(OpenType.TYPE_PRINTER, printerName);
            if (returnValue == ErrorCode.SUCCESS)
            {
                return true;
            }
            return false;
        }

        //	Sample of CloseMonPrinter
        public void CloseSamp()
        {
            if (m_StatusAPI.IsValid == true)
            {
                m_StatusAPI.CloseMonPrinter();
            }
        }



        //	Sample of DirectIOEx 
        public String DirectIOExSamp()
        {
            ErrorCode returnValue = 0;
            int timeout = 3000;
            bool readFlag = true;
            byte option = 0;

            byte[] readData = new byte[256];
            byte[] writeData = Encoding.ASCII.GetBytes("Seiko Instruments Inc.\r\n");

            returnValue = m_StatusAPI.DirectIOEx(writeData, timeout);      // Sample Print Data
            returnValue = m_StatusAPI.DirectIOEx(DevInfoE10.footerCmd, ref readData, timeout, readFlag, option);
            if (returnValue == ErrorCode.SUCCESS)
            {
                msg = string.Format("[ DirectIOEx ]\r\n\r\n");
                DispMsg(readData, readData.Length);
            }
            else
            {
                msg = string.Format("Error ( {0} ) : [ DirectIOEx ]", returnValue);
            }
            return msg;
        }

        //	Sample of SetStatusBack & CancelStatusBack
        public void CallbackSamp(bool callbackStart)
        {
            if (callbackStart)
            {
                m_StatusAPI.SetStatusBack();
            }
            else
            {
                m_StatusAPI.CancelStatusBack();
            }
        }

        //	Sample of GetPrnCapability
        public string GetPrnCapabilitySamp()
        {
            byte[] readData;

            if (indexCapability == DevInfoE10.tblCapability.Length)
            {
                indexCapability = 0;
            }

            msg = string.Format("[ GetPrnCapability : {0} ]\r\n\r\n", DevInfoE10.tblCapability[indexCapability]);

            ErrorCode returnValue = m_StatusAPI.GetPrnCapability(DevInfoE10.tblCapability[indexCapability], out readData);
            if (returnValue == ErrorCode.SUCCESS)
            {
                DispMsg(readData, readData.Length);
            }
            else
            {
                msg = string.Format("Error ( {0} ) : [ GetPrnCapability : {1} ]",
                    returnValue, DevInfoE10.tblCapability[indexCapability]);
            }

            indexCapability++;

            return msg;
        }

        //	Sample of GetCounter
        public string GetCounterSamp()
        {
            int readData;

            if (indexCounter == DevInfoE10.tblCounterId.Length)
            {
                indexCounter = 0;
            }

            ErrorCode returnValue = m_StatusAPI.GetCounter(DevInfoE10.tblCounterId[indexCounter], out readData);
            if (returnValue == 0)
            {
                msg = string.Format("[ GetCounter = {0} ]\r\n\r\n{1}",
                    DevInfoE10.tblCounterId[indexCounter], readData);
            }
            else
            {
                msg = string.Format("Error ( {0} ) : [ GetCounter = {1} ]",
                    returnValue, DevInfoE10.tblCounterId[indexCounter]);
            }

            indexCounter++;
            return msg;
        }

        //	Display 
        public void DispMsg(byte[] readData, int readLength)
        {
            uint index = 0;

            if (readLength > 0)
            {
                while (readLength-- > 0)
                {
                    string tmpMsg = "";
                    tmpMsg = string.Format("0x{0,2:x2} ", readData[index++]);
                    msg += tmpMsg;

                    if (index % 6 == 0)
                    {
                        msg += "\r\n";
                    }
                    else if (index > 30)
                    {
                        msg += "....";
                        break;
                    }
                }
            }
            else
            {
                msg += "NO DATA !!";
            }
        }
    }
}
