﻿using Microsoft.AspNetCore.Mvc;

namespace FapProject.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
