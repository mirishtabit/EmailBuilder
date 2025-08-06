
using EmailBuilder.Models.Configurations;
using EmailBuilder.Models.HtmlObjects;
using HtmlAgilityPack;
using System.Collections.Generic;

namespace EmailBuilder.Models.Blocks
{
    public class EbLayout:ElementBase
    {
       
        public new LayoutConfiguration Configuration
        {
            get { return (LayoutConfiguration)base.Configuration; }
            set { base.Configuration = value; }
        }

        public EbLayout()
        {
            Configuration = new LayoutConfiguration();
        }

        public List<string> FontResources { get; set; } = new List<string>();

        public List<EbSection> Sections { get; set; } = new List<EbSection>();


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


        public void InjectInlineStyle(ref HtmlDocument bodyHtml)
        {
           Configuration.InjectInlineStyle(ref bodyHtml);
        }

    }

    public class Root
    {
        public EbLayout Layout { get; set; } 
    }
}

