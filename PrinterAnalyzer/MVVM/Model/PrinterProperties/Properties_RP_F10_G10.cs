using System.Collections.Generic;

namespace PrinterAnalyzer.MVVM.Model.PrinterProperties
{
    internal class Properties_RP_F10_G10
    {
        public Dictionary<PropertyType, List<string>> Properties { get; set; }

        public Properties_RP_F10_G10()
        {
            Properties = new Dictionary<PropertyType, List<string>>();
            Properties.Add(PropertyType.Speed, new List<string> 
            { "High", "Middle(Quality)", "Middle (Silent)" });
            Properties.Add(PropertyType.Margin, new List<string> 
            { "Minimum margin", "Minimum top margin", "Minimum bottom margin", "Maximum margin" });
            Properties.Add(PropertyType.FeedToCutPosition, new List<string>
            {  "Enabled", "Disabled" });
           // Properties.Add
        }
    }
}
