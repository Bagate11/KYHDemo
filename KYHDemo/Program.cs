namespace KYHDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Startar bilsimulering med GPS och OBD-felkoder...\n");

            Random rand = new Random();
            int bränsle = 100;
            double latitude = 59.3293;  
            double longitude = 18.0686;

            string[] felkoder = new string[]
            {
                "P0300", // slumpmässigt misständning
                "P0420", // katalysatoreffektivitet låg
                "P0113", // luftintagstemp-sensor hög signal
                "P0171", // magert bränsleblandning
                "P0128"  // kylsystem ej i rätt temp
            };

            while (true)
            {
                int hastighet = rand.Next(0, 140);
                int motorvärme = rand.Next(70, 100);
                int rpm = rand.Next(800, 6000);

                // Enkel bränsleminskning
                bränsle -= rand.Next(0, 2);
                if (bränsle < 0) bränsle = 100;

                
                latitude += rand.NextDouble() * 0.0005 - 0.00025;
                longitude += rand.NextDouble() * 0.0005 - 0.00025;

                
                string felkod = rand.Next(0, 10) == 0 ? felkoder[rand.Next(felkoder.Length)] : "";

                var sensordata = new SensorData(hastighet, bränsle, motorvärme, rpm, latitude, longitude, felkod);
                await SendDataService.SendDataAsync(sensordata);

                Thread.Sleep(1500);
            }
        }
    }
}