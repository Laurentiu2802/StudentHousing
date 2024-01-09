using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic.Entities;
using Logic.Managers;
using DataAcces;
using Logic.DTO;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Pages
{
    [Authorize]
    public class HouseDetailsModel : PageModel
    {
        private HouseManager houseManager;

        [BindProperty]
        public HouseDTO HouseDTO { get; set; }
        [BindProperty]
        CustomerDTO CustomerDTO { get; set; }

        private readonly HouseManager _houseManager;
        private readonly CustomerManager customerManager;

        public HouseDetailsModel(HouseManager houseManager, CustomerManager customerManager)
        {

            this._houseManager = houseManager;
            this.customerManager = customerManager;
        }
        public void OnGet()
        {
            HouseDTO = _houseManager.GetHouseByID(HttpContext.Session.GetInt32("houseID").Value).HouseToHouseDTO();
            string? id = User?.FindFirst("personID")?.Value;

            if(id == null)
            {
                CustomerDTO = customerManager.GetCustomerByID(Convert.ToInt32("personID")).CustomerToCustomerDTO();
            }

        }

        public IActionResult OnPost()
        {

            return null;
        }


    }
}
