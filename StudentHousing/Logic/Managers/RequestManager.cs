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
    public class RequestManager
    {
        private readonly IRequest request;

        public RequestManager(IRequest request)
        {
            this.request= request?? throw new ArgumentNullException(nameof(request));
        }

        public bool AddRequest(RequestDTO requestDTO)
        {
            return request.AddRequest(requestDTO);
        }

        public List<Request> GetAllHouses()
        {
            List<House> houses = new List<House>();
            foreach (HouseDTO houseDTO in houseRepository.GetAllHouses())
            {
                houses.Add(new House(houseDTO));
            }
            return houses;
        }

    }
}
