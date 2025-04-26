namespace SupportSystem.ObserverPattern.LightHTML
{
    public interface IEventListener
    {
        void Update(string eventType, HtmlElement element);
    }
}