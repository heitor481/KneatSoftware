using KneatSoftware.HttpRequest;
using System;
using System.Threading.Tasks;

namespace KneatSoftware
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var request = new RequestToSwapiApi();
            var requestResult = await request.ReturnTheStarShipModels();
            Console.WriteLine(requestResult);
            Console.ReadKey();
        }
    }
}
