using EmailBuilder.Common;
using EmailBuilder.Models.HtmlProperties;
using EmailBuilder.Models.Properties;

namespace EmailBuilder.Models.Configurations
{
    public class ConfigurationBase
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Position BlockAlignment { get; set; } = Position.Center;
        public virtual SpacingBase Spacing { get; set; } = new SpacingBase();
        public EbBorder Border { get; set; } = new EbBorder();
        public string BackgroundColor { get; set; } = "transparent";
        public EbBackgroundImage BackgroundImage { get; set; } = new EbBackgroundImage();
        public int RoundedCorners { get; set; } = 0;


        private string _width=string.Empty;
        private string _widthNumericValue = string.Empty;
        
        public string Width
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
                if (PropertyValidator.ValidateSizeCordinates(value, out var numeric))
                {
                    _width = value;
                    _widthNumericValue = numeric;
                }
            }
        }

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

        public string BlockAlignmentAttr
        {
            get
            {
                return $"align='{BlockAlignment.ToString().ToLower()}'";
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

        public string RoundedCornersStyle
        {
            get
            {
                return $"border-radius:{RoundedCorners}px;";
            }
        }

        public string IdAttr
        {
            get
            {
                return !string.IsNullOrEmpty(Id) ? $"id=\"{Id}\"" : string.Empty;
            }
        }

        public string NameAttr
        {
            get
            {
                return !string.IsNullOrEmpty(Id) ? $"id=\"{Name}\"" : string.Empty;
            }
        }

        public string TableMsoAttributes
        {
            get
            {
                return "cellpadding=\"0\" cellspacing=\"0\" border=\"0\"";
            }
        }
        public ConfigurationBase()
        {
           
        }

    }

}