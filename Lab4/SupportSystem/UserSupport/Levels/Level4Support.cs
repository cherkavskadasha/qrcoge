namespace SupportSystem.UserSupport.Levels
{
    public class Level4Support : AbstractSupportHandler
    {
        public override void HandleRequest(int level)
        {
            if (level == 4)
            {
                System.Console.WriteLine("Ваш запит передано на четвертий рівень підтримки.");
                System.Console.WriteLine("Ми докладемо всіх зусиль, щоб вам допомогти.");
            }
            else
            {
                base.HandleRequest(level);
            }
        }
    }
}