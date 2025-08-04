namespace EmailBuilder.Models.Properties
{
    public enum LinkType
    {
        Url
    }

    public enum TargetType
    {
        _blank,
        _self
    }

    public class EbLink
    {
        public bool LinkEnabled { get; set; } = false;
        public LinkType LinkType { get; set; } = LinkType.Url;
        public TargetType Target { get; set; } = TargetType._blank;
        public string Url { get; set; }
        public string LinkTitle { get; set; } = string.Empty;

        public EbLink() { }

        public string WrapWithLink(string html)
        {
            if (!LinkEnabled || string.IsNullOrEmpty(Url))
                return html;

            return $"<a href=\"{Url}\" title=\"{LinkTitle}\">{html}</a>";
        }
    }
}
