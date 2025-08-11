using EmailBuilder.Common;
using EmailBuilder.Converters;
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
        public string ImageUrl { get; set; } = string.Empty;

        [JsonProperty(Required = Required.Always)]
        public string AltText { get; set; } = string.Empty;

        [JsonProperty(Required = Required.Always)]
        public EbLink Link { get; set; }

        [JsonProperty("width", Required = Required.Always)]
        [JsonConverter(typeof(WidthConverter), SizeUnit.Both)]
        public EbWidth Width { get; set; } = new EbWidth(SizeUnit.Both);
        #endregion

        #region element style helpers

        internal string ImageUrlAttr
        {
            get
            {
                return $"src=\"{ImageUrl}\"";
            }    
        }
        internal string AltTextAttr
        {
            get
            {
                return $"alt=\"{AltText}\"";
            }
        }
        internal string Td1Style
        {
            get
            {
                string styles = $"{Spacing.GetOuterHtmlStyle} {Width.WidthStyle}";
                string attributes = $"{BlockAlignmentAttr(BlockAlignment)}  width=\"100%\"";
                return $"style=\"{styles}\" {attributes}";
            }
        }

        internal string Td2Style
        {
            get
            {
                string styles = $"{Spacing.GetHtmlStyle} {Width.WidthStyle}";
                string attributes = $"{BlockAlignmentAttr(BlockAlignment)} {Width.WidthAttr}";
                return $"style=\"{styles}\" {attributes}";
            }
        }

        internal string TblStyle
        {
            get
            {
                string tableCollapseBorder = "border-collapse: separate;";
                string styles = $"{Border.GetHtmlStyle} {BackColorStyle(BackgroundColor)} {RoundedCornersStyle(RoundedCorners)} {tableCollapseBorder} {Width.WidthTblStyle}";
                string attributes = $"{Width.WidthAttr} {TableMsoAttributes}";
                return $"style=\"{styles}\" {attributes}";
            }
        }

        internal string InnerStyle
        {
            get
            {
                string styles = $"{RoundedCornersStyle(RoundedCorners)} "+ " width:100% !important;max-width:100%;";
                string attributes = $"{ImageUrlAttr} {AltTextAttr} {Width.WidthAttr}";
                return $"style=\"{styles}\" {attributes}";
            }
        }

        #endregion
    }
}
