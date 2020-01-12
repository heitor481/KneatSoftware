using KneatSoftware.Interfaces;
using System;
using System.Collections.Generic;

namespace KneatSoftware.Models
{
    public class SwapiApiResponse : ISwapiApiResponse
    {
        /*
         * I´m putting the hours here based on the results that I´m getting from the API response
         * So it has the total hours per day, per week, per month, and per year
         * With that, I can create the calculous to discover how many stops was done to reach the MGLT passed as input
         */

        private readonly double HoursPerDay = 24;
        private readonly double HoursPerWeek = 168;
        private readonly double HoursPerMonth = 730.001;
        private readonly double HoursPerYear = 8760;
        private double HoursCalculated = 0;
        private readonly Dictionary<string, int> CollectionOfStarShipsWithStops = new Dictionary<string, int>();

        public SwapiApiResponse()
        {

        }

        public string Name { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string CostInCredits { get; set; }
        public string Length { get; set; }
        public string MaxAtmospheringSpeed { get; set; }
        public string Crew { get; set; }
        public string Passenger { get; set; }
        public string CargoCapacity { get; set; }
        public string Consumables { get; set; }
        public string HyperdriveRating { get; set; }
        public string MGLT { get; set; }
        public string StarshipClass { get; set; }
        public ICollection<object> Pilots { get; set; }
        public ICollection<string> Films { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public string Url { get; set; }

        public Dictionary<string, int> StartCalculateTotalOfStops(IList<SwapiApiResponse> swapiApiResponses, double megalightsTyped)
        {
            for (int i = 0; i <= swapiApiResponses.Count -1; i++)
            {
                // If I don´t have the MGLT or the Consumables, I will assume that the total o stops will be 0
                if (swapiApiResponses[i].MGLT == "unknown" | swapiApiResponses[i].Consumables == "unknown")
                {
                    this.CollectionOfStarShipsWithStops.Add(swapiApiResponses[i].Name, 0);
                    continue;
                }

                var mglt = Convert.ToInt32(swapiApiResponses[i].MGLT);
                var consumables = swapiApiResponses[i].Consumables;
                double hoursCalculated = CalculateTotalOfHours(consumables);
                int stops = CalculateTotalOfStops(hoursCalculated, mglt, megalightsTyped);
                this.CollectionOfStarShipsWithStops.Add(swapiApiResponses[i].Name, stops);
            }

            return this.CollectionOfStarShipsWithStops;
        }

        public int CalculateTotalOfStops(double hours, int mglt, double megalightsTyped)
        {
            int totalStopsForResupply = 0;
            double calc = mglt * hours;

            while (calc <= megalightsTyped)
            {
                calc += mglt * hours;
                totalStopsForResupply += 1;
            }

            return totalStopsForResupply;
        }

        public double CalculateTotalOfHours(string consumables)
        {
            var consumablesInt = Convert.ToInt32(consumables.Remove(1, consumables.Length - 1));

            if (consumables.Contains("day"))
            {
                this.HoursCalculated = consumablesInt * this.HoursPerDay;
            }

            if (consumables.Contains("week"))
            {
                this.HoursCalculated = consumablesInt * this.HoursPerWeek;
            }

            if (consumables.Contains("month"))
            {
                this.HoursCalculated = consumablesInt * this.HoursPerMonth;
            }

            if (consumables.Contains("year"))
            {
                this.HoursCalculated = consumablesInt * this.HoursPerYear;
            }

            return this.HoursCalculated;
        }
    }
}
