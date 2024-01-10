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

        public List<Request> GetRequestsByCustomerID(int id)
        {
            List<Request> requestList= new List<Request>();
            foreach (RequestDTO requestDTO in request.GetRequestsByCustomerID(id))
            {
                requestList.Add(new Request(requestDTO));
            }
            return requestList;
        }

        public List<Request> GetRequestsByHouseID(int id)
        {
            List<Request> requestList = new List<Request>();
            foreach (RequestDTO requestDTO in request.GetRequestsByHouseID(id))
            {
                requestList.Add(new Request(requestDTO));
            }
            return requestList;
        }

        public bool UpdateRequest(RequestDTO requestDTO)
        {
            return request.UpdateRequest(requestDTO);
        }
    }
}
