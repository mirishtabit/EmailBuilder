using EmailBuilder.Common;

namespace EmailBuilder.Models.Configurations
{
    public class SectionConfiguration:ConfigurationBase
    {
        public string BodyColor { get; set; } = string.Empty;

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
                string attributes = $"{BackColorAttr(BackgroundColor)} {WidthAttr} {TableMsoAttributes}";
                return $"style=\"{styles}\" {attributes}";
            }
        }

        public string Tbl2Style
        {
            get
            {
                string styles = $"{BackColorStyle(BodyColor)} {RoundedCornersStyle} {Border.GetHtmlStyle} {WidthTblStyle}";
                string attributes = $"{BackColorAttr(BodyColor)} {WidthAttr} {TableMsoAttributes}";
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
 
    }

}