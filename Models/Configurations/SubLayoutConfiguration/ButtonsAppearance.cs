using EmailBuilder.Common;
using EmailBuilder.Models.HtmlProperties;

namespace EmailBuilder.Models.Configurations.SubConfiguration
{
    public class ButtonsAppearance
    {
        public string FontFamily { get; set; } = "Arial, Helvetica, sans-serif";
        public int FontSize { get; set; }
        public bool Bold { get; set; }
        public bool Italic { get; set; }
        public bool Underline { get; set; }
        public int ButtonRadius { get; set; }
        public string BackgroundColor { get; set; } = "transparent";
        public AfBorderSide Borders { get; set; } = new AfBorderSide();

        private string _widthNumericValue = string.Empty;
        private string _width = string.Empty;
        public string Width
        {
            get
            {
                if (string.IsNullOrEmpty(_width))
                {
                    // Default to 100% width if not set
                    _width = "100%";
                }
                return _width;
            }
            set
            {
                if (PropertyValidator.ValidateSizeCordinates(value, out _widthNumericValue))
                    _width = value;
            }
        }

        public ButtonsAppearance()
        {

        }

        public string GenerateCssStyles()
        {
            return $@"
                    .button {{
                        font-family: {FontFamily};
                        font-size: {FontSize}px;
                        font-weight: {(Bold ? "bold" : "normal")};
                        font-style: {(Italic ? "italic" : "normal")};
                        text-decoration: {(Underline ? "underline" : "none")};
                        border-radius: {ButtonRadius}px;
                        background-color: {BackgroundColor};
                        width: {Width};
                    }}

                    @media screen and (max-width: 600px) {{
                        .button {{
                            font-size: {FontSize - 2}px;
                            width: 100%;
                        }}
                    }}";
        }
    }
}
