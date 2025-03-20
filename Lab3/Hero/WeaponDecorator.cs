public class WeaponDecorator : InventoryDecorator
{
    public WeaponDecorator(Hero hero) : base(hero, "Weapon", 0, 30) { }
}