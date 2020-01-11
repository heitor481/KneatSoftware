using KneatSoftware.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace KneatSoftware.HttpRequest
{
    public class RequestToSwapiApi : IRequestToSwapiApi
    {
        public string ApiURL
        {
            get
            {
                return "https://swapi.co/api/starships/";
            }
        }

        public async Task<object> ReturnTheStarShipModels()
        {
            var request = new HttpClient();
            return await request.GetStringAsync(this.ApiURL);
        }
    }
}
