
using System.Text;

namespace EmailBuilder.Models.Properties
{
    public class SpacingBase
    {
        public bool PaddingEnabled { get; set; } = false;
        public bool MarginEnabled { get; set; } = false;
        public int MarginTop { get; set; } = 0;
        public int MarginBottom { get; set; } = 0;
        public int MarginLeft { get; set; } = 0;
        public int MarginRight { get; set; } = 0;
        public int PaddingTop { get; set; } = 0;
        public int PaddingBottom { get; set; } = 0;
        public int PaddingLeft { get; set; } = 0;
        public int PaddingRight { get; set; } = 0;


        public SpacingBase() { 
           
        }

        /// <summary>
        /// Sets all padding values at once.
        /// </summary>
        public void SetPadding(bool isPadding, int top, int right, int bottom, int left)
        {
            PaddingEnabled = isPadding;
            PaddingTop = top;
            PaddingRight = right;
            PaddingBottom = bottom;
            PaddingLeft = left;
        }

        /// <summary>
        /// Sets all margin values at once.
        /// </summary>
        public void SetMargin(bool isMargin, int top, int bottom, int left,int right)
        {
            MarginEnabled = isMargin;
            MarginTop = top;
            MarginBottom = bottom;
            MarginLeft = left;
            MarginRight = right;
        }

        public virtual string GetHtmlStyle
        {
            get
            {
                return PaddingEnabled ? $"padding: {PaddingTop}px {PaddingRight}px {PaddingBottom}px {PaddingLeft}px;" : $"padding:0px;";
            }
        }


        public virtual string GetOuterHtmlStyle
        {
            get
            {
                return MarginEnabled ? $"padding:{MarginTop}px {MarginRight}px {MarginBottom}px {MarginLeft}px;" : $"padding:0px;";
            }
        }

    }
}