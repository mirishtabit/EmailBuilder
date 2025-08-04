using EmailBuilder.Models.Blocks;
using EmailBuilder.Models.HtmlObjects;
using System;
using System.Linq;
using System.Text;

namespace EmailBuilder.Extensions
{
    public static class HtmlRenderer
    {
        public static string RenderLayoutHtml(this EbLayout layout)
        {
            if (layout == null)
                throw new ArgumentNullException(nameof(layout));

            if (layout.Sections == null)
                throw new ArgumentException("Layout.Sections cannot be null.", nameof(layout));

            StringBuilder innerPopulateHtml = new StringBuilder();

            foreach (EbSection section in layout.Sections)
            {
                innerPopulateHtml.Append(GenerateHtmlFromElement(section));
            }

            return layout.RenderElementHtml(innerPopulateHtml.ToString());
        }

        private static string GenerateHtmlFromElement(EbSection mainContainer)
        {
            if (mainContainer == null)
            {
                throw new ArgumentNullException(nameof(mainContainer), "Layout or MainContainer cannot be null.");
            }
            return PopulateHtml(mainContainer);
        }

        private static string PopulateHtml(ElementBase currElement)
        {
            var innerHtmlBuilder = new StringBuilder();

            if (currElement.Objects?.Any() == true)
            {
                foreach (var elem in currElement.Objects)
                {
                    innerHtmlBuilder.Append(PopulateHtml(elem));
                }
            }
            return currElement.RenderElementHtml(innerHtmlBuilder.ToString());
        }
       
    }
}
