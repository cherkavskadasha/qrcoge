public class SmartTextChecker : SmartTextReader
{
    private SmartTextReader reader;

    public SmartTextChecker(SmartTextReader reader)
    {
        this.reader = reader;
    }

    public new char[][] ReadFile(string filePath)
    {
        Console.WriteLine($"Opening file: {filePath}");
        char[][] content = reader.ReadFile(filePath);
        Console.WriteLine($"File read successfully: {filePath}");

        int linesCount = content.Length;
        int charsCount = 0;
        foreach (var line in content)
        {
            charsCount += line.Length;
        }

        Console.WriteLine($"Lines: {linesCount}, Chars: {charsCount}");
        Console.WriteLine($"Closing file: {filePath}");

        return content;
    }
}