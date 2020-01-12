using KneatSoftware.HttpRequest;
using KneatSoftware.Models;
using System;
using System.Threading.Tasks;

namespace KneatSoftware
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Enter the total of Megalights: ");
            var valueTyped = Console.ReadLine();
            double valueConverted;
            var value = double.TryParse(valueTyped, out valueConverted);

            if (value)
            {
                var convertedValuePassed = Convert.ToDouble(valueConverted);
                var request = new RequestToSwapiApi();
                var requestResult = await request.ReturnTheStarShipModels();
                var swap = new SwapiApiResponse();
                var calculeDone = swap.StartCalculateTotalOfStops(requestResult.Results, convertedValuePassed);

                foreach (var test in calculeDone)
                {
                    Console.WriteLine($"{test.Key}: {test.Value}");
                }


                Console.ReadKey();
            }
            
        }
    }
}
