namespace SupportSystem.ObserverPattern.LightHTML
{
    public class Div : HtmlElement
    {
        public string Content { get; set; }

        public Div(string content = "") : base("div")
        {
            Content = content;
        }

        public void SimulateClick()
        {
            NotifyListeners("click");
        }

        public void SimulateMouseOver()
        {
            NotifyListeners("mouseover");
        }

        public override string Render()
        {
            return $"<div>{Content}</div>";
        }
    }
}