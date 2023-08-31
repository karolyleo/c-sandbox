// See https://aka.ms/new-console-template for more information
using System.Text;
using System.Text.Json;
using System;
using System.Net.Http;
//using System.Text;
using System.Threading.Tasks;

namespace SerializeExtra
{
    public class WeatherForecast
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string? Summary { get; set; }
        public string? SummaryField;
        public IList<DateTimeOffset>? DatesAvailable { get; set; }
        public Dictionary<string, HighLowTemps>? TemperatureRanges { get; set; }
        public string[]? SummaryWords { get; set; }
    }

    public class HighLowTemps
    {
        public int High { get; set; }
        public int Low { get; set; }
    }

    public class Program
    {
        static async Task Main(string[] args)
        {
            string message = "{\"Hello\": \"Wanted to say Hi Victor, from a ghost... Not really, it's Leo\"}";

            string url = "https://vc0316.queue.core.windows.net/?sv=2022-11-02&ss=qt&srt=sco&sp=rwdlacup&se=2023-09-03T04:11:59Z&st=2023-08-30T20:11:59Z&spr=https&sig=LzTFUkCm%2BsjOiF7gwcjFGswM%2FbnWMyHK4BTe3PrHk%2Bg%3D";

            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(message, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Message sent successfully.");
                }
                else
                {
                    Console.WriteLine($"Error sending message: {response.ReasonPhrase}");
                }
            }
        }
        public static void Mains()
        {








            /*
            var weatherForecast = new WeatherForecast
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot",
                SummaryField = "Hot",
                DatesAvailable = new List<DateTimeOffset>()
                    { DateTime.Parse("2019-08-01"), DateTime.Parse("2019-08-02") },
                TemperatureRanges = new Dictionary<string, HighLowTemps>
                {
                    ["Cold"] = new HighLowTemps { High = 20, Low = -10 },
                    ["Hot"] = new HighLowTemps { High = 60, Low = 20 }
                },
                SummaryWords = new[] { "Cool", "Windy", "Humid" }
            };

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(weatherForecast, options);

            Console.WriteLine(jsonString);
            */
        }
    }





}
// output:
//{
//  "Date": "2019-08-01T00:00:00-07:00",
//  "TemperatureCelsius": 25,
//  "Summary": "Hot",
//  "DatesAvailable": [
//    "2019-08-01T00:00:00-07:00",
//    "2019-08-02T00:00:00-07:00"
//  ],
//  "TemperatureRanges": {
//    "Cold": {
//      "High": 20,
//      "Low": -10
//    },
//    "Hot": {
//    "High": 60,
//      "Low": 20
//    }
//  },
//  "SummaryWords": [
//    "Cool",
//    "Windy",
//    "Humid"
//  ]
//}