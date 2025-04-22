using System;

namespace AirTraffic
{
    public class Runway : ControlTowerEntity
    {
        public Guid Id { get; } = Guid.NewGuid();
        public Aircraft? OccupiedByAircraft { get; private set; }
        public bool IsOccupied => OccupiedByAircraft != null;

        public void Occupy(Aircraft aircraft)
        {
            OccupiedByAircraft = aircraft;
            HighlightRed();
        }

        public void Free()
        {
            OccupiedByAircraft = null;
            HighlightGreen();
        }

        public bool IsOccupiedBy(Aircraft aircraft)
        {
            return OccupiedByAircraft == aircraft;
        }

        public void HighlightRed()
        {
            System.Console.WriteLine($"Злітно-посадкова смуга {Id} ЗАЙНЯТА!");
        }

        public void HighlightGreen()
        {
            System.Console.WriteLine($"Злітно-посадкова смуга {Id} ВІЛЬНА!");
        }
    }
}