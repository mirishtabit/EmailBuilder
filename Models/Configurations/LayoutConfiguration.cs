
using EmailBuilder.Common;
using EmailBuilder.Models.Configurations.SubConfiguration;
using EmailBuilder.Models.Properties;
using EmailBuilder.Models.Properties.Spacing;
using Newtonsoft.Json;
using System.Text;

namespace EmailBuilder.Models.Configurations
{

    public class LayoutConfiguration: ConfigurationBase
    {
        public DefaultTagStyles DefaultTagStyles { get; set; }

        public DefaultGeneralStyles DefaultGeneralStyles { get; set; } 

        public override SpacingBase Spacing { get; set; } = new EbLayoutSpacing();

        public string BodyColor { get; set; } = string.Empty;

        [JsonProperty("BodyWidth")]
        public new string Width
        {
            get => base.Width;
            set => base.Width = value;
        }

        public LayoutConfiguration()
        {}


        #region element properties


        public string Tbl1Style
        {
            get
            {
                string styles = $"{BackColorStyle(BackgroundColor)} {BackgroundImage.GetHtmlStyle}";
                string attributes = $"{BackColorAttr(BackgroundColor)} {TableMsoAttributes} width=\"100%\" align=\"center\"";
                return $"style=\"{styles}\" {attributes}";
            }
        }

        public string Td1Style
        {
            get
            {
                string styles = $"{Spacing.GetHtmlStyle}";
                string attributes = $"width=\"100%\" align=\"center\"";
                return $"style=\"{styles}\" {attributes}";
             
            }
        }

        public string InnerStyle
        {
            get
            {
               
                string styles = $"{WidthTblStyle} {BackColorStyle(BodyColor)}";
                string attributes = $"{BackColorAttr(BodyColor)} {WidthAttr} {TableMsoAttributes}";
                return $"style=\"{styles}\" {attributes}";
            }
        }

        #endregion

        public string GenerateCssStyles()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(DefaultGeneralStyles.GenerateCssStyles());
            sb.Append(DefaultTagStyles.GenerateCssStyles());
            return sb.ToString();

        }
    }
}
