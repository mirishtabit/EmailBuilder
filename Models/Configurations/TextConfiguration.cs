using EmailBuilder.Common;
using EmailBuilder.Converters;
using EmailBuilder.Models.HtmlProperties;
using EmailBuilder.Models.Properties;
using Newtonsoft.Json;


namespace EmailBuilder.Models.Configurations
{
    /// <summary>
    /// Represents the configuration for a text element in an email template.
    /// </summary>
    public class TextConfiguration : ConfigurationBase
    {
        #region element properties

        [JsonProperty(Required = Required.Always)]
        public string TextContent { get; set; } = string.Empty;

        [JsonProperty(Required = Required.Always)]
        public Direction Direction { get; set; } = Direction.Parent;

        [JsonProperty(Required = Required.Always)]
        public Position TextAlign { get; set; } = Position.Center;

        [JsonProperty(Required = Required.Always)]
        public EbBorder Border { get; set; } = new EbBorder();

        [JsonProperty(Required = Required.Always)]
        public int RoundedCorners { get; set; } = 0;

        [JsonProperty(Required = Required.Always)]
        public EbBackgroundImage BackgroundImage { get; set; } = new EbBackgroundImage();

        [JsonProperty(Required = Required.Always)]
        public Position BlockAlignment { get; set; } = Position.Center;

        [JsonProperty(Required = Required.Always)]
        public SpacingBase Spacing { get; set; } = new SpacingBase();

        [JsonProperty("width", Required = Required.Always)]
        [JsonConverter(typeof(WidthConverter), SizeUnit.Both)]
        public EbWidth Width { get; set; } = new EbWidth(SizeUnit.Both);

        #endregion

        #region element style helpers
        internal string DirectionStyle
        {
            get
            {
                return Direction != Direction.Parent ? $"direction:{Direction.ToString().ToLower()};" : string.Empty;
            }
        }

        internal string TextAlignStyle
        {
            get
            {
                return $"text-align:{TextAlign.ToString().ToLower()};";
            }
        }

        internal string Td1Style
        {
            get
            {
                string styles = $"{Spacing.GetOuterHtmlStyle}";
                string attributes = $"{BlockAlignmentAttr(BlockAlignment)}";
                return $"style=\"{styles}\" {attributes}";
            }
        }

        internal string Td2Style
        {
            get
            {
                string styles = $"{Spacing.GetHtmlStyle} {Width.WidthStyle} {DirectionStyle} {TextAlignStyle}";
                string attributes = $"{BlockAlignmentAttr(BlockAlignment)}";
                return $"style=\"{styles}\" {attributes}";
            }
        }

        internal string Tbl1Style
        {
            get
            {
                string tableCollapseBorder = "border-collapse: separate;";

                string styles = $"{Width.WidthStyle} {Border.GetHtmlStyle} {BackgroundImage.GetHtmlStyle} {BackColorStyle(BackgroundColor)} {RoundedCornersStyle(RoundedCorners)} {tableCollapseBorder}";
                string attributes = $"{BackColorAttr(BackgroundColor)} {Width.WidthAttr} {TableMsoAttributes}";
                return $"style=\"{styles}\" {attributes}";
            }
        }
        #endregion
    }

}
