

using System.Text;

namespace EmailBuilder.Models.Configurations.SubConfiguration
{
    public class DefaultTagStyles
    {

        public TextTagAppearance Paragraph { get; set; } = new TextTagAppearance() { TagName = "p" };
        public TextTagAppearance Heading1 { get; set; } = new TextTagAppearance() { TagName = "h1" };
        public TextTagAppearance Heading2 { get; set; } = new TextTagAppearance() { TagName = "h2" };
        public TextTagAppearance Heading3 { get; set; } = new TextTagAppearance() { TagName = "h3" };
        public TextTagAppearance Heading4 { get; set; } = new TextTagAppearance() { TagName = "h4" };

        public LinkAppearance Links { get; set; } = new LinkAppearance();

        public ButtonsAppearance Buttons { get; set; } = new ButtonsAppearance();

        public DefaultTagStyles()
        {
           
        }

        public string GenerateCssStyles()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Paragraph.GenerateCssStyles());
            sb.AppendLine(Heading1.GenerateCssStyles());
            sb.AppendLine(Heading2.GenerateCssStyles());
            sb.AppendLine(Heading3.GenerateCssStyles());
            sb.AppendLine(Heading4.GenerateCssStyles());
            sb.AppendLine(Links.GenerateCssStyles());
            sb.AppendLine(Buttons.GenerateCssStyles());
            return sb.ToString();

        }
    }
}
