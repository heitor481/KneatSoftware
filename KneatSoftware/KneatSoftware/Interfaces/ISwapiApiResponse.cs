using KneatSoftware.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KneatSoftware.Interfaces
{
    public interface ISwapiApiResponse
    {
        Dictionary<string, int> StartCalculateTotalOfStops(IList<SwapiApiResponse> swapiApiResponses, int megalightsTyped);
    }
}
