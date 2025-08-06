using EmailBuilder.Common;
using EmailBuilder.Helpers;
using EmailBuilder.Models.Configurations.SubLayoutConfiguration;
using HtmlAgilityPack;
using System.Collections.Generic;

namespace EmailBuilder.Models.Configurations.SubConfiguration
{
    public class DefaultGeneralStyles : DefaultBase
    {
        public override string TagName { get; set; } = "h1,h2,h3,h4,p";
        public double LineHeight { get; set; }
        public Direction Direction { get; set; }

       
        public void ApplyAsInnerStyle(ref HtmlDocument html)
        {
            string[] tagsArr = TagName.Split(',');
            foreach (var tag in tagsArr)
            {
               base.InjectAsInlineStyle(ref html, tag.Trim());
            }
        }

        protected override void UpdateDictionaryWithDefaults(ref Dictionary<string, string> styleDict)
        {
            HtmlHelper.AddToDictionary(styleDict, "margin", "0");
            HtmlHelper.AddToDictionary(styleDict, "padding", "0");
            HtmlHelper.AddToDictionary(styleDict, "line-height", LineHeight.ToString());
            if (Direction != Direction.Parent)
            {
                HtmlHelper.AddToDictionary(styleDict, "direction", Direction.ToString().ToLower());
            }
        }
    }
}

