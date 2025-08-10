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

        private string _width=string.Empty;
        private string _widthNumericValue = string.Empty;

        public virtual string Width
        {
            get
            {
                if (string.IsNullOrEmpty(_width))
                    _width = "100%";
                return _width;
            }
            set
            {
                // ValidateSizeCoordinates returns true if “value” is valid
                // and spits out the numeric part into out _widthNumericValue
                if (PropertyValidator.ValidateSizeCordinates(value,SizeUnit.Both,out var numeric))
                {
                    _width = value;
                    _widthNumericValue = numeric;
                }
            }
        }

        #endregion
        #region element style helpers

        public string WidthNumericValue
        {
            get
            {
                return _widthNumericValue;
            }  
        }

        public string WidthStyle
        {
            get
            {
                return $"width:{Width};";
            }
        }
        
        public string WidthTblStyle
        {
            get
            {
                return $"width:100% !important; max-width:{Width};";
            }
        }

        public string WidthAttr
        {
            get
            {
                return string.IsNullOrEmpty(WidthNumericValue) ? "width='100%'" : $"width='{WidthNumericValue}'";
            }
        }

        public string BlockAlignmentAttr(Position BlockAlignment)
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
                return "cellpadding=\"0\" cellspacing=\"0\" border=\"0\"";
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