namespace SupportSystem.ObserverPattern.LightHTML
{
    public class Image : HtmlElement
    {
        private IImageLoadStrategy _loadStrategy;
        public string Href { get; set; }

        public Image(string href) : base("img")
        {
            Href = href;
            SetLoadStrategy(href);
        }

        public void SetLoadStrategy(string href)
        {
            if (href.StartsWith("file://"))
            {
                _loadStrategy = new FileImageLoadStrategy();
            }
            else if (href.StartsWith("http://") || href.StartsWith("https://"))
            {
                _loadStrategy = new NetworkImageLoadStrategy();
            }
            else
            {
                _loadStrategy = new DefaultImageLoadStrategy();
            }
        }

        public string LoadImage()
        {
            return _loadStrategy.Load(Href);
        }

        public override string Render()
        {
            return $"<img src=\"{Href}\" alt=\"{LoadImage()}\">";
        }
    }
}