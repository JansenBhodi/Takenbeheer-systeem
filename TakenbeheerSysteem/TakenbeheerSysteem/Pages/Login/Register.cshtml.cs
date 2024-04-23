using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TakenbeheerSysteem.Pages.Login
{
    public class RegisterModel : PageModel
    {
        public void OnGet()
        {
        }


        public IActionResult OnPost()
        {
            string name = Request.Form["Name"];
            string email = Request.Form["Email"];
            string password = Request.Form["Password"];

            //Send data through


            if (true)
            {

                return Redirect("Login");
            }
            return Redirect("Register");
        }
    }
}
