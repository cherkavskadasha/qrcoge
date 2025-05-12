using System;

namespace Lab5.Patterns
{
    // Інтерфейс команди
    public interface ICommand
    {
        void Execute();
    }

    public class AddElementCommand : ICommand
    {
        private readonly HTMLElement element;

        public AddElementCommand(HTMLElement element)
        {
            this.element = element;
        }

        public void Execute()
        {
            Console.WriteLine($"Command: Adding {element.Name}");
            element.Render();
        }
    }
}
