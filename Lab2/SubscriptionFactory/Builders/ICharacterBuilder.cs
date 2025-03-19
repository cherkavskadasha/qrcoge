using SubscriptionFactory.Models;

namespace SubscriptionFactory.Builders
{
    public interface ICharacterBuilder
    {
        ICharacterBuilder SetName(string name);
        ICharacterBuilder SetHeight(int height);
        ICharacterBuilder SetBuild(string build);
        ICharacterBuilder SetHairColor(string color);
        ICharacterBuilder SetEyeColor(string color);
        ICharacterBuilder SetClothing(string clothing);
        ICharacterBuilder AddInventoryItem(string item);
        Character GetCharacter();
    }
}