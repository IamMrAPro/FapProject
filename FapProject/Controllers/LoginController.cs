using FapProject.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FapProject.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (email == null || password == null)
            {
                ViewBag.Username = email;
                TempData["ErrorMessage"] = "Vui lòng điền tài khoản , mật khẩu.";
                return View();
            }
            FapDbContext fap = new FapDbContext();
            var acc = fap.Students.ToList();
            foreach (var accItem in acc)
            {
                if (email.Equals(accItem.StudentEmail)&&password.Equals(accItem.StudentPassword))
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ViewBag.Username = email;
            TempData["ErrorMessage"] = "Sai tài khoản hoặc mật khẩu.";
            return View();
        }

        [HttpGet]
        [Route("/signin-google")]
        public IActionResult LoginGoogle()
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = Url.Action("GoogleCallback"),
            };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [HttpGet]
        [Route("/google-callback")]
        public async Task<IActionResult> GoogleCallback()
        {
            var result = await HttpContext.AuthenticateAsync(IdentityConstants.ExternalScheme);

            if (result.Succeeded)
            {
                // Get user information from the authentication result
                var email = result.Principal.FindFirstValue(ClaimTypes.Email);
                var firstName = result.Principal.FindFirstValue(ClaimTypes.GivenName);
                var lastName = result.Principal.FindFirstValue(ClaimTypes.Surname);

                // Here, you would create or authenticate the user in your application's database,
                // and sign them in with your application's cookie authentication middleware.
                // For demonstration purposes, we'll just display the user's information in a view.
                using (var context = new FapDbContext())
                {
                    var st = context.Students.SingleOrDefault(s => s.StudentEmail == email);
                    if (st != null)
                    {
                        RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction(nameof(Login));
                    }
                }
            }

            // If we get here, authentication failed.
            return RedirectToAction(nameof(Login));
        }
    }
}
