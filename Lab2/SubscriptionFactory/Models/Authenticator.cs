namespace SubscriptionFactory.Models
{
    public sealed class Authenticator
    {
        private static Authenticator instance = null;
        private static readonly object padlock = new object();

        private Authenticator()
        {
        }

        public static Authenticator Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new Authenticator();
                        }
                    }
                }
                return instance;
            }
        }

        public void Authenticate(string username, string password)
        {
            Console.WriteLine($"Authenticating user: {username}");
        }
    }
}