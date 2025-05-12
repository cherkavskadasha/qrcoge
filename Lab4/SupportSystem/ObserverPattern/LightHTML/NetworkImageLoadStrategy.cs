namespace SupportSystem.ObserverPattern.LightHTML
{
    public class NetworkImageLoadStrategy : IImageLoadStrategy
    {
        public string Load(string href)
        {
            return $"Зображення з мережі: {href}";
        }
    }
}