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
                throw new RequestExceptions("Adding the request failed");
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
                                HouseType = Convert.ToInt32(dr["houseType"]),
                                Space = Convert.ToInt32(dr["space"]),
                                Furnished = Convert.ToBoolean(dr["furnishing"]),
                                ContractType = Convert.ToInt32(dr["contractType"]),
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
                throw new RequestExceptions("Retrieving the requests failed", ex);
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
                    string sql = "SELECT * FROM s2_Request r INNER JOIN s2_Customer c ON r.customerID = c.customerID INNER JOIN s2_Person p ON c.customerID = p.personID INNER JOIN s2_House h ON r.houseID = h.houseID WHERE r.houseID = @houseID";
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
                                HouseType = Convert.ToInt32(dr["houseType"]),
                                Space = Convert.ToInt32(dr["space"]),
                                Furnished = Convert.ToBoolean(dr["furnishing"]),
                                ContractType = Convert.ToInt32(dr["contractType"]),
                                Rent = Convert.ToDouble(dr["rent"]),
                                Deposit = Convert.ToDouble(dr["deposit"]),
                                HousePhoto = (byte[])dr["housePhoto"]
                            },
                            Status = Convert.ToInt32(dr["status"]),
                            RequestID = Convert.ToInt32(dr["requestID"])
                        };
                        requestList.Add(requestDTO);
                    }
                    passed = true;
                }
            }
            catch (Exception ex)
            {
                passed = false;
                throw new RequestExceptions("Retrieving the requests failed", ex);

            }
            if (passed = true)
            {
                return requestList;
            }
            else
            {
                return null;
                throw new RequestExceptions("Retrieving the requests failed");
            }
        }

        public List<RequestDTO> GetAllRequests()
        {
            List<RequestDTO> requestList = new List<RequestDTO>();

            try
            {
                using (SqlConnection conn = InitializeConection())
                {
                    string sql = "SELECT * FROM s2_Request  r INNER JOIN s2_Customer c ON r.customerID = c.customerID INNER JOIN s2_Person p ON c.customerID = p.personID INNER JOIN s2_House h ON r.houseID = h.houseID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
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
                                HouseType = Convert.ToInt32(dr["houseType"]),
                                Space = Convert.ToInt32(dr["space"]),
                                Furnished = Convert.ToBoolean(dr["furnishing"]),
                                ContractType = Convert.ToInt32(dr["contractType"]),
                                Rent = Convert.ToDouble(dr["rent"]),
                                Deposit = Convert.ToDouble(dr["deposit"]),
                                HousePhoto = (byte[])dr["housePhoto"]
                            },
                            Status = Convert.ToInt32(dr["status"]),
                            RequestID = Convert.ToInt32(dr["requestID"])
                        };
                        requestList.Add(requestDTO);
                    }
                    return requestList;

                }
            }
            catch (Exception ex)
            {
                throw new RequestExceptions("Retrieving all the requests failed");
            }
        }

        public bool UpdateRequest(RequestDTO requestDTO)
        {
            try
            {
                using (SqlConnection conn = InitializeConection())
                {
                    string sql = "UPDATE s2_Request SET status = @status WHERE requestID = @requestID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("requestID", requestDTO.RequestID);
                    cmd.Parameters.AddWithValue("status", requestDTO.Status);
                    

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new RequestExceptions("Updating the request failed");
            }
        }
    }
}
