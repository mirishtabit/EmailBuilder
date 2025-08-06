
using EmailBuilder.Helpers;
using EmailBuilder.Models.Configurations.SubLayoutConfiguration;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI.WebControls;


namespace EmailBuilder.Models.Configurations.SubConfiguration
{
    public class LinkAppearance: DefaultBase
    {
        public override string TagName { get; set; } = "a";
        public string Color { get; set; } = "#0000EE";
        public bool Italic { get; set; } = true;
        public bool Underline { get; set; } = false;
        public bool Bold { get; set; } = false;

        public LinkAppearance()
        {

        }

        public string GenerateCssStyles()
        {
            return $@"
                    a {{
                        color: {Color};
                        text-decoration: {(Underline ? "underline" : "none")};
                        font-weight: {(Bold ? "bold" : "normal")};
                        font-style: {(Italic ? "italic" : "normal")};
                    }}
                    }}";
        }


        protected override void UpdateDictionaryWithDefaults(ref Dictionary<string, string> styleDict)
        {
            HtmlHelper.AddToDictionary(styleDict, "color", Color);
            HtmlHelper.AddToDictionary(styleDict, "font-style", Italic ? "italic" : "normal");
            HtmlHelper.AddToDictionary(styleDict, "text-decoration", Underline? "underline":"none");
            HtmlHelper.AddToDictionary(styleDict, "font-weight", Bold ? "bold": "normal");
        }
    }
    
}
