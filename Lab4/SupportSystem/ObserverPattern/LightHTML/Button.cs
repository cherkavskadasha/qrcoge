namespace SupportSystem.ObserverPattern.LightHTML
{
    public class Button : HtmlElement
    {
        public string Text { get; set; }

        public Button(string text = "") : base("button")
        {
            Text = text;
        }

        public void SimulateClick()
        {
            NotifyListeners("click");
        }

        public override string Render()
        {
            return $"<button>{Text}</button>";
        }
    }
}