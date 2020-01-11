using System.Collections.Generic;

namespace KneatSoftware.Models
{
    public class RootObject
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public object Previous { get; set; }
        public ICollection<SwapiApiResponse> Results { get; set; }
    }
}
