namespace SupportSystem.UserSupport
{
    using UserSupport.Levels;

    public class SupportSystem
    {
        private ISupportHandler _handlerChain;

        public SupportSystem()
        {
            ISupportHandler level1 = new Level1Support();
            ISupportHandler level2 = new Level2Support();
            ISupportHandler level3 = new Level3Support();
            ISupportHandler level4 = new Level4Support();

            level1.SetNext(level2).SetNext(level3).SetNext(level4);
            _handlerChain = level1;
        }

        public void ProcessRequest(int level)
        {
            _handlerChain.HandleRequest(level);
        }
    }
}