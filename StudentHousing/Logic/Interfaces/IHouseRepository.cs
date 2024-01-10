using Logic.DTO;

namespace DataAcces
{
    public interface IHouseRepository
    {
        bool AddHouse(HouseDTO houseDTO);
        List<HouseDTO> GetAllHouses();
        List<HouseDTO> GetAllHousesByStatusAndType(bool Status, int HouseType);
        HouseDTO GetHouseByID(int id);
        bool UpdateHouse(HouseDTO houseDTO);
    }
}