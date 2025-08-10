using EmailBuilder.Common;
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

        [JsonProperty(Required = Required.Always)]
        public override string Width  
        {
            get => base.Width;
            set => base.Width = value;
        }

        #endregion

        #region element style helpers
        public string DirectionStyle
        {
            get
            {
                return Direction != Direction.Parent ? $"direction:{Direction.ToString().ToLower()};" : string.Empty;
            }
        }

        public string TextAlignStyle
        {
            get
            {
                return $"text-align:{TextAlign.ToString().ToLower()};";
            }
        }

        public string Td1Style
        {
            get
            {
                string styles = $"{Spacing.GetOuterHtmlStyle}";
                string attributes = $"{BlockAlignmentAttr(BlockAlignment)}";
                return $"style=\"{styles}\" {attributes}";
            }
        }

        public string Td2Style
        {
            get
            {
                string styles = $"{Spacing.GetHtmlStyle} {WidthStyle} {DirectionStyle} {TextAlignStyle}";
                string attributes = $"{BlockAlignmentAttr(BlockAlignment)}";
                return $"style=\"{styles}\" {attributes}";
            }
        }

        public string Tbl1Style
        {
            get
            {
                string tableCollapseBorder = "border-collapse: separate;";

                string styles = $"{WidthStyle} {Border.GetHtmlStyle} {BackgroundImage.GetHtmlStyle} {BackColorStyle(BackgroundColor)} {RoundedCornersStyle(RoundedCorners)} {tableCollapseBorder}";
                string attributes = $"{BackColorAttr(BackgroundColor)} {WidthAttr} {TableMsoAttributes} role=\"presentation\"";
                return $"style=\"{styles}\" {attributes}";
            }
        }
        #endregion
    }

}
