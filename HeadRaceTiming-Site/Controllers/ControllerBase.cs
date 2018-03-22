using HeadRaceTimingSite.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly TimingSiteContext _context;

        public BaseController(TimingSiteContext context)
        {
            _context = context;
        }
    }
}
