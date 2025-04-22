namespace SupportSystem.UserSupport
{
    public interface ISupportHandler
    {
        ISupportHandler SetNext(ISupportHandler handler);
        void HandleRequest(int level);
    }
}