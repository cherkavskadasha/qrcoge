namespace DeviceFactory.Models
{
    public class Smartphone
    {
        public string Brand { get; set; }
        public string Model { get; set; }

        public override string ToString()
        {
            return $"Smartphone: {Brand} {Model}";
        }
    }
}