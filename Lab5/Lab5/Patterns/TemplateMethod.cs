using System;

namespace Lab5.Patterns
{
    public abstract class HTMLElement
    {
        public string Name { get; }

        protected HTMLElement(string name)
        {
            Name = name;
        }

        public void Render()
        {
            OnCreated();
            OnInserted();
            OnRendered();
            OnRemoved();
        }

        protected virtual void OnCreated() => Console.WriteLine($"{Name} created.");
        protected virtual void OnInserted() => Console.WriteLine($"{Name} inserted.");
        protected virtual void OnRendered() => Console.WriteLine($"{Name} rendered.");
        protected virtual void OnRemoved() => Console.WriteLine($"{Name} removed.");
    }

    public class ParagraphElement : HTMLElement
    {
        public ParagraphElement() : base("Paragraph") { }

        protected override void OnRendered() => Console.WriteLine("Rendering paragraph element.");
    }

    public class HeaderElement : HTMLElement
    {
        public HeaderElement() : base("Header") { }

        protected override void OnRendered() => Console.WriteLine("Rendering header element.");
    }

    public class FooterElement : HTMLElement
    {
        public FooterElement() : base("Footer") { }

        protected override void OnRendered() => Console.WriteLine("Rendering footer element.");
    }
}
