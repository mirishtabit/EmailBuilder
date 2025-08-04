using EmailBuilder.Models.Properties;

namespace EmailBuilder.Models.Configurations
{
    public class ImageConfiguration : ConfigurationBase
    {
        public override SpacingBase Spacing { get; set; } = new SpacingBase();
        public string ImageUrl { get; set; } = string.Empty;
        public string AltText { get; set; } = string.Empty;
        public EbLink Link { get; set; }

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
                string attributes = $"{BlockAlignmentAttr}  width=\"100%\"";
                return $"style=\"{styles}\" {attributes}";
            }
        }

        public string Td2Style
        {
            get
            {
                string styles = $"{Spacing.GetHtmlStyle} {WidthStyle}";
                string attributes = $"{BlockAlignmentAttr} {WidthAttr}";
                return $"style=\"{styles}\" {attributes}";
            }
        }

        public string TblStyle
        {
            get
            {
                string tableCollapseBorder = "border-collapse: separate;";
                string styles = $"{Border.GetHtmlStyle} {BackColorStyle(BackgroundColor)} {RoundedCornersStyle} {tableCollapseBorder} {WidthTblStyle}";
                string attributes = $"{WidthAttr} {TableMsoAttributes}";
                return $"style=\"{styles}\" {attributes}";
            }
        }

        public string InnerStyle
        {
            get
            {
                string styles = $"{RoundedCornersStyle} "+ " width:100% !important;max-width:100%;";
                string attributes = $"{ImageUrlAttr} {AltTextAttr} {WidthAttr}";
                return $"style=\"{styles}\" {attributes}";
            }
        }
    }
}
