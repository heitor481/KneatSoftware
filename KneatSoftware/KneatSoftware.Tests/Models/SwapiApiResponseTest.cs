using KneatSoftware.Interfaces;
using KneatSoftware.Models;
using System.Collections.Generic;
using Xunit;

namespace KneatSoftware.Tests.Models
{
    public class SwapiApiResponseTest
    {
        private readonly ISwapiApiResponse subject;

        public SwapiApiResponseTest()
        {
            this.subject = new SwapiApiResponse();
        }

        [Fact]
        public void It_Should_Return_The_Name_And_Zero_If_The_MGLT_Is_Equal_To_Unknown()
        {
            var expectedRootObject = new RootObject()
            {
                Count = 1,
                Next = "",
                Previous = "",
                Results = new List<SwapiApiResponse>()
                {
                    new SwapiApiResponse()
                    {
                        Name = "Star-Trek",
                        MGLT = "unknown",
                        Model = "Star-Ship"
                    }
                }
            };

            var mgltTyped = 200000;

            var response = this.subject.StartCalculateTotalOfStops(expectedRootObject.Results, mgltTyped);

            var expectedResponse = new Dictionary<string, int>()
            {
                { "Star-Trek", 0}
            };

            Assert.NotNull(response);
            Assert.Equal(expectedResponse, response);
        }


        [Fact]
        public void It_Should_Return_The_Name_And_Zero_If_The_Consubamles_Is_Equal_To_Unknown()
        {
            var expectedRootObject = new RootObject()
            {
                Count = 1,
                Next = "",
                Previous = "",
                Results = new List<SwapiApiResponse>()
                {
                    new SwapiApiResponse()
                    {
                        Name = "Star-Trek",
                        Consumables = "unknown",
                        Model = "Star-Ship"
                    }
                }
            };

            var mgltTyped = 200000;

            var response = this.subject.StartCalculateTotalOfStops(expectedRootObject.Results, mgltTyped);

            var expectedResponse = new Dictionary<string, int>()
            {
                { "Star-Trek", 0}
            };

            Assert.NotNull(response);
            Assert.Equal(expectedResponse, response);
        }

        [Fact]
        public void It_Should_Return_The_Collection_Of_StarShips()
        {
            var expectedRootObject = new RootObject()
            {
                Count = 1,
                Next = "",
                Previous = "",
                Results = new List<SwapiApiResponse>()
                {
                    new SwapiApiResponse()
                    {
                        Name = "Millennium Falcon",
                        Consumables = "2 months",
                        Model = "Star-Ship",
                        MGLT = "75"
                    },
                    new SwapiApiResponse()
                    {
                        Name = "Y-Wing",
                        Consumables = "1 week",
                        Model = "Star-Ship",
                        MGLT = "80"
                    }
                }
            };

            var mgltTyped = 1000000;

            var response = this.subject.StartCalculateTotalOfStops(expectedRootObject.Results, mgltTyped);

            var expectedResponse = new Dictionary<string, int>()
            {
                { "Millennium Falcon", 9},
                { "Y-Wing", 74}
            };

            Assert.NotNull(response);
            Assert.Equal(expectedResponse, response);
        }
    }
}
