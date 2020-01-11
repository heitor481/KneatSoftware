using KneatSoftware.HttpRequest;
using KneatSoftware.Models;
using Newtonsoft.Json;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace KneatSoftware
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var request = new RequestToSwapiApi();
            var requestResult = await request.ReturnTheStarShipModels();
            Console.WriteLine("Test");
            Console.ReadKey();
        }
    }
}
