namespace DeviceFactory.Models
{
    public class Laptop
    {
        public string Brand { get; set; }
        public string Model { get; set; }

        public override string ToString()
        {
            return $"Laptop: {Brand} {Model}";
        }
    }
}