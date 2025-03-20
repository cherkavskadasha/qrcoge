public class FileLoggerAdapter
{
    private FileWriter fileWriter;

    public FileLoggerAdapter(FileWriter fileWriter)
    {
        this.fileWriter = fileWriter;
    }

    public void Log(string message)
    {
        fileWriter.WriteLine($"LOG: {message}");
    }

    public void Error(string message)
    {
        fileWriter.WriteLine($"ERROR: {message}");
    }

    public void Warn(string message)
    {
        fileWriter.WriteLine($"WARN: {message}");
    }
}