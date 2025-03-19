using SubscriptionFactory.Models;

namespace SubscriptionFactory.Factories
{
    public abstract class SubscriptionFactory
    {
        public abstract Subscription CreateSubscription();
    }
}