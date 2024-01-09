using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DTO
{
    public class RequestDTO
    {
        public HouseDTO HouseDTO { get; set; }
        public CustomerDTO CustomerDTO { get; set; }
        public int RequestID {  get; set; }
        public int Status { get; set; }

        public RequestDTO() { }
    }
}
