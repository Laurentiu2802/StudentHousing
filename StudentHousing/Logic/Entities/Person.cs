using Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public abstract class Person
    {
        protected int personID;
        protected string email;
        protected string password;
        protected bool isEmployee;

        public int PersonID { get => personID; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public bool IsEmployee { get => isEmployee; }


        public Person() { }

        protected Person(CustomerDTO customerDTO)
        {
            this.personID = customerDTO.PersonID;
            this.email = customerDTO.Email;
            this.password = customerDTO.Password;
            this.isEmployee = customerDTO.IsEmployee;
        }
        protected Person(int personID, string email, string password, bool isEmployee)
        {
            this.personID = personID;
            this.email = email;
            this.password = password;
            this.isEmployee = isEmployee;
        }
    }
}
