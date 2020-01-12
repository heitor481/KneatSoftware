using KneatSoftware.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KneatSoftware.Interfaces
{
    public interface ISwapiApiResponse
    {
        void StartCalculateTotalOfStops(IList<SwapiApiResponse> swapiApiResponses, int megalightsTyped);
    }
}
