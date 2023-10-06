using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DTO
{
    public class CustomerDTO
    {
        public int PersonID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsEmployee { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public CustomerDTO() { }


    }
}
