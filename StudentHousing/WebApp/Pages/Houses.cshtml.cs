using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic.Entities;
using Logic.Interfaces;
using Logic.Managers;
using Logic.DTO;
using DataAcces;

namespace WebApp.Pages
{
    public class HousesModel : PageModel
    {
        private HouseManager houseManager;
        public List<House> Houses;

        [BindProperty]
        public HouseDTO HouseDTO { get; set; }

        private readonly HouseManager _houseManager;

        public HousesModel(HouseManager houseManager)
        {
            this._houseManager = houseManager;

        }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (HouseDTO.HouseID != -1)
            {
                HttpContext.Session.SetInt32("houseID", HouseDTO.HouseID);
                return RedirectToPage("/HouseDetails");
            }
            else
            {
                return Page();
            }
        }

        public IEnumerable<House> houses => houseManager.GetAllHouses();

    }
}
