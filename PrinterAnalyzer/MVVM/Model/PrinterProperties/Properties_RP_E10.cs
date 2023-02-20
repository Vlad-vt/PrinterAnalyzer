using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterAnalyzer.MVVM.Model.PrinterProperties
{
    public class Properties_RP_E10 : Properties
    {
        private Dictionary<PropertyType, Dictionary<int, string>> PropertiesList { get; set; }

        public Dictionary<PropertyType, int> CurrentProperties { get; set; }

        public bool ChangesDone { get; set; }

        public Properties_RP_E10()
        {
            PropertiesList = new Dictionary<PropertyType, Dictionary<int, string>>();
            CurrentProperties = new Dictionary<PropertyType, int>();
            #region Properties Initialization

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

            #endregion
            ChangesDone = true;
        }

        public Dictionary<PropertyType, Dictionary<int, string>> GetDefaultPrinterSettings()
        {
            return PropertiesList;
        }

        public Dictionary<PropertyType, int> GetCurrentPrinterSettings(string PrinterName, ref SiiPrinterSdk.StatusAPI statusAPI)
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

        public void ChangeParameter(string PrinterName, ref SiiPrinterSdk.StatusAPI statusAPI, PropertyType property, int id)
        {
            PrinterSettings.ChangePrinterSetting(PrinterName, ref statusAPI, property, id);
        }
    }
}
