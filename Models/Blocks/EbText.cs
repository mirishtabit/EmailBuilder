
using EmailBuilder.Models.Blocks;
using EmailBuilder.Models.Configurations;
using Newtonsoft.Json;

namespace EmailBuilder.Models.HtmlObjects
{
    /// <summary>
    /// represents a text element in the layout, providing configuration and HTML rendering logic.
    /// </summary>
    public class EbText : ElementBase
    {
        [JsonProperty(Required = Required.Always)]
        public new TextConfiguration Configuration
        {
            get { return (TextConfiguration)base.Configuration; }
            set { base.Configuration = value; }
        }

        public EbText()
        { }

        public override string RenderElementHtml(string innerHtml)
        {
            return base.RenderElementHtml(Configuration.TextContent);
        }

        protected override string RenderContainer(string innerHtml)
        {
            return $"<{ElementTagName} {IdAttr} {NameAttr}>{innerHtml}</{ElementTagName}>";
        }

        protected override string RenderOuterElementHtml(string elemStr)
        {
            return $"<tr>" +
                   $"<td  class=\"td1\" {Configuration.Td1Style}>" +
                   $"<table class=\"tbl1\" {Configuration.Tbl1Style}>" +
                   $"<tr>" +
                   $"<td class=\"td2\" {Configuration.Td2Style}>{elemStr}</td>" +
                   $"</tr></table></td></tr>";
        }
    }
}