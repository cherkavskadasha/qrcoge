public class LightNodeFactory
{
    private Dictionary<string, LightElementNode> elementCache = new Dictionary<string, LightElementNode>();

    public LightElementNode GetElement(string tagName, string display, string closingType, List<string> classes)
    {
        string key = $"{tagName}-{display}-{closingType}-{string.Join("-", classes)}";

        if (!elementCache.ContainsKey(key))
        {
            elementCache[key] = new LightElementNode(tagName, display, closingType, classes);
        }

        return elementCache[key];
    }
}