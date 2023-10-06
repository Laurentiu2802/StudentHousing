using Logic.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public class Customer : Person
    {
        private string username;
        private string firstName;
        private string lastName;
        private string address;
        private string city;
        private string country;


        [Required(ErrorMessage = "Your username is required.")]
        [StringLength(100, ErrorMessage = "Username must be at least {4} characters long.", MinimumLength = 4)]
        public string Username { get => username; }

        [Required(ErrorMessage = "Your first name is required.")]
        [StringLength(50, ErrorMessage = "The first name must be at most {4} characters long.", MinimumLength = 4)]
        public string FirstName { get => firstName; }

        [Required(ErrorMessage = "Your last name is required.")]
        [StringLength(50, ErrorMessage = "The last name must be at most {4} characters long.", MinimumLength = 4)]
        public string LastName { get => lastName; }

        [Required(ErrorMessage = "Your Address is required.")]
        [StringLength(50, ErrorMessage = "The address must be at most {4} characters long.", MinimumLength = 4)]
        public string Address { get => address; }

        [Required(ErrorMessage = "Your City is required.")]
        [StringLength(50, ErrorMessage = "The city must be at most {4} characters long.", MinimumLength = 4)]
        public string City { get => city; }

        [Required(ErrorMessage = "Your country is required.")]
        [StringLength(50, ErrorMessage = "The country must be at most {4} characters long.", MinimumLength = 4)]
        public string Country { get => country; }



        public Customer(string username, string firstName, string lastName, string address, string city, string country, int personID, string email, string password, bool isEmployee) : base(personID, email, password, isEmployee)
        {
            this.username = username;
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.country = country;
        }
        public Customer() { }

        public Customer(CustomerDTO customerDTO) : base(customerDTO)
        {
            this.username = customerDTO.Username;
            this.firstName = customerDTO.FirstName;
            this.lastName = customerDTO.LastName;
            this.address = customerDTO.Address;
            this.city = customerDTO.City;
            this.country = customerDTO.Country;
            this.personID = customerDTO.PersonID;
            this.email = customerDTO.Email;
            this.password = customerDTO.Password;
            this.isEmployee = customerDTO.IsEmployee;
        }

        public CustomerDTO CustomerToCustomerDTO()
        {
            return new CustomerDTO()
            {
                Username = this.username,
                FirstName = this.firstName,
                LastName = this.lastName,
                Address = this.address,
                City = this.city,
                Country = this.country,
                PersonID = this.personID,
                Email = this.email,
                Password = this.password,
                IsEmployee = this.isEmployee,
            };
        }


    }
}
