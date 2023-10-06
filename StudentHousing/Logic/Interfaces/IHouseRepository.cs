using Logic.DTO;

namespace DataAcces
{
    public interface IHouseRepository
    {
        bool AddHouse(HouseDTO houseDTO);
        List<HouseDTO> GetAllHouses();
        HouseDTO GetHouseByID(int id);
        bool UpdateHouse(HouseDTO houseDTO);
    }
}