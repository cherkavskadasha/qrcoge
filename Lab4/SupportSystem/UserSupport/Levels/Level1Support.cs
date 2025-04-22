namespace SupportSystem.UserSupport.Levels
{
    public class Level1Support : AbstractSupportHandler
    {
        public override void HandleRequest(int level)
        {
            if (level == 1)
            {
                System.Console.WriteLine("Ваш запит передано на перший рівень підтримки.");
                System.Console.WriteLine("Будь ласка, зачекайте на з'єднання з оператором.");
            }
            else
            {
                base.HandleRequest(level);
            }
        }
    }
}