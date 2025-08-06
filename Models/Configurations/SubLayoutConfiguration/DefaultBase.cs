using EmailBuilder.Helpers;
using HtmlAgilityPack;
using System.Collections.Generic;


namespace EmailBuilder.Models.Configurations.SubLayoutConfiguration
{
    public abstract class DefaultBase
    {
        public abstract string TagName { get; set; }

        public void InjectAsInlineStyle(ref HtmlDocument bodyHtml,string tagName = "")
        {
            tagName = string.IsNullOrEmpty(tagName) ? TagName : tagName;

            var tagNodes = bodyHtml.DocumentNode.SelectNodes("//" + tagName + "");
            if (tagNodes == null) return;

            foreach (var node in tagNodes)
            {
                InsertDefaultsIntoStyle(node);
            }
        }

        private void InsertDefaultsIntoStyle(HtmlNode node)
        {
            Dictionary<string, string> styleDict = new Dictionary<string, string>();
            string styleValue = node.GetAttributeValue("style", null);
            if (styleValue != null)
            {
                HtmlHelper.CreateTagStyleDictionary(styleValue, ref styleDict);
            }
            UpdateDictionaryWithDefaults(ref styleDict);
            InjectUpdatedStyle(node, styleDict);
        }

        private void InjectUpdatedStyle(HtmlNode node, Dictionary<string, string> styleDict)
        {
            string styleString = HtmlHelper.RenderStyleString(styleDict);
            if (!string.IsNullOrEmpty(styleString))
            {
                node.SetAttributeValue("style", styleString);
            }
        }

        protected abstract void UpdateDictionaryWithDefaults(ref Dictionary<string, string> styleDict);


    }
}