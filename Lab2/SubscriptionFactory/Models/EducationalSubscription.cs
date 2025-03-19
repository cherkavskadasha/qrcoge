namespace SubscriptionFactory.Models
{
    public class EducationalSubscription : Subscription
    {
        public EducationalSubscription()
        {
            MonthlyFee = 5.00m;
            MinimumPeriod = 3;
            Channels = new List<string> { "Educational Channel 1", "Educational Channel 2" };
            Features = new List<string> { "High Definition", "Educational Content" };
        }

        public override void DisplaySubscriptionDetails()
        {
            Console.WriteLine("Educational Subscription:");
            Console.WriteLine($"Monthly Fee: {MonthlyFee}");
            Console.WriteLine($"Minimum Period: {MinimumPeriod} months");
            Console.WriteLine("Channels: " + string.Join(", ", Channels));
            Console.WriteLine("Features: " + string.Join(", ", Features));
        }
    }
}