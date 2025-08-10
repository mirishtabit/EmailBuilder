using EmailBuilder.Models.Blocks;
using EmailBuilder.Models.Configurations;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EmailBuilder.Models.HtmlObjects
{
    /// <summary>
    /// Represents a section element in the layout, containing configuration and a collection of child elements.
    /// </summary>
    public class EbSection : ElementBase
    {
        [JsonProperty(Required = Required.Always)]
        public new SectionConfiguration Configuration
        {
            get { return (SectionConfiguration)base.Configuration; }
            set { base.Configuration = value; }
        }

        [JsonProperty(Required = Required.Always)]
        public List<ElementBase> Objects { get; set; }

        public EbSection(){ }


        protected override string RenderContainer(string innerHtml)
        {
            return $"<{ElementTagName} {IdAttr} {NameAttr} {Configuration.TableMsoAttributes} width=\"100%\">{innerHtml}</{ElementTagName}>";
        }

        protected override string RenderOuterElementHtml(string elemStr)
        {
            return $"<tr><td width=\"100%\">" +
                     $"<table class=\"section tbl1\" {Configuration.Tbl1Style}>" +
                        $"<tr><td class=\"td1\" {Configuration.Td1Style}>" +
                           $"<table class=\"tbl2\" {Configuration.Tbl2Style}>" +
                              $"<tr><td class=\"td3\" {Configuration.Td3Style}>" +
                                 $"{elemStr}"+
                              $"</td></tr>" +
                           $"</table>"+
                        $"</td></tr>" +
                  $"</table></td></tr>";
        }

    }
}
