using EmailBuilder.Common;
using EmailBuilder.Models.Blocks;
using EmailBuilder.Models.HtmlObjects;
using System;
using System.Linq;
using System.Text;

namespace EmailBuilder.Extensions
{
    public static class HtmlRenderer
    {
        /// <summary>
        /// Generates the HTML markup for the specified <see cref="EbLayout"/> and its sections.
        /// Must contain at least one section, and each section at least one object.
        /// </summary>
        /// <returns>A <see cref="string"/> containing the complete HTML representation of the layout and its sections.</returns>
        public static string GenerateElementsHtml(this EbLayout layout)
        {
            if (layout == null)
                throw new ArgumentNullException(nameof(layout));

            if (layout.Sections == null || layout.Sections.Count < 1)
                throw new ArgumentException("Layout.Sections cannot be null or empty, needs to be at least one section in layout.", nameof(layout));

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
                throw new ArgumentNullException(nameof(mainContainer), "Section or MainContainer cannot be null.");

            return PopulateHtml(mainContainer);
        }

        /// <summary>
        /// Generates the HTML markup for the specified element and its child elements.
        /// </summary>
        /// <param name="currElement">The element to render as HTML. If the element contains child elements, their HTML will be recursively
        /// included.</param>
        /// <returns>A string containing the HTML representation of <paramref name="currElement"/> and its descendants.</returns>
        private static string PopulateHtml(ElementBase currElement)
        {
            if (currElement == null)
                throw new ArgumentNullException(nameof(currElement), "Element cannot be null.");
            
            var innerHtmlBuilder = new StringBuilder();
            // Only check for empty Objects if the element is of type Section
            if (currElement.Type == ClientElementType.Section)
            {
                var section = currElement as EbSection;
                if (section.Objects != null && section.Objects.Count == 0)
                    throw new ArgumentException($"Section element has an empty Objects list, but at least one object is required.", nameof(currElement));

                if (section.Objects?.Any() == true)
                {
                    foreach (var elem in section.Objects)
                    {
                        innerHtmlBuilder.Append(PopulateHtml(elem));
                    }
                }
            }
            return currElement.RenderElementHtml(innerHtmlBuilder.ToString());
        }
       
    }
}
