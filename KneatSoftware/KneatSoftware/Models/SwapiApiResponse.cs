using KneatSoftware.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KneatSoftware.Models
{
    public class SwapiApiResponse : ISwapiApiResponse
    {
        private readonly double HoursPerDay = 24;
        private readonly double HoursPerWeek = 168;
        private readonly double HoursPerMonth = 730.001;
        private readonly double HoursPerYear = 8760;
        private double HoursCalculated = 0;

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

        public void StartCalculateTotalOfStops(IList<SwapiApiResponse> swapiApiResponses, int megalightsTyped)
        {
            for (int i = 0; i <= swapiApiResponses.Count; i++)
            {
                if (swapiApiResponses[i].MGLT == "unknown" | swapiApiResponses[i].Consumables == "unknown")
                {
                }

                var mglt = Convert.ToInt32(swapiApiResponses[i].MGLT);
                var consumables = swapiApiResponses[i].Consumables;
                double hoursCalculated = CalculateTotalOfHours(consumables);
                int stops = CalculateTotalOfStops(hoursCalculated, mglt, megalightsTyped);
            }
        }

        public int CalculateTotalOfStops(double hours, int mglt, int megalightsTyped)
        {
            int totalOfStopsForResupply = 0;
            double calc = mglt * hours;

            while (calc <= megalightsTyped)
            {
                calc += mglt * hours;
                totalOfStopsForResupply += 1;
            }

            return totalOfStopsForResupply;
        }

        public double CalculateTotalOfHours(string consumables)
        {
            var test = consumables.Length - 1;

            var consumablesInt = Convert.ToInt32(consumables.Remove(1, test));

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
