public class Money
{
    public int WholePart { get; set; }
    public int FractionalPart { get; set; }
    public string Currency { get; set; }

    public Money(int wholePart, int fractionalPart, string currency)
    {
        WholePart = wholePart;
        FractionalPart = fractionalPart;
        Currency = currency;
    }

    public void Display()
    {
        Console.WriteLine($"{WholePart}.{FractionalPart:00} {Currency}");
    }
}

public class Product
{
    public string Name { get; set; }
    public Money Price { get; set; }
    public string Category { get; set; }

    public Product(string name, Money price, string category)
    {
        Name = name;
        Price = price;
        Category = category;
    }

    public void ReducePrice(int amount)
    {
        if (Price.WholePart >= amount)
        {
            Price.WholePart -= amount;
        }
        else
        {
            Console.WriteLine("Недостатньо коштів для зменшення ціни.");
        }
    }
}

public class Warehouse
{
    public string Name { get; set; }
    public string Unit { get; set; }
    public Money PricePerUnit { get; set; }
    public int Quantity { get; set; }
    public DateTime LastArrival { get; set; }

    public Warehouse(string name, string unit, Money pricePerUnit, int quantity, DateTime lastArrival)
    {
        Name = name;
        Unit = unit;
        PricePerUnit = pricePerUnit;
        Quantity = quantity;
        LastArrival = lastArrival;
    }

    public void Display()
    {
        Console.WriteLine($"Назва: {Name}, Одиниця: {Unit}, Ціна: ");
        PricePerUnit.Display();
        Console.WriteLine($"Кількість: {Quantity}, Останній завіз: {LastArrival.ToShortDateString()}");
    }
}

public class Reporting
{
    private List<Warehouse> inventory = new List<Warehouse>();
    private List<string> incomingInvoices = new List<string>();
    private List<string> outgoingInvoices = new List<string>();

    public void RegisterArrival(Warehouse item, string invoice)
    {
        inventory.Add(item);
        incomingInvoices.Add(invoice);
        Console.WriteLine($"Товар {item.Name} додано до складу. Накладна: {invoice}");
    }

    public void RegisterShipment(string itemName, int quantity, string invoice)
    {
        Warehouse item = inventory.Find(i => i.Name == itemName);
        if (item != null && item.Quantity >= quantity)
        {
            item.Quantity -= quantity;
            outgoingInvoices.Add(invoice);
            Console.WriteLine($"Товар {itemName} відвантажено зі складу. Накладна: {invoice}");
        }
        else
        {
            Console.WriteLine("Недостатньо товару на складі.");
        }
    }

    public void InventoryReport()
    {
        Console.WriteLine("Звіт по інвентаризації:");
        foreach (var item in inventory)
        {
            item.Display();
        }
    }
}

public class ShoppingCart
{
    private List<Tuple<Product, int>> items = new List<Tuple<Product, int>>();

    public void AddItem(Product product, int quantity)
    {
        items.Add(Tuple.Create(product, quantity));
        Console.WriteLine($"Товар {product.Name} додано до корзини в кількості {quantity} шт.");
    }

    public void DisplayCart()
    {
        Console.WriteLine("Корзина замовлень:");
        foreach (var item in items)
        {
            Console.WriteLine($"{item.Item1.Name} - {item.Item2} шт.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Money price1 = new Money(10, 50, "USD");
        Product product1 = new Product("Телефон", price1, "Електроніка");

        Money price2 = new Money(5, 0, "EUR");
        Warehouse warehouse1 = new Warehouse("Книга", "шт.", price2, 100, DateTime.Now);

        Reporting reporting = new Reporting();
        ShoppingCart cart = new ShoppingCart();

        reporting.RegisterArrival(warehouse1, "Прибуткова накладна 1");
        reporting.InventoryReport();

        cart.AddItem(product1, 1);
        cart.DisplayCart();

        product1.ReducePrice(3);
        Console.WriteLine("Ціна товару після знижки:");
        product1.Price.Display();

        reporting.RegisterShipment("Книга", 10, "Видаткова накладна 1");
        reporting.InventoryReport();
    }
}