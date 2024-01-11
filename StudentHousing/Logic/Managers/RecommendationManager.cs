using DataAcces;
using Logic.DTO;
using Logic.Entities;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Managers
{
    public class RecommendationManager
    {
        private Dictionary<string, Type> recommendationTypes;
        private readonly IRecommendation recommendation;
        private readonly IHouseRepository houseRepository;
        private readonly IRequest requestRepository;
        private int userID;

        public RecommendationManager(IHouseRepository houseRepository, IRequest requestRepository)
        {
            recommendationTypes = new Dictionary<string, Type>();
            this.houseRepository = houseRepository ?? throw new ArgumentNullException(nameof(houseRepository));
            recommendationTypes.Add("ByRequest", typeof(RecommendationByRequest));
            recommendationTypes.Add("ByChance", typeof(ReccomandationByChance));
            this.requestRepository = requestRepository ?? throw new ArgumentNullException(nameof(requestRepository));
        }

        public List<House> GetRecommendedHouses(string strategyName, List<House> houses)
        {
            IRecommendation recommendation = GetRecommendation(strategyName);
            return recommendation.GetRecommendedHouses(houses);
        }

        private IRecommendation GetRecommendation(string strategyName)
        {
            if (recommendationTypes.ContainsKey(strategyName))
            {
                Type recommendationType = recommendationTypes[strategyName];
                if (typeof(IRecommendation).IsAssignableFrom(recommendationType))
                {
                    if (strategyName == "ByRequest")
                    {
                        List<Request> requests = GetAllRequests();
                        return (IRecommendation)Activator.CreateInstance(recommendationType, requests);
                    }
                    else if (strategyName == "ByChance")
                    {
                        List<Request> requests = GetAllRequests();
                        return (IRecommendation)Activator.CreateInstance(recommendationType, requests);
                    }
                }
            }

            throw new ArgumentException("Invalid strategyName or recommendation type.");
        }

        private List<Request> GetAllRequests()
        {
            List<Request> requests = new List<Request>();

            foreach (RequestDTO r in requestRepository.GetAllRequests())
            {
                requests.Add(new Request(r));
            }

            return requests;
        }
    }
}
