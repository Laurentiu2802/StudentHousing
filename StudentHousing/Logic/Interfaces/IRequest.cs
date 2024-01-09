using Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IRequest
    {
        public bool AddRequest(RequestDTO requestDTO);
        public List<RequestDTO> GetRequestsByCustomerID(int id);
        public List<RequestDTO> GetRequestsByHouseID(int id);
    }
}
