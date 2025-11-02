using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace KYHDemo
{
    internal class Thinkspeak
    {
        private static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://api.thingspeak.com")
        };

        private const string ApiKey = "5Y1SA56YQIH8DHYF";

        internal async Task SendDataAsync(SensorData data)
        {
            try
            {
                
                string url = $"/update?api_key={ApiKey}" +
                             $"&field1={data.Hastighet}" +
                             $"&field2={data.Bränsle}" +
                             $"&field3={data.Motorvärme}" +
                             $"&field4={data.RPM}" +
                             $"&field5={data.Felkod}" +
                             $"&field6={data.Latitude}" +
                             $"&field7={data.Longitude}";

                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Data skickad [{DateTime.Now:T}] " +
                                      $"Hast={data.Hastighet} km/h, RPM={data.RPM}, GPS=({data.Latitude:F4},{data.Longitude:F4})" +
                                      (string.IsNullOrEmpty(data.Felkod) ? "" : $" Felkod: {data.Felkod}"));
                }
                else
                {
                    Console.WriteLine($" Misslyckades: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Nätverksfel: {ex.Message}");
            }
        }
    }
}
