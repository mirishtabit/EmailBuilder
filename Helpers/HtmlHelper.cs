using EmailBuilder.Common;
using EmailBuilder.Models.Configurations;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System.Text;

namespace EmailBuilder.Helpers
{
    public static class HtmlHelper
    {

        //public static string RenderPropertyString(Dictionary<string, List<string>> propertiesDic)
        //{
        //    var sb = new StringBuilder();

        //    if (propertiesDic.ContainsKey("Attributes") && propertiesDic["Attributes"] != null && propertiesDic["Attributes"].Count > 0)
        //    {
        //        foreach (string attr in propertiesDic["Attributes"])
        //        {
        //            sb.Append($"{attr} ");
        //        }
        //    }

        //    if (propertiesDic.ContainsKey("Styles") && propertiesDic["Styles"] != null && propertiesDic["Styles"].Count > 0)
        //    {
        //        sb.Append($"style=\"");

        //        foreach (string style in propertiesDic["Styles"])
        //        {
        //            sb.Append($"{style}");
        //        }
        //        sb.Append($"\"");
        //    }
        //    return sb.ToString();
        //}

       
    }
    
}

