using System;

namespace SupportSystem.MementoPattern
{
    public class TextEditor
    {
        public TextDocument Document { get; set; }

        public TextEditor()
        {
            Document = new TextDocument();
        }

        public void Write(string text)
        {
            Document.Content += text;
            Console.WriteLine($"Написано: {text}");
        }

        public TextDocumentSnapshot Save()
        {
            Console.WriteLine($"Збережено стан документа: \"{Document.Content}\"");
            return new TextDocumentSnapshot(Document);
        }

        public void Restore(TextDocumentSnapshot snapshot)
        {
            Document.Content = snapshot.Document.Content;
            Console.WriteLine($"Відновлено стан документа до: \"{Document.Content}\" (збережено {snapshot.GetCreationDate()})");
        }
    }
}