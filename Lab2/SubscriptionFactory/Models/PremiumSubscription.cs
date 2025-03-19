namespace SubscriptionFactory.Models
{
    public class PremiumSubscription : Subscription
    {
        public PremiumSubscription()
        {
            MonthlyFee = 20.00m;
            MinimumPeriod = 12;
            Channels = new List<string> { "All Channels" };
            Features = new List<string> { "4K Ultra HD", "Premium Features", "On-Demand Content" };
        }

        public override void DisplaySubscriptionDetails()
        {
            Console.WriteLine("Premium Subscription:");
            Console.WriteLine($"Monthly Fee: {MonthlyFee}");
            Console.WriteLine($"Minimum Period: {MinimumPeriod} months");
            Console.WriteLine("Channels: " + string.Join(", ", Channels));
            Console.WriteLine("Features: " + string.Join(", ", Features));
        }
    }
}