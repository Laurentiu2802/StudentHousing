using Logic.DTO;
using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface ICustomer
    {
        public bool AddCustomer(CustomerDTO customerDTO);
        public CustomerDTO GetCustomerByCredentials(string email, string password);
        public CustomerDTO GetCustomerByID(int id);
        public List<CustomerDTO> GetAllCustomers();
    }
}
