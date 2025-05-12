namespace SupportSystem.ObserverPattern.LightHTML
{
    public class DefaultImageLoadStrategy : IImageLoadStrategy
    {
        public string Load(string href)
        {
            return $"Невідомий протокол для завантаження: {href}";
        }
    }
}