using EmailBuilder.Common;
using EmailBuilder.Models.Properties;


namespace EmailBuilder.Models.Configurations
{
    public class TextConfiguration : ConfigurationBase
    {
        public override SpacingBase Spacing { get; set; } = new SpacingBase();
        public string TextContent { get; set; } = string.Empty;
        //public AfFont? Font { get; set; }
        public Direction Direction { get; set; } = Direction.Parent;
        public double LineHeight { get; set; } = 1;
        public Position TextAlign { get; set; } = Position.Center;
        

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
                string attributes = $"{BlockAlignmentAttr}";
                return $"style=\"{styles}\" {attributes}";
            }
        }

        public string Td2Style
        {
            get
            {
                string styles = $"{Spacing.GetHtmlStyle} {WidthStyle} {DirectionStyle} {TextAlignStyle}";
                string attributes = $"{BlockAlignmentAttr}";
                return $"style=\"{styles}\" {attributes}";
            }
        }

        public string Tbl1Style
        {
            get
            {
                string tableCollapseBorder = "border-collapse: separate;";

                string styles = $"{WidthStyle} {Border.GetHtmlStyle} {BackgroundImage.GetHtmlStyle} {BackColorStyle(BackgroundColor)} {RoundedCornersStyle} {tableCollapseBorder}";
                string attributes = $"{BackColorAttr(BackgroundColor)} {WidthAttr} {TableMsoAttributes}";
                return $"style=\"{styles}\" {attributes}";
            }
        }

    }

}
