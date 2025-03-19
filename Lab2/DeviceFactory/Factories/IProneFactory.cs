using DeviceFactory.Models;

namespace DeviceFactory.Factories
{
    public class IProneFactory : IDeviceFactory
    {
        public Laptop CreateLaptop()
        {
            return new Laptop { Brand = "IProne", Model = "MacBook" };
        }

        public Netbook CreateNetbook()
        {
            return new Netbook { Brand = "IProne", Model = "NetBook Mini" };
        }

        public EBook CreateEBook()
        {
            return new EBook { Brand = "IProne", Model = "EBook Pro" };
        }

        public Smartphone CreateSmartphone()
        {
            return new Smartphone { Brand = "IProne", Model = "IProne 15" };
        }
    }
}