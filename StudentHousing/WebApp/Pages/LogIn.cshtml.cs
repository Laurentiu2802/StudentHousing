using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAcces;
using Logic.Exceptions;
using Logic.Entities;
using Logic.Managers;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Logic.DTO;
using Logic.Interfaces;

namespace WebApp.Pages
{
    public class LogInModel : PageModel
    {
        [BindProperty]
        public CustomerDTO CustomerForm { get; set; }
        [BindProperty]
        public string ErrorMessage { get; set; }
        [BindProperty]
        public string ReturnUrl { get; set; }

        private readonly CustomerManager customerManager;

        public LogInModel()
        {
            customerManager = new CustomerManager(new CustomerRepository());


        }
        public void OnGet()
        {
            ReturnUrl = Request.Query["ReturnUrl"];

            //if (!string.IsNullOrEmpty(returnUrl))
            //{
            //    Response.Redirect(returnUrl);
            //}
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                CustomerForm = customerManager.GetIDByCredentials(CustomerForm.Email, CustomerForm.Password).CustomerToCustomerDTO();
                if (CustomerForm.PersonID > -1)
                {
                    HttpContext.Session.SetInt32("personID", CustomerForm.PersonID);

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, CustomerForm.Email),
                        new Claim("personID", CustomerForm.PersonID.ToString())
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var props = new AuthenticationProperties();

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);
                    if(ReturnUrl != null)
                    {
                        return RedirectToPage(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToPage("Index");

                    }
                    //return RedirectToPage("Index");
                }
                else
                {
                    return Page();
                }
            }
            catch (CustomerExceptions ec)
            {

                this.ErrorMessage = "Invalid Credentials";
                ModelState.AddModelError("Invalid Credentials", ec.Message);
                return Page();
            }

        }
    }
}
