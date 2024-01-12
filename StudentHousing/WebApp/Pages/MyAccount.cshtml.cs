using Logic.DTO;
using Logic.Managers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    [Authorize]
    public class MyAccountModel : PageModel
    {
        [BindProperty]
        public CustomerDTO customerDTO { get; set; }
        private readonly CustomerManager customerManager;

        public MyAccountModel(CustomerManager customerManager)
        {
            this.customerManager = customerManager;
        }

        public void OnGet()
        {
            string? customerID = User?.FindFirst("personID")?.Value;
            if(customerID != null) 
            {
                customerDTO = customerManager.GetCustomerByID(Convert.ToInt32(customerID)).CustomerToCustomerDTO();
            }
        }
        public async Task<IActionResult> OnPost()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToPage("Index");
        }
    }
}
