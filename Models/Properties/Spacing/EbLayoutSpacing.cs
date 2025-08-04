
using System.Text;

namespace EmailBuilder.Models.Properties.Spacing
{
    public class EbLayoutSpacing : SpacingBase
    {
        public EbLayoutSpacing() { 
           
        }

        public override string GetHtmlStyle
        {
            get
            {
                return PaddingEnabled ? $"padding: {PaddingTop}px 0px {PaddingBottom}px 0px;" : $"padding:0px;";
            }
        }

        
        public override string GetOuterHtmlStyle
        {
            get
            {
                return string.Empty;
            }
        }

    }
}