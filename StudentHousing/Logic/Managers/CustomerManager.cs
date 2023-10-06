using Logic.DTO;
using Logic.Entities;
using Logic.Exceptions;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Managers
{
    public class CustomerManager
    {
        private readonly ICustomer customerRepository;

        public CustomerManager(ICustomer customerRepository)
        {
            this.customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }


        public List<ValidationResult> TryToAddCustomer(CustomerDTO customerDTO)
        {
            List<ValidationResult> validationResults = new List<ValidationResult>();
            if (Validator.TryValidateObject(customerDTO, new ValidationContext(customerDTO), validationResults, true))
            {
                customerRepository.AddCustomer(customerDTO);
            }
            return validationResults;
        }
        public bool AddCustomer(CustomerDTO customerDTO)
        {
            return customerRepository.AddCustomer(customerDTO);
        }

        public Customer GetIDByCredentials(string email, string password)
        {
            try
            {
                return new Customer(customerRepository.GetCustomerByCredentials(email, password));
            }
            catch (CustomerExceptions ec)
            {
                throw new CustomerExceptions("Finding the customer failed", ec);
            }
        }
        public Customer GetCustomerByID(int id)
        {
            try
            {
                return new Customer(customerRepository.GetCustomerByID(id));
            }
            catch (CustomerExceptions ec)
            {
                throw new CustomerExceptions("Finding the customer failed", ec);
            }
        }


        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            foreach (CustomerDTO customerDTO in customerRepository.GetAllCustomers())
            {
                customers.Add(new Customer(customerDTO));
            }
            return customers;
        }
    }
}
