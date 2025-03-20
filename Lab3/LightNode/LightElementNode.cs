using System.Text;

public class LightElementNode : LightNode
{
    public string TagName { get; set; }
    public string Display { get; set; }
    public string ClosingType { get; set; }
    public List<string> Classes { get; set; }
    public List<LightNode> Children { get; set; }

    public LightElementNode(string tagName, string display, string closingType, List<string> classes)
    {
        TagName = tagName;
        Display = display;
        ClosingType = closingType;
        Classes = classes;
        Children = new List<LightNode>();
    }

    public override string OuterHTML()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"<{TagName}");

        if (Classes.Count > 0)
        {
            sb.Append($" class=\"{string.Join(" ", Classes)}\"");
        }

        if (ClosingType == "single")
        {
            sb.Append(" />");
        }
        else
        {
            sb.Append(">");
            sb.Append(InnerHTML());
            sb.Append($"</{TagName}>");
        }

        return sb.ToString();
    }

    public override string InnerHTML()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var child in Children)
        {
            sb.Append(child.OuterHTML());
        }
        return sb.ToString();
    }
}