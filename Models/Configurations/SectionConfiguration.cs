
using EmailBuilder.Models.Configurations.SubConfiguration;
using EmailBuilder.Models.HtmlProperties;
using EmailBuilder.Models.Properties;
using Newtonsoft.Json;

namespace EmailBuilder.Models.Configurations
{
    /// <summary>
    /// Represents the configuration for a section element in an email template.
    /// </summary>

    public class SectionConfiguration:ConfigurationBase
    {
        #region element properties

        [JsonProperty(Required = Required.Always)]
        public EbBorder Border { get; set; } = new EbBorder();

        [JsonProperty(Required = Required.Always)]
        public int RoundedCorners { get; set; } = 0;

        [JsonProperty(Required = Required.Always)]
        public SpacingBase Spacing { get; set; } = new SpacingBase();

        [JsonProperty(Required = Required.Always)]
        public EbBackgroundImage BackgroundImage { get; set; } = new EbBackgroundImage();

        [JsonProperty(Required = Required.Always)]
        public string BodyColor { get; set; } = string.Empty;


        #endregion

        #region element style helpers
        public string Td1Style
        {
            get
            {
                string styles = $"{Spacing.GetOuterHtmlStyle}";
                string attributes = $"align =\"center\"";
                return $"style=\"{styles}\" {attributes}";
            }
        }

        public string Tbl1Style
        {
            get
            {
                string styles = $"{BackgroundImage.GetHtmlStyle} {BackColorStyle(BackgroundColor)} {WidthStyle}";
                string attributes = $"{BackColorAttr(BackgroundColor)} {WidthAttr} {TableMsoAttributes} role=\"presentation\"";
                return $"style=\"{styles}\" {attributes}";
            }
        }

        public string Tbl2Style
        {
            get
            {
                string styles = $"{BackColorStyle(BodyColor)} {RoundedCornersStyle(RoundedCorners)} {Border.GetHtmlStyle} {WidthTblStyle}";
                string attributes = $"{BackColorAttr(BodyColor)} {WidthAttr} {TableMsoAttributes} role=\"presentation\"";
                return $"style=\"{styles}\" {attributes}";
            }
        }

        public string Td2Style
        {
            get
            {
                string styles = $"{Spacing.GetHtmlStyle}";
                return $"style=\"{styles}\"";
            }
        }

        public string Td3Style
        {
            get
            {
                string styles = $"{Spacing.GetHtmlStyle}";
                string attributes = $"{WidthAttr} align=\"center\"";
                return $"style=\"{styles}\" {attributes}";
            }
        }
        #endregion
        
        public SectionConfiguration()
        {
        }
    }

}