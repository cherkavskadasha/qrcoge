namespace SupportSystem.ObserverPattern.LightHTML
{
    public class FileImageLoadStrategy : IImageLoadStrategy
    {
        public string Load(string href)
        {
            string filePath = href.Substring("file://".Length);
            return $"Зображення з файлу: {filePath}";
        }
    }
}