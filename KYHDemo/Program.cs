using System;
using System.Threading.Tasks;
using System.Threading;

namespace KYHDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== KYH Bilprojekt ===");
                Console.WriteLine("1. Starta bilsimulator");
                Console.WriteLine("2. Kör analys");
                Console.WriteLine("0. Avsluta");
                Console.Write("\nVälj (0–2): ");

                var val = Console.ReadLine();

                if (val == "1")
                {
                    await StartSimulator();
                }
                else if (val == "2")
                {
                    await AnalysisProgram.RunAnalysisAsync();
                    Console.WriteLine("\nTryck på valfri tangent för att återgå till menyn...");
                    Console.ReadKey();
                }
                else if (val == "0")
                {
                    Console.WriteLine("Avslutar...");
                    break;
                }
                else
                {
                    Console.WriteLine("Felaktigt val. Tryck på valfri tangent för att försöka igen.");
                    Console.ReadKey();
                }
            }
        }

        //  Simulatorn (samma som din tidigare kod)
        static async Task StartSimulator()
        {
            Console.WriteLine("\nStartar bilsimulering med GPS och OBD-felkoder...\n");

            Random rand = new Random();
            int bränsle = 100;
            double latitude = 59.3293;
            double longitude = 18.0686;

            string[] felkoder = { "P0300", "P0420", "P0113", "P0171", "P0128" };

            for (int i = 0; i < 10; i++) // kör t.ex. 10 cykler (ändra till while(true) om du vill)
            {
                int hastighet = rand.Next(0, 140);
                int motorvärme = rand.Next(70, 100);
                int rpm = rand.Next(800, 6000);

                bränsle -= rand.Next(0, 2);
                if (bränsle < 0) bränsle = 100;

                latitude += rand.NextDouble() * 0.0005 - 0.00025;
                longitude += rand.NextDouble() * 0.0005 - 0.00025;

                string felkod = rand.Next(0, 10) == 0 ? felkoder[rand.Next(felkoder.Length)] : "";

                var sensordata = new SensorData(hastighet, bränsle, motorvärme, rpm, latitude, longitude, felkod);
                await SendDataService.SendDataAsync(sensordata);

                Thread.Sleep(4500);
            }

            Console.WriteLine("\nSimuleringen avslutad. Tryck på valfri tangent för att återgå till menyn...");
            Console.ReadKey();
        }
    }
}
