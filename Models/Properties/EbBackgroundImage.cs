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

    /// <summary>
    /// Represents the background image properties for an email element.
    /// </summary>
    public class EbBackgroundImage
    {
        public bool BackgroundImageEnabled { get; set; } = false;
        public string ImageUrl { get; set; } = string.Empty;
        public ImageRepeat ImageRepeat { get; set; } = ImageRepeat.NoRepeat;
        public Position ImagePosition { get; set; } = Position.Center;
        public ImageSize ImageSize { get; set; } = ImageSize.Contain;


        public EbBackgroundImage() { }
        public EbBackgroundImage(bool backgroundImageEnabled, string url, ImageRepeat repeat = ImageRepeat.NoRepeat, Position position = Position.Center, ImageSize size = ImageSize.Contain)
        {
            BackgroundImageEnabled = backgroundImageEnabled;
            ImageUrl = url;
            ImageRepeat = repeat;
            ImagePosition = position;
            ImageSize = size;
        }

        private string SafeUrl
        {  
            get
            {
                return string.IsNullOrEmpty(ImageUrl) ? string.Empty : ImageUrl.Replace("'", "\\'");
            }
        }

        internal string GetHtmlStyle
        {
            get
            {
                if (!BackgroundImageEnabled || string.IsNullOrEmpty(ImageUrl))
                {
                    return string.Empty; // No background image set
                }
                
                return $"background-image:url('{SafeUrl}'); " +
                       $"background-repeat:{ImageRepeat.ToString().Replace('_','-').ToLower()}; " +
                       $"background-position:{ImagePosition.ToString().ToLower()}; " +
                       $"background-size:{ImageSize.ToString().ToLower()};";
            }
        }

    }
}