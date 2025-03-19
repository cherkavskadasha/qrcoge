namespace SubscriptionFactory.Models
{
    public abstract class Subscription
    {
        public decimal MonthlyFee { get; protected set; }
        public int MinimumPeriod { get; protected set; }
        public List<string> Channels { get; protected set; }
        public List<string> Features { get; protected set; }

        public abstract void DisplaySubscriptionDetails();
    }
}