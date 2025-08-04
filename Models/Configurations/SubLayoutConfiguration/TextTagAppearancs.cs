using EmailBuilder.Common;

namespace EmailBuilder.Models.Configurations.SubConfiguration
{
    public class TextTagAppearance
    {
        public string TagName { get; set; } = "p";
        public int FontSize { get; set; }
        public string FontFamily { get; set; } = "Arial, Helvetica, sans-serif";
        public string Color { get; set; }= "#000000";

          public TextTagAppearance()
          {
              
          }

        public string GenerateCssStyles()
        {
            return $@"{TagName} {{
                    font-size: {FontSize}px;
                    font-family: {FontFamily};
                    color: {Color};
                    }}";
        }
    }
}

