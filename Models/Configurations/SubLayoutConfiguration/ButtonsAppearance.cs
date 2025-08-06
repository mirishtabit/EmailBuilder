using EmailBuilder.Common;
using EmailBuilder.Helpers;
using EmailBuilder.Models.Configurations.SubLayoutConfiguration;
using EmailBuilder.Models.HtmlProperties;
using System.Collections.Generic;


namespace EmailBuilder.Models.Configurations.SubConfiguration
{
    public class ButtonsAppearance: DefaultBase
    {
        public override string TagName { get; set; } = "button";
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
                    _width = "100%";
                return _width;
            }
            set
            {
                // ValidateSizeCoordinates returns true if “value” is valid
                // and spits out the numeric part into out _widthNumericValue
                if (PropertyValidator.ValidateSizeCordinates(value, out var numeric))
                {
                    _width = value;
                    _widthNumericValue = numeric;
                }
            }
        }
        public string WidthNumericValue
        {
            get
            {
                return _widthNumericValue;
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

        protected override void UpdateDictionaryWithDefaults(ref Dictionary<string, string> styleDict)
        {
            HtmlHelper.AddToDictionary(styleDict, "font-family", FontFamily);
            HtmlHelper.AddToDictionary(styleDict, "font-size", FontSize.ToString() + "px");
            HtmlHelper.AddToDictionary(styleDict, "border-radius", ButtonRadius.ToString() + "px");
            HtmlHelper.AddToDictionary(styleDict, "background-color", BackgroundColor);
            HtmlHelper.AddToDictionary(styleDict, "width", Width);
            HtmlHelper.AddToDictionary(styleDict, "font-weight", Bold ? "bold" : "normal");
            HtmlHelper.AddToDictionary(styleDict, "font-style", Italic ? "italic" : "normal");
            HtmlHelper.AddToDictionary(styleDict, "text-decoration", Underline ? "underline" : "none");

            if (Borders != null && Borders.BorderWidth > 0)
            {
                HtmlHelper.AddToDictionary(styleDict, "border-color", Borders.BorderColor);
                HtmlHelper.AddToDictionary(styleDict, "border-style", Borders.BorderStyle.ToString());
                HtmlHelper.AddToDictionary(styleDict, "border-width", Borders.BorderWidth.ToString() + "px");
            }
        }
    }
}
