using EmailBuilder.Extensions;
using EmailBuilder.Models.Blocks;
using EmailBuilder.Services.Interfaces;
using HtmlAgilityPack;
using System.IO;

namespace EmailBuilder.Services
{
    public class MainGeneratorService : IMainGeneratorService
    {
        public string RenderLayoutHtml(EbLayout layout)
        {
            /// Skeleton
            HtmlDocument doc = RenderHtmlSkeleton();

            /// Add generated elements into the skeleton
            var tdNode = doc.DocumentNode.SelectSingleNode("//body");
            if (tdNode != null)
            {
                tdNode.InnerHtml = layout.RenderLayoutHtml(); 
            }

            /// Add generated Style into the HEAD           
            string generalStyle = layout.Configuration.GenerateCssStyles();
            AddCssToStyleTag(doc, generalStyle);

            /// Add external link resources 
            AddFontResourcesToHead(layout, doc);

            return doc.DocumentNode.OuterHtml;
        }

        public static HtmlDocument RenderHtmlSkeleton()
        {
            /// Load html skeleton from file
            var path = System.Web.Hosting.HostingEnvironment.MapPath($"~/Static/EmailWrapperNew.html");
            string htmlStr = File.ReadAllText(path);

            if (htmlStr == null)
                throw new FileNotFoundException("HTML skeleton file not found.", path);

            var doc = new HtmlDocument();
            doc.LoadHtml(htmlStr);

            return doc;
        }

        private static void AddFontResourcesToHead(EbLayout layout, HtmlDocument doc)
        {
            //string linkResources = layout.GetFontResources();
            var headNode = doc.DocumentNode.SelectSingleNode("//head");
            if (headNode != null && layout.FontResources!=null)
            {
                foreach (var link in layout.FontResources)
                {
                    var linkNode = doc.CreateElement("link");
                    linkNode.SetAttributeValue("href", link);
                    linkNode.SetAttributeValue("rel", "stylesheet");
                    headNode.PrependChild(linkNode);
                }
                
            }
        }

        private void AddCssToStyleTag(HtmlDocument doc, string generalStyle)
        {
            var styleNode = doc.DocumentNode.SelectSingleNode("//head/style");

            if (styleNode != null)
            {
                styleNode.InnerHtml += "\n" + generalStyle;
            }
            else
            {
                var head = doc.DocumentNode.SelectSingleNode("//head") ?? doc.CreateElement("head");
                styleNode = doc.CreateElement("style");
                styleNode.SetAttributeValue("type", "text/css");
                styleNode.InnerHtml = generalStyle;
                head.AppendChild(styleNode);
            }
        }

       


        public void BuildElementClasses()
        {
            //// building the head container
            //AfSection mainContainer = new AfSection();
            //mainContainer.Type = ClientElementType.SECTION;
            //mainContainer.Configuration = new ElementConfiguration()
            //{
            //    Width = "300px",
            //    BackgroundColor = "#FFFFF",
            //    BlockAlignment = Align.CENTER,
            //    Spacing = new AfSpacing() { MarginBottom = 5, MarginTop = 5 }
            //};

            ////Create an inner element - image
            //AfImage afimg = new AfImage("150px");
            //afimg.Type = ClientElementType.IMAGE;
            //afimg.Id = "afImage";

            //afimg.Configuration = new ImageConfiguration()
            //{
            //    ImageUrl = "~/wine.png",
            //    AltText = "yekev"
            //};

            //mainContainer.Objects = new List<Element>();
            //mainContainer.Objects.Add(afimg);

            //// create socond element - a text
            //AfText afText = new AfText();
            //afText.Type = ClientElementType.TEXT;
            //afText.Configuration = new TextConfiguration()
            //{
            //    Text = $"הימים האחרונים רגישים, מורכבים ומלאי חוסר וודאות.\r\n\r\nאנחנו פועלים במתכונת מצומצמת אך בוחרים לפתוח את הלב\r\n\r\nוגם את היקב, בצורה שקטה, בטוחה ומחבקת\r\n\r\nעבור כל מי שצריך לקחת לגימה של רוגע ושלווה."
            //};

        }

    }

}
