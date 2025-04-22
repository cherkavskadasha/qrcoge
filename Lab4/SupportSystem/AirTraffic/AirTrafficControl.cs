using System.Collections.Generic;

namespace AirTraffic
{
    public class AirTrafficControl : IAirTrafficControl
    {
        private List<Runway> _runways = new List<Runway>();
        private List<Aircraft> _aircrafts = new List<Aircraft>();

        public void RegisterAircraft(Aircraft aircraft)
        {
            if (!_aircrafts.Contains(aircraft))
            {
                _aircrafts.Add(aircraft);
                aircraft.SetTrafficControl(this);
            }
        }

        public void RegisterRunway(Runway runway)
        {
            if (!_runways.Contains(runway))
            {
                _runways.Add(runway);
                runway.SetTrafficControl(this);
            }
        }

        public bool CanLand(Aircraft aircraft, Runway runway)
        {
            if (runway.IsOccupied)
            {
                System.Console.WriteLine($"Посередник: Злітно-посадкова смуга {runway.Id} зайнята. Літак {aircraft.Name} не може приземлитися.");
                return false;
            }
            System.Console.WriteLine($"Посередник: Злітно-посадкова смуга {runway.Id} вільна. Дозвіл на посадку для літака {aircraft.Name}.");
            return true;
        }

        public void NotifyLanded(Aircraft aircraft, Runway runway)
        {
            System.Console.WriteLine($"Посередник: Літак {aircraft.Name} успішно приземлився на злітно-посадкову смугу {runway.Id}.");
            runway.Occupy(aircraft);
        }

        public void NotifyTakingOff(Aircraft aircraft, Runway runway)
        {
            System.Console.WriteLine($"Посередник: Літак {aircraft.Name} злітає зі злітно-посадкової смуги {runway.Id}.");
            runway.Free();
        }
    }
}