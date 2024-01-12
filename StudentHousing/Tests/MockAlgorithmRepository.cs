using DataAcces;
using Logic.DTO;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class MockAlgorithmRepository : IHouseRepository, IRequest
    {
        HouseDTO house = new HouseDTO();
        RequestDTO requestDTO = new RequestDTO();
        List<HouseDTO> houses;
        List<RequestDTO> requests;
        byte[] testImage;

        bool IHouseRepository.AddHouse(HouseDTO houseDTO)
        {
            houses = new List<HouseDTO>
            {
                houseDTO
            };
            if (houses.Count > 0)
            {
                return true;
            }
            return false;
        }

        bool IRequest.AddRequest(RequestDTO requestDTO)
        {
            throw new NotImplementedException();
        }

        List<HouseDTO> IHouseRepository.GetAllHouses()
        {
            houses = new List<HouseDTO>
            {
               new HouseDTO
                {
                    HouseID = 1,
                    Address = "Address",
                    HouseNumber = 1,
                    City = "City",
                    HouseType = 0,
                    Space = 100,
                    Furnished = true,
                    ContractType = 0,
                    Rent = 500,
                    Deposit = 100,
                    HousePhoto = testImage,
                    Status = true
               },
               new HouseDTO
                {
                    HouseID = 2,
                    Address = "Address",
                    HouseNumber = 1,
                    City = "City",
                    HouseType = 0,
                    Space = 100,
                    Furnished = true,
                    ContractType = 0,
                    Rent = 500,
                    Deposit = 100,
                    HousePhoto = testImage,
                    Status = true
                },
               new HouseDTO
                {
                    HouseID = 3,
                    Address = "Address",
                    HouseNumber = 1,
                    City = "City",
                    HouseType = 0,
                    Space = 100,
                    Furnished = true,
                    ContractType = 0,
                    Rent = 500,
                    Deposit = 100,
                    HousePhoto = testImage,
                    Status = true
                }
            };
            return houses;
        }

        List<HouseDTO> IHouseRepository.GetAllHousesByStatusAndType(bool Status, int HouseType)
        {
            throw new NotImplementedException();
        }

        List<RequestDTO> IRequest.GetAllRequests()
        {
            requests = new List<RequestDTO>
            {
               new RequestDTO
                {
                    CustomerDTO = new CustomerDTO
                    {
                        PersonID = 1,
                        Email = "test@email.com",
                        Password = "12345",
                        IsEmployee = false,
                        Username = "username",
                        FirstName = "John",
                        LastName = "Doe",
                        Address = "Address",
                        City = "City",
                        Country = "Country"
                    },
                    HouseDTO = new HouseDTO
                    {
                        HouseID = 1,
                        Address = "Address",
                        HouseNumber = 1,
                        City = "City",
                        HouseType = 0,
                        Space = 100,
                        Furnished = true,
                        ContractType = 0,
                        Rent = 500,
                        Deposit = 100,
                        HousePhoto = testImage,
                        Status = true
                    },
                    Status = 0
                }
            };
            return requests;
        }

        HouseDTO IHouseRepository.GetHouseByID(int id)
        {
            houses = new List<HouseDTO>
            {
               new HouseDTO
                {
                    HouseID = 1,
                    Address = "Address",
                    HouseNumber = 1,
                    City = "City",
                    HouseType = 0,
                    Space = 100,
                    Furnished = true,
                    ContractType = 0,
                    Rent = 500,
                    Deposit = 100,
                    HousePhoto = testImage,
                    Status = true
               },
               new HouseDTO
                {
                    HouseID = 2,
                    Address = "Address",
                    HouseNumber = 1,
                    City = "City",
                    HouseType = 0,
                    Space = 100,
                    Furnished = true,
                    ContractType = 0,
                    Rent = 500,
                    Deposit = 100,
                    HousePhoto = testImage,
                    Status = true
                },
               new HouseDTO
                {
                    HouseID = 3,
                    Address = "Address",
                    HouseNumber = 1,
                    City = "City",
                    HouseType = 0,
                    Space = 100,
                    Furnished = true,
                    ContractType = 0,
                    Rent = 500,
                    Deposit = 100,
                    HousePhoto = testImage,
                    Status = true
                }
            };
            foreach (HouseDTO h in houses)
            {
                if (h.HouseID == id)
                {
                    return h;
                }
            }
            return null;
        }

        List<RequestDTO> IRequest.GetRequestsByCustomerID(int id)
        {
            throw new NotImplementedException();
        }

        List<RequestDTO> IRequest.GetRequestsByHouseID(int id)
        {
            throw new NotImplementedException();
        }

        bool IHouseRepository.UpdateHouse(HouseDTO houseDTO)
        {
            throw new NotImplementedException();
        }

        bool IRequest.UpdateRequest(RequestDTO requestDTO)
        {
            throw new NotImplementedException();
        }
    }
}
