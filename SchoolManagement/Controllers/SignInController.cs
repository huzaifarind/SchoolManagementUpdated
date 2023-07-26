using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagement.Controllers
{
    public class SignInController : Controller
    {
        // GET: SignIn
        public ActionResult SignIn()
        {
            return View();
        }

        // POST: YourLogin/SignIn
        [HttpPost]
        public ActionResult SignIn(string email, string password)
        {
            // Assuming you have a proper authentication mechanism in place.
            // Here, you should check if the email and password are correct.
            // Replace this with your actual authentication logic.
            bool isAuthenticated = CheckCredentials(email, password);

            if (isAuthenticated)
            {
                // Redirect to Dashboard action in DashboardController for admin users.
                return RedirectToAction("Dashboard", "DashboardController");
            }
            else
            {
                // Handle invalid credentials, for example, show an error message.
                ViewBag.ErrorMessage = "Invalid email or password.";
                return View("SignIn"); // Assuming your login view name is "SignIn.cshtml".
            }
        }

        // Replace this method with your actual authentication logic.
        private bool CheckCredentials(string email, string password)
        {
            // Implement your authentication logic here, such as checking against a database.
            // For the sake of this example, let's assume the email and password are correct if they are both "admin".
            return email == "admin@admin.com" && password == "admin";
        }



        public ActionResult Register()
        {
            return View();
        }
    }
}


