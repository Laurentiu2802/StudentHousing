using Logic.DTO;
using Logic.Exceptions;
using Logic.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DataAcces
{
    public class CustomerRepository : Connection , ICustomer 
    {
        public bool AddCustomer(CustomerDTO customerDTO)
        {

            try
            {
                using (SqlConnection conn = InitializeConection())
                {
                    const string sql = @"declare @passwordSalt varchar(max) = crypt_gen_random(16)
                        INSERT INTO s2_Person ([email], [password], [passwordSalt], [isEmployee])" +
                        "VALUES (@email, hashbytes('SHA2_256', convert(varchar(max), concat(convert(varchar(max), @password), @passwordSalt))), @passwordSalt, @isEmployee); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("email", customerDTO.Email);
                    cmd.Parameters.AddWithValue("password", customerDTO.Password);
                    cmd.Parameters.AddWithValue("isEmployee", customerDTO.IsEmployee);
                    conn.Open();
                    int insertedID = Convert.ToInt32(cmd.ExecuteScalar());

                    const string sql1 = "INSERT INTO s2_Customer ([customerID],[username],[firstName],[lastName],[address],[city],[country]) " +
                        "VALUES (@customerID, @username, @firstName, @lastName, @address, @city, @country); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd1 = new SqlCommand(sql1, conn);
                    cmd1.Parameters.AddWithValue("customerID", insertedID);
                    cmd1.Parameters.AddWithValue("username", customerDTO.Username);
                    cmd1.Parameters.AddWithValue("firstName", customerDTO.FirstName);
                    cmd1.Parameters.AddWithValue("lastName", customerDTO.LastName);
                    cmd1.Parameters.AddWithValue("address", customerDTO.Address);
                    cmd1.Parameters.AddWithValue("city", customerDTO.City);
                    cmd1.Parameters.AddWithValue("country", customerDTO.Country);
                    cmd1.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new CustomerExceptions("Adding the customer failed", ex);
            }
        }

        public CustomerDTO GetCustomerByCredentials(string email, string password)
        {


            try
            {
                using (SqlConnection conn = InitializeConection())
                {
                    string sql = "SELECT * FROM s2_Person p INNER JOIN s2_Customer c ON p.personID = c.customerID WHERE email = @email AND password = hashbytes('SHA2_256', convert(varchar(max), concat(convert(varchar(max), @password), passwordSalt)))";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        var customerDTO = new CustomerDTO
                        {
                            PersonID = Convert.ToInt32(dr["personID"]),
                            Email = dr["email"].ToString(),
                            Password = dr["password"].ToString(),
                            IsEmployee = Convert.ToBoolean(dr["isEmployee"]),
                            Username = dr["username"].ToString(),
                            FirstName = dr["firstName"].ToString(),
                            LastName = dr["lastName"].ToString(),
                            Address = dr["address"].ToString(),
                            City = dr["city"].ToString(),
                            Country = dr["country"].ToString(),
                        };

                        return customerDTO;
                    }

                }
            }
            catch (Exception ex)
            {
                throw new CustomerExceptions("Finding the customer failed", ex);
            }
            throw new CustomerExceptions("Finding the customer failed");
        }

        public CustomerDTO GetCustomerByID(int id)
        {


            try
            {
                using (SqlConnection conn = InitializeConection())
                {
                    string sql = "SELECT * FROM s2_Person p INNER JOIN s2_Customer c ON p.personID = c.customerID WHERE c.customerID = @customerID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@customerID", id);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        var customerDTO = new CustomerDTO
                        {
                            PersonID = Convert.ToInt32(dr["personID"]),
                            Email = dr["email"].ToString(),
                            Password = dr["password"].ToString(),
                            IsEmployee = Convert.ToBoolean(dr["isEmployee"]),
                            Username = dr["username"].ToString(),
                            FirstName = dr["firstName"].ToString(),
                            LastName = dr["lastName"].ToString(),
                            Address = dr["address"].ToString(),
                            City = dr["city"].ToString(),
                            Country = dr["country"].ToString(),
                        };

                        return customerDTO;
                    }

                }
            }
            catch (Exception ex)
            {
                throw new CustomerExceptions("Finding the customer failed", ex);
            }
            throw new CustomerExceptions("Finding the customer failed");
        }
        public List<CustomerDTO> GetAllCustomers()
        {
            bool passed;
            List<CustomerDTO> customersList = new List<CustomerDTO>();

            try
            {
                using (SqlConnection conn = InitializeConection())
                {
                    string sql = "SELECT * FROM s2_Person p INNER JOIN s_Customer c ON p.personID = c.customerID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        var customerDTO = new CustomerDTO
                        {
                            PersonID = Convert.ToInt32(dr["personID"]),
                            Email = dr["email"].ToString(),
                            Password = dr["password"].ToString(),
                            IsEmployee = Convert.ToBoolean(dr["isEmployee"]),
                            Username = dr["username"].ToString(),
                            FirstName = dr["firstName"].ToString(),
                            LastName = dr["lastName"].ToString(),
                            Address = dr["address"].ToString(),
                            City = dr["city"].ToString(),
                            Country = dr["country"].ToString(),
                        };
                        customersList.Add(customerDTO);
                    }
                    passed = true;

                }
            }
            catch (Exception ex)
            {
                passed = false;
                throw new CustomerExceptions("Retrieving all the customers failed", ex);
            }

            if (passed = true)
            {
                return customersList;
            }
            else
            {
                throw new CustomerExceptions("Retrieving all the customers failed");
            }
        }
    }
}
