using DataAcces;
using Logic.DTO;
using Logic.Entities;
using Logic.Exceptions;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Managers
{
    public class HouseManager
    {
        private readonly IHouseRepository houseRepository;

        public HouseManager(IHouseRepository houseRepository)
        {
            this.houseRepository = houseRepository ?? throw new ArgumentNullException(nameof(houseRepository));
        }


        public List<ValidationResult> TryToAddHouse(HouseDTO houseDTO)
        {
            List<ValidationResult> validationResults = new List<ValidationResult>();
            if (Validator.TryValidateObject(houseDTO, new ValidationContext(houseDTO), validationResults, true))
            {
                houseRepository.AddHouse(houseDTO);
            }
            return validationResults;
        }
        public bool AddHouse(HouseDTO houseDTO)
        {
            return houseRepository.AddHouse(houseDTO);
        }

        public House GetHouseByID(int id)
        {
            try
            {
                return new House(houseRepository.GetHouseByID(id));
            }
            catch (CustomerExceptions ec)
            {
                throw new NotImplementedException();
            }
        }

        public List<House> GetAllHouses()
        {
            List<House> houses = new List<House>();
            foreach (HouseDTO houseDTO in houseRepository.GetAllHouses())
            {
                houses.Add(new House(houseDTO));
            }
            return houses;
        }

        public List<House> GetAllHousesByStatusAndType(bool Status, int HouseType)
        {
            List<House> houses = new List<House>();
            foreach(HouseDTO houseDTO in houseRepository.GetAllHousesByStatusAndType(Status, HouseType))
            {
                houses.Add(new House(houseDTO));
            }
            return houses;
        }

        public bool UpdateHouse(HouseDTO houseDTO)
        {
            return houseRepository.UpdateHouse(houseDTO);
        }
    }
}
