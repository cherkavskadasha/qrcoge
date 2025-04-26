using SupportSystem.ObserverPattern.LightHTML;
using System;

namespace SupportSystem.ObserverPattern
{
    public class ConsoleLogger : IEventListener
    {
        private readonly string _name;

        public ConsoleLogger(string name)
        {
            _name = name;
        }

        public void Update(string eventType, HtmlElement element)
        {
            Console.WriteLine($"[{_name}] Відбулась подія '{eventType}' на елементі <{element.TagName}>");
        }
    }
}