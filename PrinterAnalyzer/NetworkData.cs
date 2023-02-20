using PrinterAnalyzer.MVVM.Model.PrinterProperties;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PrinterAnalyzer.Enums;

namespace PrinterAnalyzer
{
    internal class NetworkData
    {
        private static NetworkData _singleton;

        private List<string> defaultPrinterSettingsDevices;

        public Dictionary<PrinterType,string> printersId { get; set; }

        public int CanPrintPage { get; set; }

        public static NetworkData GetInstance()
        {
            if(_singleton == null)
            {
                _singleton = new NetworkData();
            }
            return _singleton;
        }

        public NetworkData()
        {
            defaultPrinterSettingsDevices = new List<string>();
            printersId = new Dictionary<PrinterType, string>();
            CanPrintPage = 0;
        }

        /// <summary>
        /// This method will get command from WEB API
        /// </summary>
        /// <param name="printerType"></param>
        /// <returns></returns>
        public async Task<string> GetCommands(PrinterType printerType)
        {

            using (var client = new HttpClient())
            {
                var requestContent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("MachineName", System.Environment.MachineName),
                new KeyValuePair<string, string>("PrinterType", printerType.ToString()),
                new KeyValuePair<string, string>("getCurrentSettings", "Give me Data!")
            });
                defaultPrinterSettingsDevices.Add(printerType.ToString());
                var response = await client.PostAsync("https://seiko.hosting9.tn-rechenzentrum1.de/api/api.php", requestContent);

                var responseContent = await response.Content.ReadAsStringAsync();

                return responseContent;
            }
        }

        public async Task<string> SendInfoAboutPrint(PrinterType printerType, string id)
        {

            using (var client = new HttpClient())
            {
                var requestContent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("MachineName", System.Environment.MachineName),
                new KeyValuePair<string, string>("PrinterType", printerType.ToString()),
                new KeyValuePair<string, string>("PrintingPageDone", id)
            });
                defaultPrinterSettingsDevices.Add(printerType.ToString());
                var response = await client.PostAsync("https://seiko.hosting9.tn-rechenzentrum1.de/api/api.php", requestContent);

                var responseContent = await response.Content.ReadAsStringAsync();

                return responseContent;
            }
        }

        public async Task<string> SendInfoAboutChanges(PrinterType printerType, string id)
        {

            using (var client = new HttpClient())
            {
                var requestContent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("MachineName", System.Environment.MachineName),
                new KeyValuePair<string, string>("PrinterType", printerType.ToString()),
                new KeyValuePair<string, string>("ChangesDone", id)
            });
                defaultPrinterSettingsDevices.Add(printerType.ToString());
                var response = await client.PostAsync("https://seiko.hosting9.tn-rechenzentrum1.de/api/api.php", requestContent);

                var responseContent = await response.Content.ReadAsStringAsync();

                return responseContent;
            }
        }

        /// <summary>
        /// This method will send default printer settings
        /// </summary>
        /// <param name="printerType"></param>
        /// <param name="propertiesList"></param>
        /// <returns></returns>
        public async Task<string> SendDefaultSettings(PrinterType printerType, Dictionary<PropertyType, Dictionary<int, string>> propertiesList)
        {
            bool sendDefSet = true;

            for(int i = 0; i < defaultPrinterSettingsDevices.Count; i++)
            {
                if(printerType.ToString() == defaultPrinterSettingsDevices[i])
                    sendDefSet = false;
            }
            if (!sendDefSet)
                return null;

            string json = JsonConvert.SerializeObject(propertiesList, Formatting.Indented);

            using (var client = new HttpClient())
            {
                var requestContent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("MachineName", System.Environment.MachineName),
                new KeyValuePair<string, string>("PrinterGeneralType", printerType.ToString()),
                new KeyValuePair<string, string>("DefaultPrinterSettings", json)
            });
                defaultPrinterSettingsDevices.Add(printerType.ToString());
                var response = await client.PostAsync("https://seiko.hosting9.tn-rechenzentrum1.de/api/api.php", requestContent);

                var responseContent = await response.Content.ReadAsStringAsync();
                
                return responseContent;
            }
        }
        /// <summary>
        /// This method will send current printer settings
        /// </summary>
        /// <param name="printerType"></param>
        /// <param name="currentProperties"></param>
        /// <returns></returns>
        public async Task<string> SendSettings(PrinterType printerType, Dictionary<PropertyType, int> currentProperties)
        {
            var json = JsonConvert.SerializeObject(currentProperties, Formatting.Indented);
            using (var client = new HttpClient())
            {
                var requestContent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("MachineName", System.Environment.MachineName),
                new KeyValuePair<string, string>("PrinterType", printerType.ToString()),
                new KeyValuePair<string, string>("CurrentSettings", json),
            });

                var response = await client.PostAsync("https://seiko.hosting9.tn-rechenzentrum1.de/api/api.php", requestContent);

                var responseContent = await response.Content.ReadAsStringAsync();

                return responseContent;
            }
        }
        /// <summary>
        /// This method will send current printer status
        /// </summary>
        /// <returns></returns>
        public async Task<string> SendStatus(PrinterType printerType, string status, string errors)
        {
            using (var client = new HttpClient())
            {
                var requestContent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("MachineName", System.Environment.MachineName),
                new KeyValuePair<string, string>("PrinterType", printerType.ToString()),
                new KeyValuePair<string, string>("Status", status),
                new KeyValuePair<string, string>("Errors", errors)
            });

                var response = await client.PostAsync("https://seiko.hosting9.tn-rechenzentrum1.de/api/api.php", requestContent);

                var responseContent = await response.Content.ReadAsStringAsync();

                return responseContent;
            }
        }
    }
}
