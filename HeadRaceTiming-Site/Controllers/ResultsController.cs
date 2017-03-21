using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HeadRaceTiming_Site.Controllers
{
    public class ResultsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Crew()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
