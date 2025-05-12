using System;
using SupportSystem.MementoPattern;
using SupportSystem.ObserverPattern.LightHTML;
using SupportSystem.ObserverPattern;

namespace SupportSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // --- Завдання 1: Ланцюжок відповідальностей ---
            Console.WriteLine("--- Завдання 1: Ланцюжок відповідальностей ---");
            UserSupport.SupportSystem supportSystem = new UserSupport.SupportSystem();
            while (true)
            {
                Console.WriteLine("\nСистема підтримки користувачів");
                Console.WriteLine("Оберіть рівень вашої проблеми (1-4) або 0 для виходу:");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice >= 1 && choice <= 4)
                    {
                        supportSystem.ProcessRequest(choice);
                        break;
                    }
                    else if (choice == 0)
                    {
                        Console.WriteLine("Дякуємо за звернення!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Невірний вибір. Будь ласка, введіть число від 1 до 4 або 0.");
                    }
                }
                else
                {
                    Console.WriteLine("Невірний формат вводу. Будь ласка, введіть число.");
                }
            }

            // --- Завдання 2: Посередник ---
            Console.WriteLine("\n--- Завдання 2: Посередник ---");
            AirTraffic.AirTrafficControl airTrafficControl = new AirTraffic.AirTrafficControl();
            AirTraffic.Runway runway1 = new AirTraffic.Runway();
            AirTraffic.Runway runway2 = new AirTraffic.Runway();
            airTrafficControl.RegisterRunway(runway1);
            airTrafficControl.RegisterRunway(runway2);
            AirTraffic.Aircraft aircraft1 = new AirTraffic.Aircraft("Boeing 747");
            AirTraffic.Aircraft aircraft2 = new AirTraffic.Aircraft("Airbus A320");
            AirTraffic.Aircraft aircraft3 = new AirTraffic.Aircraft("Cessna 172");
            airTrafficControl.RegisterAircraft(aircraft1);
            airTrafficControl.RegisterAircraft(aircraft2);
            airTrafficControl.RegisterAircraft(aircraft3);

            Console.WriteLine("\n--- Перша спроба посадки ---");
            aircraft1.RequestLanding(runway1);
            Console.WriteLine("\n--- Друга спроба посадки ---");
            aircraft2.RequestLanding(runway1);
            Console.WriteLine("\n--- Зліт першого літака ---");
            aircraft1.RequestTakeOff(runway1);
            Console.WriteLine("\n--- Посадка другого літака на вільну смугу ---");
            aircraft2.RequestLanding(runway1);
            Console.WriteLine("\n--- Спроба зльоту не з тієї смуги ---");
            aircraft3.RequestTakeOff(runway1);

            // --- Завдання 5: Мементо ---
            Console.WriteLine("\n--- Завдання 5: Мементо ---");
            TextEditor editor = new TextEditor();
            History history = new History();
            editor.Write("Початок документу.");
            history.Push(editor.Save());
            editor.Write(" Додано текст.");
            Console.WriteLine($"Поточний документ: \"{editor.Document.Content}\"");
            TextDocumentSnapshot snapshot1 = history.Pop();
            if (snapshot1 != null) editor.Restore(snapshot1);
            Console.WriteLine($"Документ після скасування: \"{editor.Document.Content}\"");
            TextDocumentSnapshot snapshot2 = history.Pop();
            if (snapshot2 != null) editor.Restore(snapshot2);
            Console.WriteLine($"Документ після ще одного скасування: \"{editor.Document.Content}\"");
            TextDocumentSnapshot snapshot3 = history.Pop();
            if (snapshot3 != null) editor.Restore(snapshot3);

            // --- Завдання 3: Спостерігач ---
            Console.WriteLine("\n--- Завдання 3: Спостерігач ---");
            Div divElement = new Div("Привіт!");
            Button buttonElement = new Button("Натисни мене");
            ConsoleLogger logger1 = new ConsoleLogger("Логер 1");
            ConsoleLogger logger2 = new ConsoleLogger("Логер 2");
            divElement.AddEventListener("click", logger1);
            buttonElement.AddEventListener("click", logger2);
            divElement.AddEventListener("mouseover", logger2);
            Console.WriteLine("\nІмітація кліку на DIV:");
            divElement.SimulateClick();
            Console.WriteLine("\nІмітація наведення миші на DIV:");
            divElement.SimulateMouseOver();
            Console.WriteLine("\nІмітація кліку на BUTTON:");
            buttonElement.SimulateClick();
            buttonElement.RemoveEventListener("click", logger2);
            Console.WriteLine("\nІмітація кліку на BUTTON після видалення слухача:");
            buttonElement.SimulateClick();
            Console.WriteLine("\nРендер DIV: " + divElement.Render());
            Console.WriteLine("\nРендер BUTTON: " + buttonElement.Render());

            // --- Завдання 4: Стратегія ---
            Console.WriteLine("\n--- Завдання 4: Стратегія ---");

            Image fileImage = new Image("file://my_image.png");
            Image networkImage = new Image("https://example.com/image.jpg");
            Image unknownImage = new Image("ftp://some_url");

            Console.WriteLine($"\nЗавантаження fileImage: {fileImage.LoadImage()}");
            Console.WriteLine($"Рендер fileImage: {fileImage.Render()}");

            Console.WriteLine($"\nЗавантаження networkImage: {networkImage.LoadImage()}");
            Console.WriteLine($"Рендер networkImage: {networkImage.Render()}");

            Console.WriteLine($"\nЗавантаження unknownImage: {unknownImage.LoadImage()}");
            Console.WriteLine($"Рендер unknownImage: {unknownImage.Render()}");

            Console.ReadKey();
        }
    }
}