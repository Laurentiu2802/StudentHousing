using Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Enums;

namespace Logic.Entities
{
    public class House
    {
        private int houseID;
        private int houseNumber;
        private string address;
        private string city;
        private HouseType houseType;
        private int space;
        private bool furnished;
        private ContractType contractType;
        private double rent;
        private double deposit;
        private byte[] housePhoto;
        private bool status;

        public int HouseID { get => houseID; set => houseID = value; }

        public int HouseNumber { get => houseNumber; set => houseNumber = value; }
        public string Address { get => address; set => address = value; }
        public string City { get => city; set => city = value; }
        public HouseType HouseType { get => houseType; set => houseType = value; }
        public int Space { get => space; set => space = value; }
        public bool Furnished { get => furnished; set => furnished = value; }
        public ContractType ContractType { get => contractType; set => contractType = value; }
        public double Rent { get => rent; set => rent = value; }
        public double Deposit { get => deposit; set => deposit = value; }
        public byte[] HousePhoto { get => housePhoto; set => housePhoto = value; }
        public bool Status { get => status; set => status = value; }

        public House(int houseID, int houseNumber, string address, string city, HouseType houseType, int space, bool furnished, ContractType contractType, int rent, int deposit, byte[] housePhoto, bool status)
        {
            this.houseID = houseID;
            this.houseNumber = houseNumber;
            this.address = address;
            this.city = city;
            this.houseType = houseType;
            this.space = space;
            this.furnished = furnished;
            this.contractType = contractType;
            this.rent = rent;
            this.deposit = deposit;
            this.HousePhoto = housePhoto;
            this.Status = status;
            
        }
        public House(int houseNumber, string address, string city, HouseType houseType, int space, bool furnished, ContractType contractType, int rent, int deposit, byte[] housePhoto, bool status)
        {
            this.houseNumber = houseNumber;
            this.address = address;
            this.city = city;
            this.houseType = houseType;
            this.space = space;
            this.furnished = furnished;
            this.contractType = contractType;
            this.rent = rent;
            this.deposit = deposit;
            this.HousePhoto = housePhoto;
            this.Status = status;
        }
        public House(HouseDTO houseDTO)
        {
            this.HouseID = houseDTO.HouseID;
            this.HouseNumber = houseDTO.HouseNumber;
            this.address = houseDTO.Address;
            this.city = houseDTO.City;
            this.houseType = (HouseType)houseDTO.HouseType;
            this.space = houseDTO.Space;
            this.furnished = houseDTO.Furnished;
            this.contractType = (ContractType)houseDTO.ContractType;
            this.rent = houseDTO.Rent;
            this.deposit = houseDTO.Deposit;
            this.housePhoto = houseDTO.HousePhoto;
            this.status = houseDTO.Status;
        }
        public HouseDTO HouseToHouseDTO()
        {
            return new HouseDTO()
            {
                HouseID = this.HouseID,
                HouseNumber = this.HouseNumber,
                Address = this.Address,
                City = this.City,
                HouseType = Convert.ToInt32(this.HouseType),
                Space = this.Space,
                Furnished = this.Furnished,
                ContractType = Convert.ToInt32(this.ContractType),
                Rent = this.rent,
                Deposit = this.deposit,
                HousePhoto = this.housePhoto,
                Status = this.status,
            };
        }

        public override string ToString()
        {
            return $"{address} {houseNumber}";
        }
    }
}
