public abstract class Hero
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }

    public Hero(string name, int health, int damage)
    {
        Name = name;
        Health = health;
        Damage = damage;
    }

    public abstract void DisplayInfo();
}