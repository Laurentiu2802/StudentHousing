using Logic.DTO;
using Logic.Entities;
using Logic.Exceptions;
using Logic.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces
{
    public class RequestRepository : Connection,IRequest
    {
        public bool AddRequest(RequestDTO requestDTO)
        {

            try
            {
                using (SqlConnection conn = InitializeConection())
                {
                    const string sql = "INSERT INTO s2_Request ([houseID], [customerID], [status])" +
                        "VALUES (@houseID, @customerID, @status);";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("houseID", requestDTO.HouseDTO.HouseID);
                    cmd.Parameters.AddWithValue("customerID", requestDTO.CustomerDTO.PersonID);
                    cmd.Parameters.AddWithValue("status", 0);
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public List<RequestDTO> GetRequestsByCustomerID(int id)
        {
            List<RequestDTO> requestList = new List<RequestDTO>();

            try
            {
                using (SqlConnection conn = InitializeConection())
                {
                    string sql = "SELECT * FROM s2_Request r INNER JOIN s2_Customer c ON r.customerID = c.customerID INNER JOIN s2_House h ON r.houseID = h.houseID INNER JOIN s2_Person p ON c.customerID = p.personID WHERE r.customerID = @customerID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@customerID", id);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        var requestDTO = new RequestDTO
                        {
                            CustomerDTO = new CustomerDTO
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
                            },
                            HouseDTO = new HouseDTO
                            {
                                HouseID = Convert.ToInt32(dr["houseID"]),
                                HouseNumber = Convert.ToInt32(dr["houseNumber"]),
                                Address = dr["address"].ToString(),
                                City = dr["city"].ToString(),
                                HouseType = dr["houseType"].ToString(),
                                Space = Convert.ToInt32(dr["space"]),
                                Furnished = Convert.ToBoolean(dr["furnishing"]),
                                ContractType = dr["contractType"].ToString(),
                                Rent = Convert.ToDouble(dr["rent"]),
                                Deposit = Convert.ToDouble(dr["deposit"]),
                                HousePhoto = (byte[])dr["housePhoto"]
                            },
                            Status = Convert.ToInt32(dr["status"])
                        };
                        requestList.Add(requestDTO);
                    }
                    return requestList;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }

        }

        public List<RequestDTO> GetRequestsByHouseID(int id)
        {
            bool passed;
            List<RequestDTO> requestList = new List<RequestDTO>();

            try
            {
                using (SqlConnection conn = InitializeConection())
                {
                    string sql = "SELECT * FROM s2_Request r INNER JOIN s2_Customer c ON r.personID = c.customerID INNER JOIN s2_House h ON r.houseID = h.houseID WHERE r.houseID = @houseID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@houseID", id);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        var requestDTO = new RequestDTO
                        {
                            CustomerDTO = new CustomerDTO
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
                            },
                            HouseDTO = new HouseDTO
                            {
                                HouseID = Convert.ToInt32(dr["houseID"]),
                                HouseNumber = Convert.ToInt32(dr["houseNumber"]),
                                Address = dr["address"].ToString(),
                                City = dr["city"].ToString(),
                                HouseType = dr["houseType"].ToString(),
                                Space = Convert.ToInt32(dr["space"]),
                                Furnished = Convert.ToBoolean(dr["furnishing"]),
                                ContractType = dr["contractType"].ToString(),
                                Rent = Convert.ToDouble(dr["rent"]),
                                Deposit = Convert.ToDouble(dr["deposit"]),
                                HousePhoto = (byte[])dr["housePhoto"]
                            },
                            Status = Convert.ToInt32(dr["status"])
                        };
                        requestList.Add(requestDTO);
                    }
                    passed = true;
                }
            }
            catch (Exception ex)
            {
                passed = false;
            }
            if (passed = true)
            {
                return requestList;
            }
            else
            {
                return null;
            }
        }
    }
}
