namespace DeviceFactory.Models
{
    public class EBook
    {
        public string Brand { get; set; }
        public string Model { get; set; }

        public override string ToString()
        {
            return $"EBook: {Brand} {Model}";
        }
    }
}