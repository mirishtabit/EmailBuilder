
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace EmailBuilder.Models.Configurations.SubConfiguration
{
    public class LinkAppearance
    {
        public string Color { get; set; } = "transparent";
        public bool IsItalic { get; set; }
        public bool IsUnderline { get; set; }
        public bool IsBold { get; set; }

        public LinkAppearance()
        {

        }

        public string GenerateCssStyles()
        {
            return $@"
                    a {{
                        color: {Color};
                        text-decoration: {(IsUnderline ? "underline" : "none")};
                        font-weight: {(IsBold ? "bold" : "normal")};
                        font-style: {(IsItalic ? "italic" : "normal")};
                    }}

                    @media screen and (min-width: 600px) {{
                        a {{
                            color: {Color};
                            text-decoration: {(IsUnderline ? "underline" : "none")};
                            font-weight: {(IsBold ? "bold" : "normal")};
                            font-style: {(IsItalic ? "italic" : "normal")};
                        }}
                    }}";
        }

    }
}
