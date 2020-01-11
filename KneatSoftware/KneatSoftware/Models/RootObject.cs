using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KneatSoftware.Models
{
    public class RootObject
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public object Previous { get; set; }
        public List<SwapiApiResponse> Results { get; set; }
    }
}
