namespace SupportSystem.UserSupport.Levels
{
    public class Level3Support : AbstractSupportHandler
    {
        public override void HandleRequest(int level)
        {
            if (level == 3)
            {
                System.Console.WriteLine("Ваш запит передано на третій рівень підтримки.");
                System.Console.WriteLine("Для вирішення вашого питання потрібен досвідчений фахівець.");
            }
            else
            {
                base.HandleRequest(level);
            }
        }
    }
}