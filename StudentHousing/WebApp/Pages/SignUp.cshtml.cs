using DataAcces;
using Logic.DTO;
using Logic.Exceptions;
using Logic.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class SignUpModel : PageModel
    {
        [BindProperty]
        public string ErrorMessage { get; set; }

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
            try
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
            catch(CustomerExceptions ec)
            {
                this.ErrorMessage = "Invalid Credentials";
                ModelState.AddModelError("Invalid Credentials", ec.Message);
                return Page();
            }
 
        }
    }
}
