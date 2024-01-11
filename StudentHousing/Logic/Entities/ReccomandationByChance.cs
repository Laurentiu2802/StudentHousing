using Logic.Enums;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public class ReccomandationByChance : IRecommendation
    {
        private List<Request> requests;

        public ReccomandationByChance(List<Request> requests)
        {
            this.requests = requests;
        }

        public List<House> GetRecommendedHouses(List<House> allHouses)
        {
            Dictionary<House, int> houseRequestCounts = new Dictionary<House, int>();

            foreach (House house in allHouses)
            {
                // Retrieve all requests for the current house
                List<Request> houseRequests = requests.Where(request => request.House.HouseID.Equals(house.HouseID)).ToList();

                // Count the requests for the current house
                int requestCount = houseRequests.Count;

                // Add the house and its request count to the dictionary
                houseRequestCounts[house] = requestCount;
            }

            // Order houses by the number of requests in ascending order
            List<House> recommendedHouses = houseRequestCounts.OrderBy(pair => pair.Value)
                                                              .Select(pair => pair.Key)
                                                              .ToList();

            return recommendedHouses;
        }
    }
}