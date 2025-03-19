using SubscriptionFactory.Models;

namespace SubscriptionFactory.Factories
{
    public class MobileAppSubscriptionFactory : SubscriptionFactory
    {
        private string _subscriptionType;

        public MobileAppSubscriptionFactory(string subscriptionType)
        {
            _subscriptionType = subscriptionType;
        }

        public override Subscription CreateSubscription()
        {
            switch (_subscriptionType.ToLower())
            {
                case "domestic":
                    return new DomesticSubscription();
                case "educational":
                    return new EducationalSubscription();
                case "premium":
                    return new PremiumSubscription();
                default:
                    return null;
            }
        }
    }
}