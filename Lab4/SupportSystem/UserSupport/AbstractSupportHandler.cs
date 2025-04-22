namespace SupportSystem.UserSupport
{
    public abstract class AbstractSupportHandler : ISupportHandler
    {
        private ISupportHandler _nextHandler;

        public ISupportHandler SetNext(ISupportHandler handler)
        {
            this._nextHandler = handler;
            return handler;
        }

        public virtual void HandleRequest(int level)
        {
            if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(level);
            }
            else
            {
                System.Console.WriteLine("Вибачте, відповідний рівень підтримки не знайдено.");
            }
        }
    }
}