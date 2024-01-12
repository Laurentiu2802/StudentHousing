using DataAcces;
using Logic.DTO;
using Logic.Entities;
using Logic.Interfaces;
using Logic.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class AlgorithmTests
    {
        byte[] testImage;
        [TestMethod]
        public void AddHouse_ShoulReturnTrue()
        {
            bool success;
            IHouseRepository houseRepository = new MockAlgorithmRepository();
            HouseManager houseManager = new HouseManager(houseRepository);
            HouseDTO newHouse = new HouseDTO();
            newHouse.HouseID = 1;
            newHouse.Address = "Address";
            newHouse.HouseNumber = 1;
            newHouse.City = "City";
            newHouse.HouseType = 0;
            newHouse.Space = 100;
            newHouse.Furnished = true;
            newHouse.ContractType = 0;
            newHouse.Rent = 500;
            newHouse.Deposit = 100;
            newHouse.HousePhoto = testImage;
            newHouse.Status = true;

            if (houseManager.AddHouse(newHouse) == true)
            {
                success = true;
            }
            else
            {
                success = false;
            }
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void GetHouses_ShouldReturnTrue()
        {
            IHouseRepository houseRepository = new MockAlgorithmRepository();
            HouseManager houseManager = new HouseManager(houseRepository);
            bool success;
            if (houseManager.GetAllHouses().Count >= 0)
            {
                success = true;
            }
            else
            {
                success = false;
            }
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void GetHouseById_ShouldReturnHouse()
        {
            IHouseRepository houseRepository = new MockAlgorithmRepository();
            HouseManager houseManager = new HouseManager(houseRepository);
            bool success;
            int id = 1;
            if (houseManager.GetHouseByID(id) != null)
            {
                success = true;
            }
            else
            {
                success = false;
            }
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void GetHouseById_ShouldReturnNull()
        {
            IHouseRepository houseRepository = new MockAlgorithmRepository();
            HouseManager houseManager = new HouseManager(houseRepository);
            int id = 4;
            Assert.ThrowsException<NullReferenceException>(() => houseManager.GetHouseByID(id));
        }

        [TestMethod]
        public void GetRequests_ShouldReturnTrue()
        {
            IRequest requestRepository = new MockAlgorithmRepository();
            RequestManager requestManager = new RequestManager(requestRepository);
            bool success;
            if (requestManager.GetAllRequests().Count >= 0)
            {
                success = true;
            }
            else
            {
                success = false;
            }
            Assert.IsTrue(success);
        }

        public List<House> GetAllHouses()
        {
            IHouseRepository houseRepository = new MockAlgorithmRepository();
            HouseManager houseManager = new HouseManager(houseRepository);
            List<House> houses = new List<House>();

            foreach (HouseDTO h in houseRepository.GetAllHouses())
            {
                houses.Add(new House(h));
            }

            return houses;
        }

        [TestMethod]
        public void GetRecommendedHousesByChance_ShouldReturnHouses()
        {
            IHouseRepository houseRepository = new MockAlgorithmRepository();
            IRequest request = new MockAlgorithmRepository();
            RecommendationManager recommendationManager = new RecommendationManager(houseRepository, request);
            List<House> houses = GetAllHouses();

            var output = recommendationManager.GetRecommendedHouses("ByChance", houses);

            Assert.AreEqual(3, output.Count);
            CollectionAssert.Contains(output, houses[0]);
            CollectionAssert.Contains(output, houses[1]);
        }

        [TestMethod]
        public void GetRecommendedHousesByRequest_ShouldReturnHouses()
        {
            IHouseRepository houseRepository = new MockAlgorithmRepository();
            IRequest request = new MockAlgorithmRepository();
            RecommendationManager recommendationManager = new RecommendationManager(houseRepository, request);
            List<House> houses = GetAllHouses();

            var output = recommendationManager.GetRecommendedHouses("ByRequest", houses);

            Assert.AreEqual(3, output.Count);
            Assert.AreEqual(houses[0], output[0]);
            Assert.AreEqual(houses[1], output[1]);
        }
    }
}
