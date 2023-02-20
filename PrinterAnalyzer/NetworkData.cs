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
        }

        public async Task<string> SendDefaultSettings(PrinterType printerType, Dictionary<PropertyType, Dictionary<int, string>> propertiesList)
        {
            /*Dictionary<PropertyType, Dictionary<int, string>> PropertiesList;
            PropertiesList = new Dictionary<PropertyType, Dictionary<int, string>>();
            PropertiesList.Add(PropertyType.Speed, new Dictionary<int, string>
            {  {0, "High" },
               {2, "Low" },
               {1, "Middle(Quality)" },
               {3, "Middle (Silent)" }
            });
            PropertiesList.Add(PropertyType.Margin, new Dictionary<int, string>
            { {0, "Minimum margin" },
              {1, "Minimum top margin" },
              {2, "Minimum bottom margin" },
              {3, "Maximum margin" }
            });
            PropertiesList.Add(PropertyType.FeedToCutPosition, new Dictionary<int, string>
            {
                {0, "Enabled" },
                {1, "Disabled" }
            });
            PropertiesList.Add(PropertyType.PaperCut, new Dictionary<int, string>
            {
                {0, "NoCut" },
                {1, "Full_Cut_By_Jobs" },
                {2, "Partial_Cut_By_Jobs" },
                {3 ,"Full_Cut_By_Pages" },
                {4, "Partial_Cut_By_Pages" },
                {5, "Partial_Cut_Between_Pages" }
            });
            PropertiesList.Add(PropertyType.Watermark, new Dictionary<int, string>
            {
                {0, "None" },
                {1, "Upper Left" },
                {2, "Top Center" },
                {3 ,"Upper Right" },
                {4, "Left" },
                {5, "Center" },
                {6, "Right" },
                {7, "Lower Left" },
                {8, "Bottom Center" },
                {9, " Lower Right" }
            });
            PropertiesList.Add(PropertyType.Orientation, new Dictionary<int, string>
            {
                {0, "Portrait" },
                {1, "Landscape" }
            });
            PropertiesList.Add(PropertyType.Direction, new Dictionary<int, string>
            {
                {0, "Forward" },
                {1, "Backward" }
            });*/

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

        public async Task<string> SendStatus()
        {
            using (var client = new HttpClient())
            {
                var requestContent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("MachineName", System.Environment.MachineName),
                new KeyValuePair<string, string>("PrinterType", "pass123")
            });

                var response = await client.PostAsync("https://seiko.hosting9.tn-rechenzentrum1.de/api/api.php", requestContent);

                var responseContent = await response.Content.ReadAsStringAsync();

                return responseContent;
            }
        }
    }
}
