namespace PrinterAnalyzer.Communication.RP_E10
{
    class DevInfo
    {
        // Sample commands
        public static byte[] footerCmd = { 0x12, 0x71, 0x00 };

        // Define byte commands for GetPrnCapability()
        public static byte[] tblCapability =
        {
            1,
            2,
            3,
            65,
            66,
            67,
            69
        };

        // Define short commands for GetCounter()
        public static byte[] tblCounterId =
        {
            20,
            21,
            50,
            70,
            148,
            149,
            178,
            198
        };
    }
}
