using HeadRaceTimingSite.Models;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.Handlers
{
    public class CompetitionAdminAuthorizationHandler
        : AuthorizationHandler<CompetitionAdminRequirement, Competition>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CompetitionAdminRequirement requirement, Competition resource)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                string nameIdentifier = context.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
                if (resource.Administrators.FirstOrDefault(x => x.CompetitionAdministrator.NameIdentifier == nameIdentifier) != null)
                    context.Succeed(requirement);
            }
            
            return Task.CompletedTask;
        }
    }

    public class CompetitionAdminRequirement : IAuthorizationRequirement { }
}
