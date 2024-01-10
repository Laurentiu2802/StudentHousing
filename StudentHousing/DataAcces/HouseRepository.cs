using Logic.DTO;
using Logic.Exceptions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces
{
    public class HouseRepository : Connection, IHouseRepository
    {
        public bool AddHouse(HouseDTO houseDTO)
        {

            try
            {
                using (SqlConnection conn = InitializeConection())
                {
                    const string sql = "INSERT INTO s2_House ([houseNumber], [address], [city], [houseType], [space], [furnished], [contractType], [rent], [deposit], [housePhoto],[furnishing])" +
                        "VALUES (@houseNumber, @address, @city, @houseType, @space, @furnished, @contractType, @rent, @deposit, @housePhoto,@furnished);";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("houseNumber", houseDTO.HouseNumber);
                    cmd.Parameters.AddWithValue("address", houseDTO.Address);
                    cmd.Parameters.AddWithValue("city", houseDTO.City);
                    cmd.Parameters.AddWithValue("houseType", houseDTO.HouseType);
                    cmd.Parameters.AddWithValue("space", houseDTO.Space);
                    cmd.Parameters.AddWithValue("furnished", Convert.ToInt32(houseDTO.Furnished));
                    cmd.Parameters.AddWithValue("contractType", houseDTO.ContractType);
                    cmd.Parameters.AddWithValue("rent", houseDTO.Rent);
                    cmd.Parameters.AddWithValue("deposit", houseDTO.Deposit);
                    cmd.Parameters.AddWithValue("housePhoto", houseDTO.HousePhoto);
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

        public HouseDTO GetHouseByID(int id)
        {
            try
            {
                using (SqlConnection conn = InitializeConection())
                {
                    string sql = "SELECT * FROM s2_House WHERE houseID = @houseID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@houseID", id);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        var houseDTO = new HouseDTO()
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
                        };

                        return houseDTO;
                    }

                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
            throw new NotImplementedException();
        }
        public List<HouseDTO> GetAllHouses()
        {
            List<HouseDTO> houseList = new List<HouseDTO>();

            try
            {
                using (SqlConnection conn = InitializeConection())
                {
                    string sql = "SELECT * FROM s2_House";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        var houseDTO = new HouseDTO
                        {
                            HouseID = Convert.ToInt32(dr["houseID"]),
                            HouseNumber = Convert.ToInt32(dr["houseNumber"]),
                            Address = dr["address"].ToString(),
                            City = dr["city"].ToString(),
                            HouseType = dr["houseType"].ToString(),
                            Space = Convert.ToInt32(dr["space"]),
                            Furnished = Convert.ToBoolean(dr["furnished"]),
                            ContractType = dr["contractType"].ToString(),
                            Rent = Convert.ToDouble(dr["rent"]),
                            Deposit = Convert.ToDouble(dr["deposit"]),
                            HousePhoto = (byte[])dr["housePhoto"]
                        };
                        houseList.Add(houseDTO);
                    }
                    return houseList;

                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public List<HouseDTO> GetAllHousesByID(int id)
        {
            List<HouseDTO> houseList = new List<HouseDTO>();

            try
            {
                using (SqlConnection conn = InitializeConection())
                {
                    string sql = "SELECT * FROM s2_House WHERE houseID = @houseID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@houseID", id);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        var houseDTO = new HouseDTO
                        {
                            HouseID = Convert.ToInt32(dr["houseID"]),
                            HouseNumber = Convert.ToInt32(dr["houseNumber"]),
                            Address = dr["address"].ToString(),
                            City = dr["city"].ToString(),
                            HouseType = dr["houseType"].ToString(),
                            Space = Convert.ToInt32(dr["space"]),
                            Furnished = Convert.ToBoolean(dr["furnished"]),
                            ContractType = dr["contractType"].ToString(),
                            Rent = Convert.ToDouble(dr["rent"]),
                            Deposit = Convert.ToDouble(dr["deposit"]),
                            HousePhoto = (byte[])dr["housePhoto"]
                        };
                        houseList.Add(houseDTO);
                    }
                    return houseList;

                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public bool UpdateHouse(HouseDTO houseDTO)
        {
            try
            {
                using (SqlConnection conn = InitializeConection())
                {
                    string sql = "UPDATE s2_House SET houseNumber = @houseNumber, address = @address, city = @city, houseType = @houseType, space = @space, furnished = @furnished, contractType = @contractType, rent = @rent, deposit = @deposit, housePhoto = @housePhoto, areaName = @areaName WHERE houseID = houseID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("houseNumber", houseDTO.HouseNumber);
                    cmd.Parameters.AddWithValue("address", houseDTO.Address);
                    cmd.Parameters.AddWithValue("city", houseDTO.City);
                    cmd.Parameters.AddWithValue("houseType", houseDTO.HouseType);
                    cmd.Parameters.AddWithValue("space", houseDTO.Space);
                    cmd.Parameters.AddWithValue("furnished", houseDTO.Furnished);
                    cmd.Parameters.AddWithValue("contractType", houseDTO.ContractType);
                    cmd.Parameters.AddWithValue("rent", houseDTO.Rent);
                    cmd.Parameters.AddWithValue("deposit", houseDTO.Deposit);
                    cmd.Parameters.AddWithValue("housePhoto", houseDTO.HousePhoto);

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
    }
}
