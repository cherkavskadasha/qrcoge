using DeviceFactory.Models;

namespace DeviceFactory.Factories
{
    public class KiaomiFactory : IDeviceFactory
    {
        public Laptop CreateLaptop()
        {
            return new Laptop { Brand = "Kiaomi", Model = "RedmiBook" };
        }

        public Netbook CreateNetbook()
        {
            return new Netbook { Brand = "Kiaomi", Model = "Redmi Netbook" };
        }

        public EBook CreateEBook()
        {
            return new EBook { Brand = "Kiaomi", Model = "Mi EBook" };
        }

        public Smartphone CreateSmartphone()
        {
            return new Smartphone { Brand = "Kiaomi", Model = "Redmi Note" };
        }
    }
}