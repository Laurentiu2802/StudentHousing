using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic.Entities;
using Logic.Managers;
using DataAcces;
using Logic.DTO;

namespace WebApp.Pages
{
    public class HouseDetailsModel : PageModel
    {
        private int houseID = 0;
        private House house;
        HouseManager houseManager;
        private HouseRepository houseRepository = new HouseRepository();
        public void OnGet(int id)
        {
            houseID = id;
        }

        public House GetHouse()
        {
            houseManager = new HouseManager(houseRepository);
            foreach(House house in houseManager.GetAllHouses())
            {
                if(house.HouseID == houseID)
                {
                    this.house = house;
                }
            }
            return house;

        }
    }
}
