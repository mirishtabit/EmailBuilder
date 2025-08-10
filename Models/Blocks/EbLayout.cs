using EmailBuilder.Models.Configurations;
using EmailBuilder.Models.HtmlObjects;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EmailBuilder.Models.Blocks
{
    /// <summary>
    /// Root object only for json serialization.
    /// </summary>
    [JsonObject(ItemRequired = Required.Always)]
    public class Root
    {
        public EbLayout Layout { get; set; }
    }


    /// <summary>
    /// Represents the root layout element for an email, containing configuration and a collection of sections.
    /// </summary>
    public class EbLayout : ElementBase
    {
        [JsonIgnore]
        public override string Id { get; set; }

        [JsonIgnore]
        public override string Name { get; set; }

        [JsonProperty(Required = Required.Always)]
        public new LayoutConfiguration Configuration
        {
            get { return (LayoutConfiguration)base.Configuration; }
            set { base.Configuration = value; }
        }

        [JsonProperty(Required = Required.Always)]
        public List<EbSection> Sections { get; set; } = new List<EbSection>();

        public EbLayout(){ }


        protected override string RenderContainer(string innerHtml)
        {
            return $"<{ElementTagName} {Configuration.InnerStyle}>{innerHtml}</{ElementTagName}>";
        }

        protected override string RenderOuterElementHtml(string elemStr)
        {
            return $"<table id=\"LayotTbl\" class=\"tbl1\" {Configuration.Tbl1Style}>" +
                   $"<tr><td class=\"td1\" {Configuration.Td1Style}>" +
                   $"{elemStr}" +
                   $"</td></tr>" +
                   $"</table>";
        }


        /// <summary>
        /// Applies layout default style from to the provided HTML document.
        /// </summary>
        /// <param name="bodyHtml"></param>
        public void InjectInlineStyle(ref HtmlDocument bodyHtml)
        {
           Configuration.InjectInlineStyle(ref bodyHtml);
        }

    }

    
}

