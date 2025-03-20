public abstract class InventoryDecorator : Hero
{
    protected Hero hero;

    public InventoryDecorator(Hero hero, string name, int health, int damage) : base(name, health, damage)
    {
        this.hero = hero;
    }

    public override void DisplayInfo()
    {
        hero.DisplayInfo();
        Console.WriteLine($", {Name} (Health: {Health}, Damage: {Damage})");
    }
}