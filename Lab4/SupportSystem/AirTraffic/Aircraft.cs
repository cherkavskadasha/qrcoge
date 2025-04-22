using System;

namespace AirTraffic
{
    public class Aircraft : ControlTowerEntity
    {
        public string Name;

        public Aircraft(string name)
        {
            Name = name;
        }

        public void RequestLanding(Runway runway)
        {
            System.Console.WriteLine($"Літак {Name} запитує дозвіл на посадку на злітно-посадкову смугу {runway.Id}.");
            if (TrafficControl != null && TrafficControl.CanLand(this, runway))
            {
                System.Console.WriteLine($"Літак {Name} отримує дозвіл на посадку.");
                TrafficControl.NotifyLanded(this, runway);
            }
            else
            {
                System.Console.WriteLine($"Літаку {Name} відмовлено в посадці.");
            }
        }

        public void RequestTakeOff(Runway runway)
        {
            if (TrafficControl != null && runway.IsOccupiedBy(this))
            {
                System.Console.WriteLine($"Літак {Name} запитує дозвіл на зліт зі злітно-посадкової смуги {runway.Id}.");
                TrafficControl.NotifyTakingOff(this, runway);
                System.Console.WriteLine($"Літак {Name} злетів.");
            }
            else if (TrafficControl != null && !runway.IsOccupied)
            {
                System.Console.WriteLine($"Літак {Name} не може злетіти зі злітно-посадкової смуги {runway.Id}, оскільки вона вільна.");
            }
            else
            {
                System.Console.WriteLine($"Літак {Name} не може злетіти зі злітно-посадкової смуги {runway.Id}, оскільки вона зайнята іншим літаком.");
            }
        }
    }
}