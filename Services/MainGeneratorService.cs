using EmailBuilder.Common;
using EmailBuilder.Extensions;
using EmailBuilder.Models.Blocks;
using EmailBuilder.Models.Configurations;
using EmailBuilder.Models.Configurations.SubConfiguration;
using EmailBuilder.Models.HtmlObjects;
using EmailBuilder.Models.HtmlProperties;
using EmailBuilder.Models.Properties;
using EmailBuilder.Models.Properties.Spacing;
using EmailBuilder.Services.Interfaces;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.IO;


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

        /// <summary>
        /// Builds a sample EbLayout object with sections and elements, 
        /// demonstrating how to construct a layout in code for testing or example purposes.
        /// </summary>
        public void BuildElementClasses()
        {
            // building the head container
            EbLayout layout = new EbLayout();

            layout.Configuration = new LayoutConfiguration
            {
                BodyColor = "#FFFFFF",
                Width = "600px",/// need to be changed to body width
                DefaultTagStyles = new DefaultTagStyles
                {
                    Paragraph = new TextTagAppearance { FontFamily = "Arial", FontSize = 16, Color = "#333333" },
                    Heading1 = new TextTagAppearance { FontFamily = "Arial", FontSize = 32, Color = "#111111" }
                },
                DefaultGeneralStyles = new DefaultGeneralStyles
                {
                    LineHeight = 1.5,
                    Direction = Direction.Ltr
                },
                Spacing = new EbLayoutSpacing
                {
                    PaddingEnabled = true,
                    PaddingTop = 10,
                    PaddingBottom = 10,
                    PaddingLeft = 10,
                    PaddingRight = 10
                },
                BackgroundColor = "lightgray"
            };
            List<EbSection> sections = new List<EbSection>();
            EbSection sec = new EbSection();
            sec.Objects = new List<ElementBase>();
            sec.Id = "Main Section";
            sec.Name = "Header Section";
            SectionConfiguration confg1 = new SectionConfiguration();
            confg1.Spacing = new SpacingBase()
            {
                MarginEnabled = true,
                MarginTop = 20,
                MarginBottom = 20,
                PaddingEnabled = true,
                PaddingTop = 10,
                PaddingBottom = 10,
                PaddingLeft = 10,
                PaddingRight = 10
            };
            confg1.BackgroundColor = "#F5F5F5";

            sec.Configuration = confg1;
            sec.Objects = new List<ElementBase>
                {
                new EbText
                {
                    Id = "headerText",
                    Name = "Header",
                    Type = ClientElementType.Text,
                    Configuration = new TextConfiguration
                    {
                        TextContent = "<h1>Cafe Largo Test</h1>",
                        Width = "100%",
                        BackgroundColor = "#F5F5F5",
                        Spacing = new SpacingBase
                        {
                            MarginEnabled = true,
                            MarginTop = 0,
                            MarginBottom = 10
                        }
                    }
                }

            };
            sections.Add(sec);

            sections.Add(new EbSection
            {
                Id = "section2",
                Name = "Image Section",
                Type = ClientElementType.Section,
                Configuration = new SectionConfiguration
                {
                    BackgroundColor = "#FFFFFF",
                    Border = new EbBorder { BorderEnabled = false, Sides = new List<EbBorderSide>() },
                    Spacing = new SpacingBase
                    {
                        MarginEnabled = true,
                        MarginTop = 10,
                        MarginBottom = 10,
                        PaddingEnabled = true,
                        PaddingTop = 10,
                        PaddingBottom = 10,
                        PaddingLeft = 10,
                        PaddingRight = 10
                    }
                },
                Objects = new List<ElementBase>
            {
                new EbImage
                {
                    Id = "mainImage",
                    Name = "Main Image",
                    Type = ClientElementType.Image,
                    Configuration = new ImageConfiguration
                    {
                        ImageUrl = "https://media.istockphoto.com/id/1301017778/photo/three-glasses-of-white-rose-and-red-wine-on-a-wooden-barrel.jpg",
                        AltText = "Wine Glasses",
                        Width = "400px",
                        RoundedCorners = 8,
                        BackgroundColor = "#FFFFFF",
                        Spacing = new SpacingBase
                        {
                            MarginEnabled = true,
                            MarginTop = 10,
                            MarginBottom = 10
                        },
                        Link = new EbLink
                        {
                            LinkEnabled = true,
                            Url = "https://cafelargo.com/",
                            LinkTitle = "Cafe Largo"
                        },
                        Border = new EbBorder { BorderEnabled = false, Sides = new List<EbBorderSide>() }
                    }
                }
            }
            });
            sections.Add(new EbSection
            {
                Id = "section3",
                Name = "Text Section",
                Configuration = new SectionConfiguration
                {
                    BackgroundColor = "#FFFFFF",
                    Spacing = new SpacingBase
                    {
                        MarginEnabled = true,
                        MarginTop = 10,
                        MarginBottom = 10,
                        PaddingEnabled = true,
                        PaddingTop = 10,
                        PaddingBottom = 10,
                        PaddingLeft = 10,
                        PaddingRight = 10
                    }
                },
                Objects = new List<ElementBase>
            {
                new EbText
                {
                    Id = "mainText",
                    Name = "Main Text",
                    Type = ClientElementType.Text,
                    Configuration = new TextConfiguration
                    {
                        TextContent = "<p>הימים האחרונים רגישים, מורכבים ומלאי חוסר וודאות.<br>אנחנו פועלים במתכונת מצומצמת אך בוחרים לפתוח את הלב וגם את היקב, בצורה שקטה, בטוחה ומחבקת עבור כל מי שצריך לקחת לגימה של רוגע ושלווה.</p>",
                        Width = "100%",
                        TextAlign = Position.Left,
                        Direction = Direction.Rtl,
                        BackgroundColor = "#FFFFFF",
                        Spacing = new SpacingBase
                        {
                            MarginEnabled = true,
                            MarginTop = 0,
                            MarginBottom = 0
                        }
                    }
                }
            }
            });
            
            layout.Sections = sections;
        }
    }
}
 