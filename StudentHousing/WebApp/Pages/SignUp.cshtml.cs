using DataAcces;
using Logic.DTO;
using Logic.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class SignUpModel : PageModel
    {
        [BindProperty]
        public CustomerDTO CustomerForm { get; set; }
        private readonly CustomerManager customerManager;

        public SignUpModel()
        {
            customerManager = new CustomerManager(new CustomerRepository());
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
                customerManager.AddCustomer(CustomerForm);
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
