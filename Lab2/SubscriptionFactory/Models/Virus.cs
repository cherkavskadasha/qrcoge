namespace SubscriptionFactory.Models
{
    public class Virus : ICloneable
    {
        public double Weight { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public List<Virus> Children { get; set; }

        public Virus(string name, string species, double weight, int age)
        {
            Name = name;
            Species = species;
            Weight = weight;
            Age = age;
            Children = new List<Virus>();
        }

        public object Clone()
        {
            Virus clonedVirus = (Virus)MemberwiseClone();
            clonedVirus.Children = new List<Virus>();

            foreach (var child in Children)
            {
                clonedVirus.Children.Add((Virus)child.Clone());
            }

            return clonedVirus;
        }

        public void DisplayVirusInfo(int depth = 0)
        {
            string indent = new string(' ', depth * 2);
            Console.WriteLine($"{indent}Name: {Name}, Species: {Species}, Weight: {Weight}, Age: {Age}");

            foreach (var child in Children)
            {
                child.DisplayVirusInfo(depth + 1);
            }
        }
    }
}