using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab5.Patterns
{
    public class HTMLElementCollection : IEnumerable<HTMLElement>
    {
        private readonly List<HTMLElement> elements = new();

        public void Add(HTMLElement element) => elements.Add(element);

        public IEnumerator<HTMLElement> GetEnumerator() => elements.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
