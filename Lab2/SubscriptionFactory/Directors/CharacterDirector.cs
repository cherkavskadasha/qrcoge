using SubscriptionFactory.Builders;
using SubscriptionFactory.Models;

namespace SubscriptionFactory.Directors
{
    public class CharacterDirector
    {
        public Character ConstructHero(ICharacterBuilder builder)
        {
            return builder
                .SetName("Артур")
                .SetHeight(180)
                .SetBuild("атлетичний")
                .SetHairColor("русявий")
                .SetEyeColor("блакитні")
                .SetClothing("лицарські обладунки")
                .AddInventoryItem("меч")
                .AddInventoryItem("щит")
                .GetCharacter();
        }

        public Character ConstructEnemy(ICharacterBuilder builder)
        {
            return builder
                .SetName("Мордред")
                .SetHeight(190)
                .SetBuild("міцний")
                .SetHairColor("чорний")
                .SetEyeColor("червоні")
                .SetClothing("темні обладунки")
                .AddInventoryItem("дворучний меч")
                .GetCharacter();
        }
    }
}