using System;
using System.Collections.Generic;

namespace SupportSystem.MementoPattern
{
    public class History
    {
        private readonly List<TextDocumentSnapshot> _history = new List<TextDocumentSnapshot>();

        public void Push(TextDocumentSnapshot snapshot)
        {
            _history.Add(snapshot);
        }

        public TextDocumentSnapshot Pop()
        {
            if (_history.Count > 0)
            {
                var lastSnapshot = _history[_history.Count - 1];
                _history.RemoveAt(_history.Count - 1);
                return lastSnapshot;
            }
            else
            {
                Console.WriteLine("Історія скасувань порожня.");
                return null;
            }
        }
    }
}