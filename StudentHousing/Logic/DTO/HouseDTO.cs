using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DTO
{
    public class HouseDTO
    {
        public int HouseID { get; set; }
        public int HouseNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string HouseType { get; set; }
        public int Space { get; set; }
        public bool Furnished { get; set; }
        public string ContractType { get; set; }
        public double Rent { get; set; }
        public double Deposit { get; set; }
        public byte[] HousePhoto { get; set; }

        public HouseDTO() { }
    }
}
