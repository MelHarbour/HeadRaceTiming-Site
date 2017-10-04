using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace HeadRaceTimingSite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction(nameof(CompetitionController.Index), "Home");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
