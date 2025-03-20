public class Warrior : Hero
{
    public Warrior(string name) : base(name, 150, 20) { }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Warrior: {Name}, Health: {Health}, Damage: {Damage}");
    }
}