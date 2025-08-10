using EmailBuilder.Common;
using EmailBuilder.Models.Blocks;
using EmailBuilder.Models.Configurations;
using EmailBuilder.Models.Properties;
using Newtonsoft.Json;
using System;

namespace EmailBuilder.Models.HtmlObjects
{
    /// <summary>
    /// Represents an image element in the layout, providing configuration and HTML rendering logic.
    /// </summary>
    public class EbImage : ElementBase
    {
        [JsonProperty(Required = Required.Always)]
        public new ImageConfiguration Configuration
        {
            get { return (ImageConfiguration)base.Configuration; }
            set { base.Configuration = value; }
        }


        public EbImage()
        {
           
        }

        public EbImage(String width) 
        {
            Configuration = new ImageConfiguration
            {
                Width = new EbWidth(width, SizeUnit.Both)
            };
        }

        protected override string RenderContainer(string innerHtml)
        {
            string elemStr = $"<{ElementTagName} {IdAttr} {NameAttr} {Configuration.InnerStyle}/>";

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