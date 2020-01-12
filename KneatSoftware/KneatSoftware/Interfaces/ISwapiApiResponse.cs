using KneatSoftware.Models;
using System.Collections.Generic;

namespace KneatSoftware.Interfaces
{
    public interface ISwapiApiResponse
    {
        Dictionary<string, int> StartCalculateTotalOfStops(IList<SwapiApiResponse> swapiApiResponses, double megalightsTyped);
    }
}
