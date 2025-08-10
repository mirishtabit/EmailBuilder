using EmailBuilder.Common;
using EmailBuilder.Models.HtmlProperties;
using EmailBuilder.Models.Properties;
using Newtonsoft.Json;

namespace EmailBuilder.Models.Configurations
{
    /// <summary>
    /// Represents the configuration for an image element in an email template.
    /// </summary>
    public class ImageConfiguration : ConfigurationBase
    {
        #region element properties

        [JsonProperty(Required = Required.Always)]
        public SpacingBase Spacing { get; set; } = new SpacingBase();

        [JsonProperty(Required = Required.Always)]
        public int RoundedCorners { get; set; } = 0;

        [JsonProperty(Required = Required.Always)]
        public Position BlockAlignment { get; set; } = Position.Center;

        [JsonProperty(Required = Required.Always)]
        public EbBorder Border { get; set; } = new EbBorder();

        [JsonProperty(Required = Required.Always)]
        public override string Width { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string ImageUrl { get; set; } = string.Empty;

        [JsonProperty(Required = Required.Always)]
        public string AltText { get; set; } = string.Empty;

        [JsonProperty(Required = Required.Always)]
        public EbLink Link { get; set; }
       

        #endregion

        #region element style helpers

        public string ImageUrlAttr
        {
            get
            {
                return $"src=\"{ImageUrl}\"";
            }    
        }
        public string AltTextAttr
        {
            get
            {
                return $"alt=\"{AltText}\"";
            }
        }
        public string Td1Style
        {
            get
            {
                string styles = $"{Spacing.GetOuterHtmlStyle} {WidthStyle}";
                string attributes = $"{BlockAlignmentAttr(BlockAlignment)}  width=\"100%\"";
                return $"style=\"{styles}\" {attributes}";
            }
        }

        public string Td2Style
        {
            get
            {
                string styles = $"{Spacing.GetHtmlStyle} {WidthStyle}";
                string attributes = $"{BlockAlignmentAttr(BlockAlignment)} {WidthAttr}";
                return $"style=\"{styles}\" {attributes}";
            }
        }

        public string TblStyle
        {
            get
            {
                string tableCollapseBorder = "border-collapse: separate;";
                string styles = $"{Border.GetHtmlStyle} {BackColorStyle(BackgroundColor)} {RoundedCornersStyle(RoundedCorners)} {tableCollapseBorder} {WidthTblStyle}";
                string attributes = $"{WidthAttr} {TableMsoAttributes} role=\"presentation\"";
                return $"style=\"{styles}\" {attributes}";
            }
        }

        public string InnerStyle
        {
            get
            {
                string styles = $"{RoundedCornersStyle(RoundedCorners)} "+ " width:100% !important;max-width:100%;";
                string attributes = $"{ImageUrlAttr} {AltTextAttr} {WidthAttr}";
                return $"style=\"{styles}\" {attributes}";
            }
        }

        #endregion
    }
}
