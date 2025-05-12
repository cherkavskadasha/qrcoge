using System;
using Lab5.Patterns;

namespace Lab5
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Command Pattern ===");
            ICommand addCommand = new AddElementCommand(new HeaderElement());
            addCommand.Execute();
            Console.WriteLine();

            Console.WriteLine("=== Template Method Pattern ===");
            HTMLElement paragraph = new ParagraphElement();
            paragraph.Render();
            Console.WriteLine();

            Console.WriteLine("=== Iterator Pattern ===");
            HTMLElementCollection collection = new();
            collection.Add(new ParagraphElement());
            collection.Add(new HeaderElement());
            collection.Add(new FooterElement());

            foreach (var el in collection)
            {
                Console.WriteLine($"Element: {el.Name}");
                el.Render();
            }
            Console.WriteLine();

            Console.WriteLine("=== State Pattern ===");
            HTMLComponent component = new HTMLComponent(new VisibleState());
            component.Render();
            component.SetState(new HiddenState());
            component.Render();
            Console.WriteLine();

            Console.WriteLine("=== Visitor Pattern ===");
            IVisitor styleVisitor = new StyleVisitor();
            foreach (var el in collection)
            {
                styleVisitor.Visit(el);
            }

            Console.WriteLine("\nProgram finished.");
        }
    }
}
