using DataAcces;
using Logic.DTO;
using Logic.Entities;
using Logic.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class MyApplicationsModel : PageModel
    {
        private HouseManager houseManager;
        private RequestManager requestManager;
        public List<Request> requestList;

        [BindProperty]
        public HouseDTO HouseDTO { get; set; }

        private readonly HouseManager _houseManager;
        private readonly RequestManager _requestManager;

        public MyApplicationsModel(HouseManager houseManager, RequestManager requestManager)
        {
            this._houseManager = houseManager;
            this._requestManager = requestManager;
        }
        public void OnGet()
        {
            string? customerID = User?.FindFirst("personID")?.Value;

            if (!string.IsNullOrEmpty(customerID))
            {
                requestList = _requestManager.GetRequestsByCustomerID(Convert.ToInt32(customerID));
            }
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
        //public IEnumerable<Request> RequestList()
        //{
        //    string? customerID = User?.FindFirst("personID")?.Value;
        //    return requestList = _requestManager.GetRequestsByCustomerID(Convert.ToInt32(customerID));
        //}
        //public IEnumerable<Request> requestList => requestManager.GetRequestsByCustomerID(customerID);

    }
}
