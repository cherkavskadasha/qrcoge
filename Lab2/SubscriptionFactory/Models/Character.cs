namespace SubscriptionFactory.Models
{
    public class Character
    {
        public string Name { get; set; }
        public int Height { get; set; }
        public string Build { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string Clothing { get; set; }
        public List<string> Inventory { get; set; }
        public List<string> GoodDeeds { get; set; }
        public List<string> EvilDeeds { get; set; }

        public Character()
        {
            Inventory = new List<string>();
            GoodDeeds = new List<string>();
            EvilDeeds = new List<string>();
        }

        public override string ToString()
        {
            string info = $"Name: {Name}\nHeight: {Height}\nBuild: {Build}\nHair Color: {HairColor}\nEye Color: {EyeColor}\nClothing: {Clothing}\nInventory: {string.Join(", ", Inventory)}";
            if (GoodDeeds.Count > 0)
            {
                info += $"\nGood Deeds: {string.Join(", ", GoodDeeds)}";
            }
            if (EvilDeeds.Count > 0)
            {
                info += $"\nEvil Deeds: {string.Join(", ", EvilDeeds)}";
            }
            return info;
        }
    }
}