using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HeadRaceTimingSite.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using HeadRaceTimingSite.Helpers;
using AutoMapper;
using HeadRaceTimingSite.ViewModels;

namespace HeadRaceTimingSite.Controllers
{
    public class CrewController : BaseController
    {
        private readonly IMapper _mapper;

        public CrewController(IMapper mapper, TimingSiteContext context) : base(context)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [Produces("application/pdf")]
        public async Task<IActionResult> Certificate(int crewId)
        {
            System.Net.Mime.ContentDisposition cd = new System.Net.Mime.ContentDisposition
            {
                FileName = "rowing-certificate.pdf",
                Inline = false
            };
            Response.Headers.Add("Content-Disposition", cd.ToString());
            Response.Headers.Add("X-Content-Type-Options", "nosniff");

            return Ok();
        }
    }
}
