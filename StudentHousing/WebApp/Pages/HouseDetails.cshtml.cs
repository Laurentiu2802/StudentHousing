using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic.Entities;
using Logic.Managers;
using DataAcces;
using Logic.DTO;
using Microsoft.AspNetCore.Authorization;
using Logic.Enums;

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
        private readonly RequestManager requestManager;

        public HouseDetailsModel(HouseManager houseManager, CustomerManager customerManager, RequestManager requestManager)
        {

            this._houseManager = houseManager;
            this.customerManager = customerManager;
            this.requestManager = requestManager;
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
            string? customerID = User?.FindFirst("personID")?.Value;

            CustomerDTO = customerManager.GetCustomerByID(Convert.ToInt32(customerID)).CustomerToCustomerDTO();
            HouseDTO = _houseManager.GetHouseByID(HttpContext.Session.GetInt32("houseID").Value).HouseToHouseDTO();
            requestManager.AddRequest(new RequestDTO
            {
                CustomerDTO = CustomerDTO,
                HouseDTO = HouseDTO
            }
                );
            return RedirectToPage("Index");
        }


    }
}
