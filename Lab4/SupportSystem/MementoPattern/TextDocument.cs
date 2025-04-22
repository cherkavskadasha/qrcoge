namespace SupportSystem.MementoPattern
{
    public class TextDocument
    {
        public string Content { get; set; }

        public TextDocument(string content = "")
        {
            Content = content;
        }
    }
}