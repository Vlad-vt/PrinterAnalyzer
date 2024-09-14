namespace PrinterAnalyzer.Communication.RP_F10_G10
{
    class DevInfoG10F10
    {
        // Define printer name
        public const string DEVICE_NAME = "SII ";
        public const string FOLDER_NAME = "PosPrinter";

        // Command table definition for GetPrnCapability function
        public struct GetPrnCapStruct
        {
            // Message string
            public string pName;
            // Command param
            public byte cmdparam;

            public GetPrnCapStruct(string name, byte i)
            {
                // Message string
                pName = name;
                // Command param
                cmdparam = i;
            }
        }

        public GetPrnCapStruct[] tblGetPrnCap = new GetPrnCapStruct[]
        {
            new GetPrnCapStruct("Device ID",        1 ),
            new GetPrnCapStruct("Type ID",          2 ),
            new GetPrnCapStruct("Rom Version ID",   3 ),
            new GetPrnCapStruct("F/W Version Main", 65),
            new GetPrnCapStruct("Manufacturer",     66),
            new GetPrnCapStruct("Model name",       67),
            new GetPrnCapStruct("F/W Version Boot", 97),
            new GetPrnCapStruct("F/W Checksum Boot",98),
            new GetPrnCapStruct("F/W Checksum Main",99),
            new GetPrnCapStruct("F/W Checksum Both",100)
        };
    }
}
