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
            var valuePassed = Console.ReadLine();
            var convertedValuePassed = Convert.ToInt32(valuePassed);
            var request = new RequestToSwapiApi();
            var requestResult = await request.ReturnTheStarShipModels();
            var swap = new SwapiApiResponse();
            swap.StartCalculateTotalOfStops(requestResult.Results, convertedValuePassed);

            Console.WriteLine("Test");
            Console.ReadKey();
        }
    }
}
