public class Program
{
    public static async Task Main(string[] args)
    {
        // Завдання 1: Адаптер
        Logger consoleLogger = new Logger();
        consoleLogger.Log("Console log message");
        consoleLogger.Error("Console error message");
        consoleLogger.Warn("Console warning message");

        string logFilePath = "log.txt"; 
        if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
        {
            logFilePath = args[0];
        }

        FileWriter fileWriter = new FileWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, logFilePath));
        FileLoggerAdapter fileLogger = new FileLoggerAdapter(fileWriter);
        fileLogger.Log("File log message");
        fileLogger.Error("File error message");
        fileLogger.Warn("File warning message");

        Console.WriteLine("Logs written to console and file.");

        // Завдання 2: Декоратор
        Warrior warrior = new Warrior("Conan");
        warrior.DisplayInfo();

        ArmorDecorator armoredWarrior = new ArmorDecorator(warrior);
        armoredWarrior.DisplayInfo();

        WeaponDecorator armedWarrior = new WeaponDecorator(armoredWarrior);
        armedWarrior.DisplayInfo();

        Mage mage = new Mage("Merlin");
        mage.DisplayInfo();

        ArtifactDecorator enchantedMage = new ArtifactDecorator(mage);
        enchantedMage.DisplayInfo();

        Paladin paladin = new Paladin("Arthur");
        paladin.DisplayInfo();

        ArmorDecorator armoredPaladin = new ArmorDecorator(paladin);
        WeaponDecorator armedPaladin = new WeaponDecorator(armoredPaladin);
        armedPaladin.DisplayInfo();

        // Завдання 3: Міст
        IRenderer vectorRenderer = new VectorRenderer();
        IRenderer rasterRenderer = new RasterRenderer();

        Shape vectorCircle = new Circle(vectorRenderer);
        vectorCircle.Draw();

        Shape rasterSquare = new Square(rasterRenderer);
        rasterSquare.Draw();

        Shape vectorTriangle = new Triangle(vectorRenderer);
        vectorTriangle.Draw();

        // Завдання 4: Проксі
        string testFilePath = "test.txt"; 
        File.WriteAllText(testFilePath, "Hello\nWorld");

        SmartTextReader reader = new SmartTextReader();

        SmartTextChecker checker = new SmartTextChecker(reader);
        char[][] content1 = checker.ReadFile(testFilePath);

        SmartTextReaderLocker locker = new SmartTextReaderLocker(reader, ".*\\.locked");
        char[][] content2 = locker.ReadFile(testFilePath);
        char[][] content3 = locker.ReadFile("locked.locked");

        Console.WriteLine("Done.");
        
        // Завдання 5: Компонувальник
        LightElementNode table = new LightElementNode("table", "block", "closed", new List<string> { "table" });
        LightElementNode tr1 = new LightElementNode("tr", "block", "closed", new List<string>());
        LightElementNode td11 = new LightElementNode("td", "block", "closed", new List<string>());
        td11.Children.Add(new LightTextNode("Cell 1.1"));
        LightElementNode td12 = new LightElementNode("td", "block", "closed", new List<string>());
        td12.Children.Add(new LightTextNode("Cell 1.2"));
        tr1.Children.Add(td11);
        tr1.Children.Add(td12);

        LightElementNode tr2 = new LightElementNode("tr", "block", "closed", new List<string>());
        LightElementNode td21 = new LightElementNode("td", "block", "closed", new List<string>());
        td21.Children.Add(new LightTextNode("Cell 2.1"));
        LightElementNode td22 = new LightElementNode("td", "block", "closed", new List<string>());
        td22.Children.Add(new LightTextNode("Cell 2.2"));
        tr2.Children.Add(td21);
        tr2.Children.Add(td22);

        table.Children.Add(tr1);
        table.Children.Add(tr2);

        Console.WriteLine(table.OuterHTML());

        // Завдання 6: Легковаговик
        string fileUrl = "https://www.gutenberg.org/cache/epub/1513/pg1513.txt";
        string bookText = await FileDownloader.DownloadFile(fileUrl);
        string[] lines = bookText.Split('\n');

        LightElementNode html = new LightElementNode("html", "block", "closed", new List<string>());
        LightElementNode body = new LightElementNode("body", "block", "closed", new List<string>());
        html.Children.Add(body);

        LightNodeFactory factory = new LightNodeFactory();

        long memoryBefore = GC.GetTotalMemory(true);
        Console.WriteLine($"Memory before: {memoryBefore} bytes");

        foreach (string line in lines)
        {
            string trimmedLine = line.Trim();

            if (string.IsNullOrEmpty(trimmedLine)) 
                continue;

            if (body.Children.Count == 0)
            {
                LightElementNode h1 = factory.GetElement("h1", "block", "closed", new List<string>());
                h1.Children.Add(new LightTextNode(trimmedLine));
                body.Children.Add(h1);
            }
            else if (trimmedLine.Length < 20)
            {
                LightElementNode p = factory.GetElement("p", "block", "closed", new List<string>());
                p.Children.Add(new LightTextNode(trimmedLine));
                body.Children.Add(p);
            }
            else if (trimmedLine.StartsWith(" "))
            {
                LightElementNode pre = factory.GetElement("pre", "block", "closed", new List<string>());
                pre.Children.Add(new LightTextNode(trimmedLine));
                body.Children.Add(pre);
            }
            else
            {
                LightElementNode div = factory.GetElement("div", "block", "closed", new List<string>());
                div.Children.Add(new LightTextNode(trimmedLine));
                body.Children.Add(div);
            }
        }

        long memoryAfter = GC.GetTotalMemory(true);
        Console.WriteLine($"Memory after: {memoryAfter} bytes");
        Console.WriteLine($"Memory used: {memoryAfter - memoryBefore} bytes");

        Console.WriteLine(html.OuterHTML());
    }
}