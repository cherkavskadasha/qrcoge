using System;
using SupportSystem.UserSupport;
using AirTraffic;
using SupportSystem.MementoPattern;

namespace SupportSystem
{
    class Program
    {
        static void Main(string[] args)
        {
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

            Console.WriteLine("\n--- Завдання 5: Мементо ---");
            TextEditor editor = new TextEditor();
            History history = new History();

            editor.Write("Перший рядок.");
            history.Push(editor.Save());

            editor.Write(" Другий рядок.");
            history.Push(editor.Save());

            editor.Write(" Третій рядок.");
            Console.WriteLine($"Поточний документ: \"{editor.Document.Content}\"");

            Console.WriteLine("\n--- Скасування ---");
            TextDocumentSnapshot snapshot1 = history.Pop();
            if (snapshot1 != null)
            {
                editor.Restore(snapshot1);
            }
            Console.WriteLine($"Поточний документ після скасування: \"{editor.Document.Content}\"");

            Console.WriteLine("\n--- Ще одне скасування ---");
            TextDocumentSnapshot snapshot2 = history.Pop();
            if (snapshot2 != null)
            {
                editor.Restore(snapshot2);
            }
            Console.WriteLine($"Поточний документ після ще одного скасування: \"{editor.Document.Content}\"");

            Console.WriteLine("\n--- Спроба скасувати, коли історія порожня ---");
            TextDocumentSnapshot snapshot3 = history.Pop();
            if (snapshot3 != null)
            {
                editor.Restore(snapshot3);
            }

            Console.ReadKey();
        }
    }
}