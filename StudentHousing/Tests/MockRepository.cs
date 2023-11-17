using Logic.DTO;
using Logic.Entities;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class MockRepository : ICustomer
    {
        CustomerDTO customer = new CustomerDTO();
        List<CustomerDTO> customers;


        public bool AddCustomer(CustomerDTO customerDTO)
        {
            customers = new List<CustomerDTO>();
            customers.Add(customerDTO);
            if (customers.Count > 0)
            {
                return true;
            }
            return false;
        }

        public CustomerDTO GetCustomerByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<CustomerDTO> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public CustomerDTO GetCustomerByCredentials(string email, string password)
        {
            customers = new List<CustomerDTO>();
            var c = new Customer("testUserName", "testFirstName", "testLastName", "testAddress", "testCity", "testCountry", 6, "testEmail", "testPassword", false).CustomerToCustomerDTO();
            customers.Add(c);
            foreach (CustomerDTO customer in customers)
            {
                if (customer.Email == email && customer.Password == password)
                {
                    return customer;
                }
            }
            throw new Exception();
        }
    }
}
