using System;

namespace SupportSystem.MementoPattern
{
    public class TextDocumentSnapshot
    {
        public TextDocument Document { get; }
        private readonly DateTime _creationDate;

        public TextDocumentSnapshot(TextDocument document)
        {
            Document = new TextDocument(document.Content); 
            _creationDate = DateTime.Now;
        }

        public DateTime GetCreationDate()
        {
            return _creationDate;
        }
    }
}