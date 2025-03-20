public class Paladin : Hero
{
    public Paladin(string name) : base(name, 200, 30) { }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Paladin: {Name}, Health: {Health}, Damage: {Damage}");
    }
}