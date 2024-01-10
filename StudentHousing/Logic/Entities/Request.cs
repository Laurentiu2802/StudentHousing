using Logic.DTO;
using Logic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public class Request
    {
        private Customer customer;
        private House house;
        private int requestID;
        private RequestStatus status;

        public Customer Customer { get => customer; set => customer = value; }
        public House House { get => house; set => house = value; }
        public int RequestID { get => requestID; set => requestID = value; }
        public RequestStatus Status { get => status; set => status = value; }

        public Request(Customer customer, House house, int requestID, RequestStatus status)
        {
            this.customer = customer;
            this.house = house;
            this.requestID = requestID;
            this.status = status;
        }

        public Request(RequestDTO requestDTO)
        {
            this.customer= new Customer(requestDTO.CustomerDTO);
            this.house = new House(requestDTO.HouseDTO);
            this.requestID = requestDTO.RequestID;
            this.status = (RequestStatus)requestDTO.Status;
        }

        public RequestDTO RequestToRequestDTO()
        {
            return new RequestDTO()
            {
                CustomerDTO = customer.CustomerToCustomerDTO(),
                HouseDTO = house.HouseToHouseDTO(),
                Status = Convert.ToInt32(this.Status)
            };
        }

        public override string ToString()
        {
            return $"Address: {house.Address} {house.HouseNumber} Status: {status} Person: {customer.FirstName} {customer.LastName}";
        }
    }
}
