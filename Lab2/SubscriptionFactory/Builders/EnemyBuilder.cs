using SubscriptionFactory.Models;

namespace SubscriptionFactory.Builders
{
    public class EnemyBuilder : ICharacterBuilder
    {
        private Character character = new Character();

        public ICharacterBuilder SetName(string name)
        {
            character.Name = name;
            return this;
        }

        public ICharacterBuilder SetHeight(int height)
        {
            character.Height = height;
            return this;
        }

        public ICharacterBuilder SetBuild(string build)
        {
            character.Build = build;
            return this;
        }

        public ICharacterBuilder SetHairColor(string color)
        {
            character.HairColor = color;
            return this;
        }

        public ICharacterBuilder SetEyeColor(string color)
        {
            character.EyeColor = color;
            return this;
        }

        public ICharacterBuilder SetClothing(string clothing)
        {
            character.Clothing = clothing;
            return this;
        }

        public ICharacterBuilder AddInventoryItem(string item)
        {
            character.Inventory.Add(item);
            return this;
        }

        public EnemyBuilder AddEvilDeed(string deed)
        {
            character.EvilDeeds.Add(deed);
            return this;
        }

        public Character GetCharacter()
        {
            return character;
        }
    }
}