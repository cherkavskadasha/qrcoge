namespace SupportSystem.UserSupport.Levels
{
    public class Level2Support : AbstractSupportHandler
    {
        public override void HandleRequest(int level)
        {
            if (level == 2)
            {
                System.Console.WriteLine("Ваш запит передано на другий рівень підтримки.");
                System.Console.WriteLine("Спеціаліст другого рівня допоможе вам.");
            }
            else
            {
                base.HandleRequest(level);
            }
        }
    }
}