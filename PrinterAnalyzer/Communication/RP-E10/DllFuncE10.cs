using SiiPrinterSdk;
using System;
using System.Text;

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
