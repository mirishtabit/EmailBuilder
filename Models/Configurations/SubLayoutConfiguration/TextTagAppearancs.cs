using EmailBuilder.Common;
using EmailBuilder.Helpers;
using EmailBuilder.Models.Configurations.SubLayoutConfiguration;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;

namespace EmailBuilder.Models.Configurations.SubConfiguration
{
    public class TextTagAppearance: DefaultBase
    {
        public override string TagName { get; set; } = "p";
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

       
        protected override void UpdateDictionaryWithDefaults(ref Dictionary<string, string> styleDict)
        {
            HtmlHelper.AddToDictionary(styleDict, "color", Color);
            HtmlHelper.AddToDictionary(styleDict, "font-family", FontFamily);
            HtmlHelper.AddToDictionary(styleDict, "font-size", FontSize.ToString() + "px");
        }
    }
}

