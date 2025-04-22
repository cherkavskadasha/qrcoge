namespace AirTraffic
{
    public abstract class ControlTowerEntity
    {
        protected IAirTrafficControl? TrafficControl;

        public void SetTrafficControl(IAirTrafficControl trafficControl)
        {
            TrafficControl = trafficControl;
        }
    }
}