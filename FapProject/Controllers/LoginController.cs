using FapProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FapProject.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Login(string name,string pass) {
            if (name == null || pass == null)
            {
                ViewBag.Username = name;
                TempData["ErrorMessage"] = "Vui lòng điền tài khoản , mật khẩu.";
                return View();
            }
            FapDbContext fap = new FapDbContext();
			var acc = fap.Students.ToList();
			foreach(var accItem in acc)
			{
				if(name.Equals(accItem.StudentEmail)&&pass.Equals(accItem.StudentPassword))
				{
					return RedirectToAction("Index","Home"); 
				}
			}
            ViewBag.Username = name;
            TempData["ErrorMessage"] = "Sai tài khoản hoặc mật khẩu.";
            return View();
		}
	}
}
