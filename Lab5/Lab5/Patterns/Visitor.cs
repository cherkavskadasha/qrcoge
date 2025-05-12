using System;

namespace Lab5.Patterns
{
    public interface IVisitor
    {
        void Visit(HTMLElement element);
    }

    public class StyleVisitor : IVisitor
    {
        public void Visit(HTMLElement element)
        {
            Console.WriteLine($"Applying style to: {element.Name}");
        }
    }
}
