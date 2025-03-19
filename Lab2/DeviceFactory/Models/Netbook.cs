namespace DeviceFactory.Models
{
    public class Netbook
    {
        public string Brand { get; set; }
        public string Model { get; set; }

        public override string ToString()
        {
            return $"Netbook: {Brand} {Model}";
        }
    }
}