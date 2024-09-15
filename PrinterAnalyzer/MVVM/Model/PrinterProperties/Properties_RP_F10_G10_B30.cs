using PrinterAnalyzer.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrinterAnalyzer.MVVM.Model.PrinterProperties
{
    public class Properties_RP_F10_G10_B30 : Properties
    {
        private Dictionary<PropertyType, Dictionary<int , string>> PropertiesList { get; set; }

        public Dictionary<PropertyType, int> CurrentProperties { get; set; }

        public bool ChangesDone { get; set; }

        public Properties_RP_F10_G10_B30(PrinterType printerType)
        {
            PropertiesList = new Dictionary<PropertyType, Dictionary<int,string>>();
            CurrentProperties = new Dictionary<PropertyType, int>();
            PropertiesInit(printerType);
            ChangesDone = true;

        }

        public Dictionary<PropertyType, Dictionary<int, string>> GetDefaultPrinterSettings()
        {
            foreach (var outerEntry in PropertiesList)
            {
                Console.WriteLine($"PropertyType: {outerEntry.Key}");
                foreach (var innerEntry in outerEntry.Value)
                {
                    Console.WriteLine($"\tID: {innerEntry.Key}, Value: {innerEntry.Value}");
                }
            }

            return PropertiesList;
        }

        public Dictionary<PropertyType, int> GetCurrentPrinterSettings(string PrinterName, ref SII.SDK.PosPrinter.StatusAPI statusAPI)
        {
            Dictionary<PropertyType, int> tempDictionary = PrinterSettings.GetCurrentProperties(PrinterName, ref statusAPI);
            foreach (PropertyType propertyType in Enum.GetValues(typeof(PropertyType)))
            {
                if (tempDictionary.GetValueOrDefault(propertyType) != CurrentProperties.GetValueOrDefault(propertyType))
                {
                    ChangesDone = true;
                    break;
                }
            }
            CurrentProperties = tempDictionary;
            return CurrentProperties;
        }

        public void ChangeParameter(string PrinterName, ref SII.SDK.PosPrinter.StatusAPI statusAPI ,PropertyType property, int id)
        {
            PrinterSettings.ChangePrinterSetting(PrinterName, ref statusAPI, property, id);
        }

        public async Task ChangeParameterAsync(string PrinterName, SII.SDK.PosPrinter.StatusAPI statusAPI, PropertyType property, int id)
        {
            await PrinterSettings.ChangePrinterSettingAsync(PrinterName, statusAPI, property, id);
        }




        public void ChangeParameters(string PrinterName, ref SII.SDK.PosPrinter.StatusAPI statusAPI, Dictionary<PropertyType, int> settingsList)
        {
            PrinterSettings.ChangePrinterSettings(PrinterName, ref statusAPI, settingsList);
        }

        private void PropertiesInit(PrinterType printerType)
        {
            switch(printerType) 
            {
                case PrinterType.SII_RP_F10:
                    PropertiesList.Add(PropertyType.Speed, new Dictionary<int, string>
                    {  {0, "High" },
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
                    });
                    break;
                case PrinterType.SII_MP_B30L:
                    PropertiesList.Add(PropertyType.Speed, new Dictionary<int, string>
                    {  {0, "Standard" },
                       {1, "Quality1" },
                       {2, "Quality2" }
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
                        {9, "Lower Right" }
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
                    });
                    PropertiesList.Add(PropertyType.PageStartLogo, new Dictionary<int, string>
                    {
                        {0, "None" },
                        {1, "Left" },
                        {2, "Center" },
                        {3, "Right" }
                    });
                    PropertiesList.Add(PropertyType.PageEndLogo, new Dictionary<int, string>
                    {
                        {0, "None" },
                        {1, "Left" },
                        {2, "Center" },
                        {3, "Right" }
                    });
                    PropertiesList.Add(PropertyType.PaperSize, new Dictionary<int, string>
                    {
                        {0, "Letter" },
                        {1, "A4" },
                        {2, "80 mm (72×3276 mm)" },
                        {3, "58 mm (54×3276 mm) *4" },
                        {5, "76.2 mm (72×3276 mm) *4" },
                        {6, "76.2 mm (70×3276 mm) *4" },
                        {7, "58 mm (52×3276 mm) *4" }
                    });
                    PropertiesList.Add(PropertyType.Preset, new Dictionary<int, string>
                    {
                        {1, "58 mm Receipt Setting" },
                        {3, "58 mm Mark or Gap Form Feed Setting" },
                        {118, "58 mm Mark or Gap Form Feed Setting (Label)" },
                        {5, "A4->58 mm Reduction Setting" },
                        {152, "76.2 mm Receipt Setting" },
                        {153, "76.2 mm Mark or Gap Form Feed Setting" },
                        {154, "76.2 mm Mark or Gap Form Feed Setting (Label)" },
                        {155, "A4->76.2 mm Reduction Setting" },
                        {160, "80 mm Receipt Setting" },
                        {161, "80 mm Mark or Gap Form Feed Setting" },
                        {162, "80 mm Mark or Gap Form Feed Setting (Label)" },
                        {163, "A4->80 mm Reduction Setting" },
                        {255, "User setting" }
                    });
                    PropertiesList.Add(PropertyType.MarkFeed, new Dictionary<int, string>
                    {
                        {0, "No form feed" },
                        {1, "By pages" },
                        {2, "By jobs" }
                    });
                    break;

            }
        }
    }
}
