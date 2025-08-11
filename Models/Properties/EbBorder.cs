using System;
using System.Collections.Generic;
using System.Text;

namespace EmailBuilder.Models.HtmlProperties
{
    public enum BorderStyle
    {
        Solid,
        Dashed,
        Dotted,
        Double
    }

    public enum BorderSide
    {
        Top,
        Right,
        Bottom,
        Left,
        All
    }

    /// <summary>
    /// Represents a single border side with its properties.
    /// </summary>
    public class EbBorderSide
    {
        public BorderSide BorderSide { get; set; } = BorderSide.Top;
        public int BorderWidth { get; set; } = 0;
        public string BorderColor { get; set; } = "#000000";
        public BorderStyle BorderStyle { get; set; } = BorderStyle.Solid;
    }

    /// <summary>
    /// Represents the border properties for an email element.
    /// </summary>
    public class EbBorder
    {
        public bool BorderEnabled { get; set; } = false;
        public List<EbBorderSide> Sides { get; set; } = new List<EbBorderSide>();
       
        public EbBorder()
        {
            Sides = new List<EbBorderSide>
            {
                new EbBorderSide { BorderSide = BorderSide.Top },
                new EbBorderSide { BorderSide = BorderSide.Right },
                new EbBorderSide { BorderSide = BorderSide.Bottom},
                new EbBorderSide { BorderSide = BorderSide.Left }
            };
        }

        internal string GetHtmlStyle
        {
            get
            {
                if (!BorderEnabled)
                {
                    return string.Empty;
                }
               
                StringBuilder sbStyle = new StringBuilder(string.Empty);

                if (Sides == null)
                    return string.Empty;

                foreach (var border in Sides)
                {
                    if (border.BorderWidth < 0)
                    {
                        throw new ArgumentException("Border width must be greater than zero.", nameof(border.BorderWidth));  
                    }
                    if (border.BorderWidth == 0)
                    {
                        continue;
                    }
                    sbStyle.Append(BuildBorderStyle(border));
                } 
                return sbStyle.ToString();
            }
        }

        private string BuildBorderStyle(EbBorderSide br)
        {
            string styleValue = $"{br.BorderWidth}px {br.BorderStyle.ToString().ToLower()} {br.BorderColor}";

            switch (br.BorderSide)
            {
                case BorderSide.Top:
                    return $"border-top:{styleValue};";
                    
                case BorderSide.Right:
                    return $"border-right:{styleValue};";

                case BorderSide.Bottom:
                    return $"border-bottom: {styleValue};";
                  
                case BorderSide.Left:
                    return $"border-left: {styleValue};";
                
                default:
                    return string.Empty; // No valid border side specified

            }
        }
    }
}
