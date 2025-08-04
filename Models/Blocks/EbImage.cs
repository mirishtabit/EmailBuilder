using EmailBuilder.Models.Blocks;
using EmailBuilder.Models.Configurations;
using System;

namespace EmailBuilder.Models.HtmlObjects
{
    public class EbImage : ElementBase
    {

        public new ImageConfiguration Configuration
        {
            get { return (ImageConfiguration)base.Configuration; }
            set { base.Configuration = value; }
        }

        public EbImage()
        {
            base.Configuration = new ImageConfiguration
            {
                Width = "100%"
            };
        }

        public EbImage(String width) 
        {
            Configuration = new ImageConfiguration
            {
                Width = width
            };
        }

        protected override string RenderContainer(string innerHtml)
        {
            string elemStr = $"<{ElementTagName} {Configuration.InnerStyle}/>";

            if (Configuration.Link != null)
            {
                return Configuration.Link.WrapWithLink(elemStr);
            }
            return elemStr;
        }

        protected override string RenderOuterElementHtml(string elemStr)
        {
            return $"<tr>" +
                   $"<td class=\"td1\" {Configuration.Td1Style}>" +
                   $"<table class=\"tbl1\" {Configuration.TblStyle}>" +
                   $"<tr>" +
                   $"<td class=\"td2\" {Configuration.Td2Style}>{elemStr}</td>" +
                   $"</tr></table></td></tr>";
        }
      
    }
}