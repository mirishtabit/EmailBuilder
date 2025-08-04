using EmailBuilder.Common;

namespace EmailBuilder.Models.HtmlProperties
{
    public enum ImageRepeat
    {
        NoRepeat,
        Repeat,
        RepeatX,
        RepeatY
    }

    public enum ImageSize
    {
        Cover,
        Contain
    }

    public class EbBackgroundImage
    {
        public bool BackgroundImageEnabled { get; set; } = false;
        public string ImageUrl { get; set; } = string.Empty;
        public ImageRepeat ImageRepeat { get; set; }
        public Position ImagePosition { get; set; }
        public ImageSize ImageSize { get; set; }


        public EbBackgroundImage() { }
        public EbBackgroundImage(bool backgroundImageEnabled, string url, ImageRepeat repeat = ImageRepeat.NoRepeat, Position position = Position.Center, ImageSize size = ImageSize.Contain)
        {
            BackgroundImageEnabled = backgroundImageEnabled;
            ImageUrl = url;
            ImageRepeat = repeat;
            ImagePosition = position;
            ImageSize = size;
        }

        public string GetHtmlStyle
        {
            get
            {
                if (!BackgroundImageEnabled || string.IsNullOrEmpty(ImageUrl))
                {
                    return string.Empty; // No background image set
                }
                return $"background-image:url('{ImageUrl}'); " +
                       $"background-repeat:{ImageRepeat.ToString().Replace('_','-').ToLower()}; " +
                       $"background-position:{ImagePosition.ToString().ToLower()}; " +
                       $"background-size:{ImageSize.ToString().ToLower()};";
            }
        }

    }
}