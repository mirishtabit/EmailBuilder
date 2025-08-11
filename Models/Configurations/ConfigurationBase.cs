using EmailBuilder.Common;
using Newtonsoft.Json;

namespace EmailBuilder.Models.Configurations
{
    /// <summary>
    /// Base class for configuration of HTML elements.
    /// </summary>
    public class ConfigurationBase
    {
        #region element properties
       
        [JsonProperty(Required = Required.Always)]
        public string BackgroundColor { get; set; } = "transparent";

       
        #endregion
        #region element style helpers

        protected string BlockAlignmentAttr(Position BlockAlignment)
        {
           return $"align='{BlockAlignment.ToString().ToLower()}'";
        }

        public string RoundedCornersStyle(int RoundedCorners)
        {
           return $"border-radius:{RoundedCorners}px;";
        }

        public string TableMsoAttributes
        {
            get
            {
                return "cellpadding=\"0\" cellspacing=\"0\" border=\"0\" role=\"presentation\"";
            }
        }

        public string BackColorStyle(string value)
        {
           return !string.IsNullOrEmpty(value) ? $"background-color:{value};" : string.Empty;  
        }

        public string BackColorAttr(string value)
        {
           return !string.IsNullOrEmpty(value) ? $"bgcolor=\"{value}\"" : string.Empty;
        }


        #endregion

        public ConfigurationBase()
        {

        }

    }

}