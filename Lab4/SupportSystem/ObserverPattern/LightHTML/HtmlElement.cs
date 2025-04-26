using System.Collections.Generic;

namespace SupportSystem.ObserverPattern.LightHTML
{
    public abstract class HtmlElement
    {
        public string TagName { get; } 
        protected Dictionary<string, List<IEventListener>> Listeners = new Dictionary<string, List<IEventListener>>();

        protected HtmlElement(string tagName)
        {
            TagName = tagName;
        }

        public void AddEventListener(string eventType, IEventListener listener)
        {
            if (!Listeners.ContainsKey(eventType))
            {
                Listeners[eventType] = new List<IEventListener>();
            }
            Listeners[eventType].Add(listener);
        }

        public void RemoveEventListener(string eventType, IEventListener listener)
        {
            if (Listeners.ContainsKey(eventType))
            {
                Listeners[eventType].Remove(listener);
            }
        }

        protected void NotifyListeners(string eventType)
        {
            if (Listeners.ContainsKey(eventType))
            {
                foreach (var listener in Listeners[eventType])
                {
                    listener.Update(eventType, this);
                }
            }
        }

        public abstract string Render();
    }
}