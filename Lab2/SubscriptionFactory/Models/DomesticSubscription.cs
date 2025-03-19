namespace SubscriptionFactory.Models
{
    public class DomesticSubscription : Subscription
    {
        public DomesticSubscription()
        {
            MonthlyFee = 10.00m;
            MinimumPeriod = 1;
            Channels = new List<string> { "Channel 1", "Channel 2", "Channel 3" };
            Features = new List<string> { "Standard Definition", "Basic Features" };
        }

        public override void DisplaySubscriptionDetails()
        {
            Console.WriteLine("Domestic Subscription:");
            Console.WriteLine($"Monthly Fee: {MonthlyFee}");
            Console.WriteLine($"Minimum Period: {MinimumPeriod} month(s)");
            Console.WriteLine("Channels: " + string.Join(", ", Channels));
            Console.WriteLine("Features: " + string.Join(", ", Features));
        }
    }
}