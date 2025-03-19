using DeviceFactory.Models;

namespace DeviceFactory.Factories
{
    public class BalaxyFactory : IDeviceFactory
    {
        public Laptop CreateLaptop()
        {
            return new Laptop { Brand = "Balaxy", Model = "Book Pro" };
        }

        public Netbook CreateNetbook()
        {
            return new Netbook { Brand = "Balaxy", Model = "Balaxy Netbook" };
        }

        public EBook CreateEBook()
        {
            return new EBook { Brand = "Balaxy", Model = "Balaxy EBook" };
        }

        public Smartphone CreateSmartphone()
        {
            return new Smartphone { Brand = "Balaxy", Model = "Balaxy S" };
        }
    }
}