using DeviceFactory.Models;

namespace DeviceFactory.Factories
{
    public interface IDeviceFactory
    {
        Laptop CreateLaptop();
        Netbook CreateNetbook();
        EBook CreateEBook();
        Smartphone CreateSmartphone();
    }
}