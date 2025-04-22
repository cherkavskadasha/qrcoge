namespace AirTraffic
{
    public interface IAirTrafficControl
    {
        void RegisterAircraft(Aircraft aircraft);
        void RegisterRunway(Runway runway);
        bool CanLand(Aircraft aircraft, Runway runway);
        void NotifyLanded(Aircraft aircraft, Runway runway);
        void NotifyTakingOff(Aircraft aircraft, Runway runway);
    }
}