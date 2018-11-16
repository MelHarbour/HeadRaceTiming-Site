using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using HeadRaceTimingSite.Helpers;
using HeadRaceTimingSite.Api.Resources;
using Microsoft.AspNetCore.JsonPatch;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;

namespace HeadRaceTimingSite.Api.Controllers
{
    public class CompetitionController : HeadRaceTimingSite.Controllers.BaseController
    {
        private readonly IAuthorizationHelper _authorizationHelper;
        private readonly IMapper _mapper;
        
        public CompetitionController(IAuthorizationHelper authorizationHelper, IMapper mapper, Models.TimingSiteContext context) : base(context)
        {
            _authorizationHelper = authorizationHelper;
            _mapper = mapper;
        } 
        
        /// <summary>
        /// Retrieves all the competitions
        /// </summary>
        /// <response code="200">List of competitions returned</response>
        /// <response code="404">Competition not found</response>
        [Produces("application/json")]
        [HttpGet("/api/competitions")]
        public async Task<IActionResult> ListAll()
        {
            List<Models.Competition> competitions = await _context.Competitions.ToListAsync();

            return Ok(_mapper.Map<List<Models.Competition>, List<Competition>>(competitions));
        }
    }
}
