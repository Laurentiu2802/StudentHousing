using Logic.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic.Managers;
using Logic.DTO;

namespace WebApp.Pages
{
    public class Recommended_HousesModel : PageModel
    {
        private readonly HouseManager houseManager;
        
        private readonly RecommendationManager recommendationManager;
        
        private readonly CustomerManager customerManager;

        [BindProperty]
        public HouseDTO house {  get; set; }

        public List<House> recommendedHouses = new List<House>();


        [BindProperty]
        public CustomerDTO customer { get; set; }

        public string name;

        public Recommended_HousesModel(HouseManager houseManager, RecommendationManager recommendationManager, CustomerManager customerManager)
        {
            this.houseManager = houseManager;
            this.recommendationManager = recommendationManager;
            this.customerManager = customerManager;
        }


        public void OnGet()
        {
            //List<House> houses = new List<House>();
            //recommendedHouses = houseManager.GetAllHouses();
            name = Request.Query["name"];
            if (User.Identity.IsAuthenticated)
            {
                string? customerID = User?.FindFirst("personID")?.Value;

                if(customerID != null)
                {
                    customer = customerManager.GetCustomerByID(Convert.ToInt32(customerID)).CustomerToCustomerDTO();
                }
                recommendedHouses = recommendationManager.GetRecommendedHouses(name, houses.ToList());
            }
        }

        public IActionResult OnPost()
        {
            if (house.HouseID != -1)
            {
                HttpContext.Session.SetInt32("houseID", house.HouseID);
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
