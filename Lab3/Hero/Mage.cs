public class Mage : Hero
{
    public Mage(string name) : base(name, 100, 50) { }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Mage: {Name}, Health: {Health}, Damage: {Damage}");
    }
}