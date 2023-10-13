﻿using Logic.DTO;
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
        private string houseType;
        private int space;
        private bool furnished;
        private string contractType;
        private double rent;
        private double deposit;
        private byte[] housePhoto;

        public int HouseID { get => houseID; set => houseID = value; }
        public int HouseNumber { get => houseNumber; set => houseNumber = value; }
        public string Address { get => address; set => address = value; }
        public string City { get => city; set => city = value; }
        public string HouseType { get => houseType; set => houseType = value; }
        public int Space { get => space; set => space = value; }
        public bool Furnished { get => furnished; set => furnished = value; }
        public string ContractType { get => contractType; set => contractType = value; }
        public double Rent { get => rent; set => rent = value; }
        public double Deposit { get => deposit; set => deposit = value; }
        public byte[] HousePhoto { get => housePhoto; set => housePhoto = value; }

        public House(int houseID, int houseNumber, string address, string city, string houseType, int space, bool furnished, string contractType, int rent, int deposit, byte[] housePhoto)
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
        }
        public House(int houseNumber, string address, string city, string houseType, int space, bool furnished, string contractType, int rent, int deposit, byte[] housePhoto)
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
        }

        public House(HouseDTO houseDTO)
        {
            this.HouseID = houseDTO.HouseID;
            this.HouseNumber = houseDTO.HouseNumber;
            this.address = houseDTO.Address;
            this.city = houseDTO.City;
            this.houseType = houseDTO.HouseType;
            this.space = houseDTO.Space;
            this.furnished = houseDTO.Furnished;
            this.contractType = houseDTO.ContractType;
            this.rent = houseDTO.Rent;
            this.deposit = houseDTO.Deposit;
            this.housePhoto = houseDTO.HousePhoto;
        }
        public HouseDTO HouseToHouseDTO()
        {
            return new HouseDTO()
            {
                HouseID = this.HouseID,
                HouseNumber = this.HouseNumber,
                Address = this.Address,
                City = this.City,
                HouseType = this.HouseType,
                Space = this.Space,
                Furnished = this.Furnished,
                ContractType = this.ContractType,
                Rent = this.rent,
                Deposit = this.deposit,
                HousePhoto = this.housePhoto,
            };
        }

        public override string ToString()
        {
            return $"{address} {houseNumber}";
        }
    }
}