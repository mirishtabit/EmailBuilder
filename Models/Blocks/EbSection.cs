using EmailBuilder.Common;
using EmailBuilder.Models.Blocks;
using EmailBuilder.Models.Configurations;

namespace EmailBuilder.Models.HtmlObjects
{
    public class EbSection : ElementBase
    {
        public new SectionConfiguration Configuration
        {
            get { return (SectionConfiguration)base.Configuration; }
            set { base.Configuration = value; }
        }
        public EbSection()
        {
            Configuration = new SectionConfiguration();
        }


        protected override string RenderContainer(string innerHtml)
        {
            return $"<{ElementTagName} {Configuration.TableMsoAttributes} width=\"100%\">{innerHtml}</{ElementTagName}>";
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
