using System;

namespace Lab5.Patterns
{
    abstract class HTMLElement
    {
        public void Render()
        {
            OnCreated();
            OnInserted();
            OnTextRendered();
            OnStylesApplied();
            OnRemoved();
        }

        protected virtual void OnCreated() => Console.WriteLine("Element created");
        protected virtual void OnInserted() => Console.WriteLine("Element inserted");
        protected virtual void OnTextRendered() => Console.WriteLine("Text rendered");
        protected virtual void OnStylesApplied() => Console.WriteLine("Styles applied");
        protected virtual void OnRemoved() => Console.WriteLine("Element removed");
    }

    class ParagraphElement : HTMLElement
    {
        protected override void OnTextRendered() => Console.WriteLine("Paragraph text rendered");
    }
}
