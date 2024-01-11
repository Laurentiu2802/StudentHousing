using Logic.Enums;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public class RecommendationByRequest : IRecommendation
    {
        //List<Request> requestList;
        //public RecommendationByRequest(List<Request> requestList)
        //{
        //    this.requestList = requestList;
        //}

        //public List<House> GetRecommendedHouses(List<House> houses)
        //{
        //    Dictionary<HouseType, int> houseTypeCount = new Dictionary<HouseType, int>();
        //    foreach(Request request in requestList)
        //    {
        //        HouseType houseType = request.House.HouseType;

        //        if(houseTypeCount.ContainsKey(houseType))
        //        {
        //            houseTypeCount[houseType]++;
        //        }
        //        else
        //        {
        //            houseTypeCount[houseType] = 1;
        //        }
        //    }
        //    List<HouseType>
        //    return null;
        //}

        private List<Request> requests;

        public RecommendationByRequest(List<Request> requests)
        {
            this.requests = requests;
        }

        public List<House> GetRecommendedHouses(List<House> houses)
        {
            Dictionary<HouseType, int> houseTypeCounts = new Dictionary<HouseType, int>();

            foreach (Request request in requests)
            {
                HouseType houseType = request.House.HouseType;

                if (houseTypeCounts.ContainsKey(houseType))
                {
                    houseTypeCounts[houseType]++;
                }
                else
                {
                    houseTypeCounts[houseType] = 1;
                }
            }

            List<HouseType> topHouseTypes = houseTypeCounts.OrderByDescending(pair => pair.Value)
                                                          .Take(3)
                                                          .Select(pair => pair.Key)
                                                          .ToList();

            List<House> recommendedHouses = new List<House>();

            foreach (House house in houses)
            {
                if (topHouseTypes.Contains(house.HouseType))
                {
                    recommendedHouses.Add(house);
                }
            }

            return recommendedHouses;
        }
    }
}
