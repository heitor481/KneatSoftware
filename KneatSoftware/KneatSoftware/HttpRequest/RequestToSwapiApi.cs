using KneatSoftware.Interfaces;
using KneatSoftware.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace KneatSoftware.HttpRequest
{
    public class RequestToSwapiApi : IRequestToSwapiApi
    {
        private string Json;

        private string ApiURL
        {
            get
            {
                return "https://swapi.co/api/starships/";
            }
        }

        public async Task<RootObject> ReturnTheStarShipModels()
        {
            var request = new HttpClient();
            this.Json = await request.GetStringAsync(this.ApiURL);
            var rootObject = JsonConvert.DeserializeObject<RootObject>(this.Json);

            // I´m doing that while because the results comming from the API are paged, so I need to catch the next URL to grab the next starships
            while (rootObject.Next != null)
            {
                this.Json = await request.GetStringAsync(rootObject.Next);
                var newDeserializeObject = JsonConvert.DeserializeObject<RootObject>(this.Json);
                if (newDeserializeObject.Results != null)
                {
                    rootObject.Results.AddRange(newDeserializeObject.Results);
                }

                rootObject.Next = newDeserializeObject.Next;
            }

            return rootObject;
        }
    }
}
