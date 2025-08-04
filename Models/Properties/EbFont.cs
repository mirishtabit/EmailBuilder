namespace EmailBuilder.Models.HtmlProperties
{
    public enum FontStyle
    {
        Normal,
        Italic,
        Oblique
    }

    public enum FontWeight
    {
        Normal,
        Bold,
        Bolder,
        Lighter
    }


    public class EbFont
    {
        public string FontFamily { get; set; } = "Arial";
        public double FontSize { get; set; } = 16; // in pixels
        public FontStyle FontStyle { get; set; } = FontStyle.Normal;
        public FontWeight FontWeight { get; set; } = FontWeight.Normal;
       

      
    }
}