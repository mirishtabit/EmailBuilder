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

    public class AfBorderSide
    {
        public BorderSide BorderSide { get; set; }
        public int BorderWidth { get; set; } = 0;
        public string BorderColor { get; set; } = "#000000";
        public BorderStyle BorderStyle { get; set; } = BorderStyle.Solid;
    }


    public class EbBorder
    {
        public bool BorderEnabled { get; set; } = false;
        public List<AfBorderSide> Sides { get; set; } = new List<AfBorderSide>();
       
        public EbBorder()
        {
            Sides = new List<AfBorderSide>
            {
                new AfBorderSide { BorderSide = BorderSide.Top },
                new AfBorderSide { BorderSide = BorderSide.Right },
                new AfBorderSide { BorderSide = BorderSide.Bottom},
                new AfBorderSide { BorderSide = BorderSide.Left }
            };
        }

        public string GetHtmlStyle
        {
            get
            {
                if (!BorderEnabled)
                {
                    return string.Empty;
                }
               
                StringBuilder sbStyle = new StringBuilder(string.Empty);
                
                foreach (var border in Sides)
                {
                    if (border.BorderWidth <= 0)
                    {
                        continue; // Skip borders with zero width
                    }
                    sbStyle.Append(BuildBorderStyle(border));
                } 
                return sbStyle.ToString();
            }
        }

        private string BuildBorderStyle(AfBorderSide br)
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
