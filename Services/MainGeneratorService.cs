using EmailBuilder.Extensions;
using EmailBuilder.Models.Blocks;
using EmailBuilder.Models.Configurations.SubConfiguration;
using EmailBuilder.Services.Interfaces;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EmailBuilder.Services
{
    public class MainGeneratorService : IMainGeneratorService
    {

        /// <summary>
        /// Renders the HTML representation of the specified layout, including its structure and inline styles.
        /// </summary>
        /// <remarks>This method generates an HTML document based on the provided layout, including its
        /// structure and inline styles. The layout's configuration and resources are injected into the document to
        /// ensure proper rendering.</remarks>
        /// <param name="layout">The layout to render as HTML. Must not be null.</param>
        /// <returns>A string containing the complete HTML document for the specified layout.</returns>
        public string RenderLayoutHtml(EbLayout layout)
        {
            HtmlDocument doc = RenderHtmlSkeleton();

            /// Add generated elements into the body
            var bodyHtml = doc.DocumentNode.SelectSingleNode("//body");
            if (bodyHtml != null)
            {
                bodyHtml.InnerHtml = layout.RenderLayoutHtml();
                layout.InjectInlineStyle(ref doc);
            }


            return doc.DocumentNode.OuterHtml;
        }


        /// <summary>
        /// Loads and parses an HTML skeleton file into HtmlDocument object.
        /// </summary>
        /// <remarks>The method retrieves the HTML skeleton from a predefined file path and parses it into
        /// an HtmlDocument instance. The file must exist at the specified location, and its contents
        /// must be valid HTML.</remarks>
        /// <returns>An <see cref="HtmlDocument"/> object representing the parsed HTML skeleton.</returns>
        public static HtmlDocument RenderHtmlSkeleton()
        {
            var path = System.Web.Hosting.HostingEnvironment.MapPath($"~/Static/EmailWrapperNew.html");

            if (!File.Exists(path))
                throw new FileNotFoundException("HTML skeleton file not found.", path);

            string htmlStr = File.ReadAllText(path);

            if (string.IsNullOrWhiteSpace(htmlStr))
                throw new InvalidDataException($"HTML skeleton file at '{path}' is empty.");

            var doc = new HtmlDocument();
            doc.LoadHtml(htmlStr);

            return doc;
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
