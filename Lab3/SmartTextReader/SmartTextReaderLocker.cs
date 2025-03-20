using System.Text.RegularExpressions;

public class SmartTextReaderLocker : SmartTextReader
{
    private SmartTextReader reader;
    private Regex accessRegex;

    public SmartTextReaderLocker(SmartTextReader reader, string pattern)
    {
        this.reader = reader;
        accessRegex = new Regex(pattern);
    }

    public new char[][] ReadFile(string filePath)
    {
        if (accessRegex.IsMatch(filePath))
        {
            Console.WriteLine($"Access denied to file: {filePath}");
            return Array.Empty<char[]>();
        }

        return reader.ReadFile(filePath);
    }
}