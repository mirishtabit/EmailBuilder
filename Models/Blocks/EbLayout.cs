using EmailBuilder.Extensions;
using EmailBuilder.Models.Configurations;
using EmailBuilder.Models.HtmlObjects;
using EmailBuilder.Services;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Configuration;
using System.Web.Mvc;

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
            return $"{Configuration.TableMsoStart}"+
                   $"<{ElementTagName} {Configuration.InnerStyle}>{innerHtml}</{ElementTagName}>"+
                   $"{Configuration.TableMsoEnd}";
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
        private void InjectInlineStyle(ref HtmlDocument bodyHtml)
        {
           Configuration.InjectInlineStyle(ref bodyHtml);
        }

        /// <summary>
        /// Renders the HTML representation of the specified layout, including its structure and inline styles.
        /// </summary>
        /// <remarks>This method generates an HTML document based on the provided layout, including its
        /// structure and inline styles. The layout's configuration and resources are injected into the document to
        /// ensure proper rendering.</remarks>
        /// <param name="layout">The layout to render as HTML. Must not be null.</param>
        /// <returns>A string containing the complete HTML document for the specified layout.</returns>
        public string RenderLayoutHtml()
        {
            HtmlDocument doc = Helpers.HtmlHelper.RenderHtmlSkeleton();

            /// Add generated elements into the body
            var bodyHtml = doc.DocumentNode.SelectSingleNode("//body");
            if (bodyHtml != null)
            {
                bodyHtml.InnerHtml = this.GenerateElementsHtml();
                InjectInlineStyle(ref doc);
            }
            return doc.DocumentNode.OuterHtml;
        }


    }

    
}

