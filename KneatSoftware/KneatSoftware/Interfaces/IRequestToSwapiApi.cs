using KneatSoftware.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KneatSoftware.Interfaces
{
    public interface IRequestToSwapiApi
    {
        Task<RootObject> ReturnTheStarShipModels();
    }
}
