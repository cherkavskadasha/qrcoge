using DeviceFactory.Factories;
using SubscriptionFactory.Builders;
using SubscriptionFactory.Directors;
using SubscriptionFactory.Factories;
using SubscriptionFactory.Models;

namespace SubscriptionFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Factories.SubscriptionFactory webSiteFactory = new WebSiteSubscriptionFactory("premium");
            Subscription webSiteSubscription = webSiteFactory.CreateSubscription();
            webSiteSubscription?.DisplaySubscriptionDetails();

            Console.WriteLine();

            Factories.SubscriptionFactory mobileAppFactory = new MobileAppSubscriptionFactory("educational");
            Subscription mobileAppSubscription = mobileAppFactory.CreateSubscription();
            mobileAppSubscription?.DisplaySubscriptionDetails();

            Console.WriteLine();

            Factories.SubscriptionFactory managerCallFactory = new ManagerCallSubscriptionFactory("domestic");
            Subscription managerCallSubscription = managerCallFactory.CreateSubscription();
            managerCallSubscription?.DisplaySubscriptionDetails();
            
            IDeviceFactory iproneFactory = new IProneFactory();
            var iproneLaptop = iproneFactory.CreateLaptop();
            Console.WriteLine(iproneLaptop);

            IDeviceFactory kiaomiFactory = new KiaomiFactory();
            var kiaomiSmartphone = kiaomiFactory.CreateSmartphone();
            Console.WriteLine(kiaomiSmartphone);
            
            Authenticator authenticator1 = Authenticator.Instance;
            Authenticator authenticator2 = Authenticator.Instance;

            Console.WriteLine($"authenticator1 == authenticator2: {authenticator1 == authenticator2}");

            authenticator1.Authenticate("user1", "password1");
            authenticator2.Authenticate("user2", "password2");

            Virus parentVirus = new Virus("VirusA", "SpeciesX", 1.5, 5);
            Virus childVirus1 = new Virus("VirusB", "SpeciesX", 0.5, 2);
            Virus childVirus2 = new Virus("VirusC", "SpeciesX", 0.3, 1);
            Virus grandchildVirus = new Virus("VirusD", "SpeciesX", 0.1, 0);

            parentVirus.Children.Add(childVirus1);
            parentVirus.Children.Add(childVirus2);
            childVirus1.Children.Add(grandchildVirus);

            Virus clonedParentVirus = (Virus)parentVirus.Clone();

            Console.WriteLine("Original Virus:");
            parentVirus.DisplayVirusInfo();

            Console.WriteLine("\nCloned Virus:");
            clonedParentVirus.DisplayVirusInfo();

            CharacterDirector director = new CharacterDirector();
            HeroBuilder heroBuilder = new HeroBuilder();
            EnemyBuilder enemyBuilder = new EnemyBuilder();

            Character hero = director.ConstructHero(heroBuilder);
            Character enemy = director.ConstructEnemy(enemyBuilder);

            Console.WriteLine("Hero:\n" + hero);
            Console.WriteLine("\nEnemy:\n" + enemy);

            Console.ReadKey();
        }
    }
}