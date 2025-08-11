
using EmailBuilder.Common;
using EmailBuilder.Converters;
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

        [JsonIgnore]
        public EbWidth Width { get; set; } = new EbWidth(SizeUnit.Both);
        #endregion

        #region element style helpers
        internal string Td1Style
        {
            get
            {
                string styles = $"{Spacing.GetOuterHtmlStyle}";
                string attributes = $"align =\"center\"";
                return $"style=\"{styles}\" {attributes}";
            }
        }

        internal string Tbl1Style
        {
            get
            {
                string styles = $"{BackgroundImage.GetHtmlStyle} {BackColorStyle(BackgroundColor)} {Width.WidthStyle}";
                string attributes = $"{BackColorAttr(BackgroundColor)} {Width.WidthAttr} {TableMsoAttributes}";
                return $"style=\"{styles}\" {attributes}";
            }
        }

        internal string Tbl2Style
        {
            get
            {
                string styles = $"{BackColorStyle(BodyColor)} {RoundedCornersStyle(RoundedCorners)} {Border.GetHtmlStyle} {Width.WidthTblStyle}";
                string attributes = $"{BackColorAttr(BodyColor)} {Width.WidthAttr} {TableMsoAttributes}";
                return $"style=\"{styles}\" {attributes}";
            }
        }

        internal string Td2Style
        {
            get
            {
                string styles = $"{Spacing.GetHtmlStyle}";
                return $"style=\"{styles}\"";
            }
        }

        internal string Td3Style
        {
            get
            {
                string styles = $"{Spacing.GetHtmlStyle}";
                string attributes = $"{Width.WidthAttr} align=\"center\"";
                return $"style=\"{styles}\" {attributes}";
            }
        }
        #endregion
        
        public SectionConfiguration()
        {
        }
    }

}