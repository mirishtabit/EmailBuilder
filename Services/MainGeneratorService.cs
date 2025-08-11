using EmailBuilder.Common;
using EmailBuilder.Models.Blocks;
using EmailBuilder.Models.Configurations;
using EmailBuilder.Models.Configurations.SubConfiguration;
using EmailBuilder.Models.HtmlObjects;
using EmailBuilder.Models.HtmlProperties;
using EmailBuilder.Models.Properties;
using EmailBuilder.Models.Properties.Spacing;
using System.Collections.Generic;



namespace EmailBuilder.Services
{
    public class MainGeneratorService
    {
        /// <summary>
        /// Builds a sample EbLayout object with sections and elements, 
        /// demonstrating how to construct a layout in code for testing or example purposes.
        /// </summary>
        public EbLayout BuildElementClasses()
        {
            // building the head container
            EbLayout layout = new EbLayout();

            layout.Configuration = new LayoutConfiguration
            {
                BodyColor = "#FFFFFF",
                Width = new EbWidth("600px",SizeUnit.Both),/// need to be changed to body width
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
                        Width = new EbWidth("100%", SizeUnit.Both),
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
                        Width = new EbWidth("400px", SizeUnit.Both),
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
                        Width = new EbWidth("100%", SizeUnit.Both),
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

            return layout;
        }


        /// <summary>
        /// Builds an EbLayout object using the configuration and sections from the Cafe_Largo.json file.
        /// This demonstrates how to construct a layout from a JSON template.
        /// </summary>
        public EbLayout BuildElementClasses_CafeLargo()
        {
            // Layout Configuration
            var layout = new EbLayout
            {
                Configuration = new LayoutConfiguration
                {
                    DefaultTagStyles = new DefaultTagStyles
                    {
                        Paragraph = new TextTagAppearance { FontFamily = "Helvetica Neue, Helvetica, Arial, Verdana, sans-serif", FontSize = 16, Color = "#000000" },
                        Heading1 = new TextTagAppearance { FontFamily = "Helvetica Neue, Helvetica, Arial, Verdana, sans-serif", FontSize = 31, Color = "#000000" },
                        Heading2 = new TextTagAppearance { FontFamily = "Helvetica Neue, Helvetica, Arial, Verdana, sans-serif", FontSize = 28, Color = "#000000" },
                        Heading3 = new TextTagAppearance { FontFamily = "Helvetica Neue, Helvetica, Arial, Verdana, sans-serif", FontSize = 21, Color = "#000000" },
                        Heading4 = new TextTagAppearance { FontFamily = "Helvetica Neue, Helvetica, Arial, Verdana, sans-serif", FontSize = 18, Color = "#444444" },
                        Links = new LinkAppearance { Bold = false, Italic = false, Underline = false, Color = "#1a73e8" },
                        Buttons = new ButtonsAppearance
                        {
                            FontFamily = "Helvetica Neue, Helvetica, Arial, Verdana, sans-serif",
                            FontSize = 16,
                            Bold = true,
                            Italic = false,
                            Underline = false,
                            Width = "50%",
                            ButtonRadius = 4,
                            BackgroundColor = "#1a73e8",
                        }
                    },
                    DefaultGeneralStyles = new DefaultGeneralStyles
                    {
                        LineHeight = 1.7,
                        Direction = Direction.Ltr
                    },
                    Spacing = new EbLayoutSpacing(),
                    Width = new EbWidth("692px", SizeUnit.Both),
                    BackgroundColor = "#FAFAFA",
                }
            };

            // Sections
            var sections = new List<EbSection>();

            // Section 1
            sections.Add(new EbSection
            {
                Id = "section1",
                Name = "sec1",
                Configuration = new SectionConfiguration
                {
                    BodyColor = "#FFFFFF",
                    Spacing = new SpacingBase
                    {
                        PaddingEnabled = true,
                        PaddingBottom = 24,
                        MarginEnabled = true,
                        MarginLeft = 16,
                        MarginRight = 16,
                    }
                },
                Objects = new List<ElementBase>
                 {
                     new EbImage
                     {
                         Id = "afImage2",
                         Name = "Main_Product_Image",
                         Type = ClientElementType.Image,
                         Configuration = new ImageConfiguration
                         {
                             ImageUrl = "https://mcusercontent.com/edd3202c818e1f341f7b52405/images/1906cf45-054f-6ccd-073b-025495b9d9d1.gif",
                             AltText = "Cafe Largo",
                             Width = new EbWidth("100%", SizeUnit.Both),
                             Spacing = new SpacingBase
                             {
                                 PaddingEnabled = true,
                                 PaddingTop = 12,
                                 PaddingBottom = 12,
                             }
                         }
                     }
                 }
            });

            // Section 2
            sections.Add(new EbSection
            {
                Id = "section2",
                Name = "sec2",
                Configuration = new SectionConfiguration
                {
                    BodyColor = "#FFFFFF",
                    Spacing = new SpacingBase
                    {
                        PaddingBottom = 24,
                        PaddingLeft = 23,
                        PaddingRight = 23,
                        MarginEnabled = true,
                        MarginLeft = 16,
                        MarginRight = 16,
                    }
                },
                Objects = new List<ElementBase>
                 {
                     new EbText
                 {
                     Id = "",
                     Name = "",
                     Type = ClientElementType.Text,
                     Configuration = new TextConfiguration
                     {
                         TextContent = "<p><strong><span>A Key Largo Destination — 3 Restaurants, 3 Bars, and 3 Incredible Happy Hours!</span></strong></p>",
                         Width = new EbWidth("100%", SizeUnit.Both),
                         Direction = Direction.Ltr,
                         Spacing = new SpacingBase
                         {
                             PaddingEnabled = true,
                             PaddingTop = 12,
                         }
                     }
                 },
                     new EbText
                 {
                     Id = "",
                     Name = "",
                     Type = ClientElementType.Text,
                     Configuration = new TextConfiguration
                     {
                         TextContent = "<p style=\"text-decoration: none;\"><strong><span style=\"color:#000000;\">Locally owned and operated for over 30 years.</span></strong></p>",
                         Width = new EbWidth("100%", SizeUnit.Both),
                         Direction = Direction.Ltr,
                         Spacing = new SpacingBase
                         {
                             PaddingEnabled = true,
                             PaddingBottom = 24
                         }
                     }
                 },
                     new EbText
                 {
                     Id = "",
                     Name = "",
                     Type = ClientElementType.Text,
                     Configuration = new TextConfiguration
                     {
                         TextContent = "<p style=\"text-decoration: none;\"><span style=\"color:#000000;\">DiGiorgio’s Café Largo and Bayside Grille are serving up happy hour specials, Sunday Brunch, refreshing cocktails, and great food all summer long!</span></p>",
                         Width = new EbWidth("100%", SizeUnit.Both),
                         Direction = Direction.Ltr,
                         Spacing = new SpacingBase
                         {
                             MarginEnabled = true,
                             MarginBottom = 20,
                         }
                     }
                 },
                     new EbText
                 {
                     Id = "blackBtn",
                     Name = "",
                     Type = ClientElementType.Text,
                     Configuration = new TextConfiguration
                     {
                         TextContent = "<a href=\"https://keylargorestaurants.com/\" style=\"color:#ffffff;\" rel=\"noreferrer\">View Website Here</a>",
                         Width = new EbWidth("195px", SizeUnit.Both),
                         Direction = Direction.Ltr,
                         BackgroundColor = "rgb(0, 0, 0)",
                         Spacing = new SpacingBase
                         {
                             PaddingEnabled = true,
                             PaddingTop = 18,
                             PaddingBottom = 18,
                             PaddingLeft = 28,
                             PaddingRight = 28,
                             MarginEnabled = true,
                             MarginBottom = 12,
                             MarginTop = 12
                         }
                     }
                 },
                     new EbText
                 {
                     Id = "separetor",
                     Name = "",
                     Type = ClientElementType.Text,
                     Configuration = new TextConfiguration
                     {
                         TextContent = "<br>",
                         Width = new EbWidth("100%", SizeUnit.Both),
                         TextAlign = Position.Center,
                         Spacing = new SpacingBase
                         {
                             MarginEnabled = true,
                             MarginBottom = 20,
                             MarginTop = 10
                         },
                         Border = new EbBorder
                         {
                             BorderEnabled = true,
                             Sides = new List<EbBorderSide>
                             {
                                 new EbBorderSide
                                 {
                                     BorderSide = BorderSide.Bottom,
                                     BorderWidth = 2,
                                     BorderColor = "rgb(0, 0, 0)",
                                     BorderStyle = BorderStyle.Solid
                                 }
                             }
                         },
                         Direction = Direction.Ltr
                     }
                 }
                 }
            });

            // Section 3
            sections.Add(new EbSection
            {
                Id = "section3",
                Name = "sec3",
                Type = ClientElementType.Section,
                Configuration = new SectionConfiguration
                {
                    BodyColor = "#FFFFFF",
                    Spacing = new SpacingBase
                    {
                        PaddingEnabled = true,
                        PaddingBottom = 24,
                        MarginEnabled = true,
                        MarginLeft = 16,
                        MarginRight = 16
                    }
                },
                Objects = new List<ElementBase>
                 {
                     new EbImage
                     {
                         Id = "afImage3",
                         Name = "logo1",
                         Type = ClientElementType.Image,
                         Configuration = new ImageConfiguration
                         {
                             ImageUrl = "https://mcusercontent.com/edd3202c818e1f341f7b52405/images/dfd39f9d-b362-7c39-3c80-c70400ff7d37.png",
                             AltText = "Cafe Largo",
                             Width = new EbWidth("45%", SizeUnit.Both),
                             Spacing = new SpacingBase
                             {
                                 PaddingEnabled = true,
                                 PaddingTop = 12,
                                 PaddingBottom = 12
                             },
                             Link = new EbLink { LinkEnabled = true, Url = "https://cafelargo.com/", LinkTitle = "Cafe Largo" }
                         }
                     },
                     new EbImage
                     {
                         Id = "afImage4",
                         Name = "",
                         Type = ClientElementType.Image,
                         Configuration = new ImageConfiguration
                         {
                             ImageUrl = "https://mcusercontent.com/edd3202c818e1f341f7b52405/images/db3ccc8e-dfea-bae8-798e-2b1560ca7267.png",
                             AltText = "Cafe Largo",
                             Width = new EbWidth("100%", SizeUnit.Both),
                             Spacing = new SpacingBase
                             {
                                 PaddingEnabled = true,
                                 PaddingTop = 12,
                                 PaddingBottom = 12
                             },
                             Link = new EbLink { LinkEnabled = true, Url = "https://cafelargo.com/", LinkTitle = "bravo" }
                         }
                     }
                 }
            });

            // Section 4 
            sections.Add(new EbSection
            {
                Id = "section4",
                Name = "sec4",
                Type = ClientElementType.Section,
                Configuration = new SectionConfiguration
                {
                    BodyColor = "#FFFFFF",
                    Spacing = new SpacingBase
                    {
                        PaddingEnabled = true,
                        PaddingBottom = 24,
                        PaddingLeft = 23,
                        PaddingRight = 23,
                        MarginEnabled = true,
                        MarginLeft = 16,
                        MarginRight = 16
                    }
                },
                Objects = new List<ElementBase>
                 {
                     new EbText
                     {
                         Id = "",
                         Name = "Summer Happy Hour",
                         Type = ClientElementType.Text,
                         Configuration = new TextConfiguration
                         {
                             TextContent = "<h3><strong><span>Summer Happy Hour</span></strong></h3><p><strong><span style=\"color:rgb(0, 0, 0);\">Monday - Saturday | 4:00 - 7:00</span></strong></p><p>Discounted Cocktails</p><p>Discounted Wines by the glass</p><p>$5.00 Peroni’s</p><p>$10 Happy Hour Food Menu (Bar Bites)</p>",
                             Width = new EbWidth("100%", SizeUnit.Both),
                             Direction = Direction.Ltr,
                             BackgroundColor = "#fff",
                             Spacing = new SpacingBase
                             {
                                 PaddingEnabled = true,
                                 PaddingLeft = 16,
                                 PaddingRight = 16,
                                 MarginEnabled = true,
                                 MarginBottom = 60,
                                 MarginTop = 65
                             }
                         }
                     },
                     new EbText
                     {
                         Id = "blackBtn2",
                         Name = "",
                         Type = ClientElementType.Text,
                         Configuration = new TextConfiguration
                         {
                             TextContent = "<a href=\"https://keylargorestaurants.com/\" style=\"color:#ffffff;\" rel=\"noreferrer\">View Happy Hour Menu</a>",
                             Width = new EbWidth("250px", SizeUnit.Both),
                             Direction = Direction.Ltr,
                             BackgroundColor = "rgb(0, 0, 0)",
                             Spacing = new SpacingBase
                             {
                                 PaddingEnabled = true,
                                 PaddingTop = 18,
                                 PaddingBottom = 18,
                                 PaddingLeft = 28,
                                 PaddingRight = 28,
                                 MarginEnabled = true,
                                 MarginBottom = 12,
                                 MarginTop = 12
                             }
                         }
                     }
                 }
            });

            layout.Sections = sections;
            return layout;
        }
    }
}
 