using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.Handlers
{
    public class AdminAuthorizationHandler : IAuthorizationHandler
    {
        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            var pendingRequirements = context.PendingRequirements.ToList();

            foreach (var requirement in pendingRequirements)
            {
                if (context.User.HasClaim(x => x.Type == ClaimTypes.Role))
                {
                    if (context.User.Claims.First(x => x.Type == ClaimTypes.Role).Value == "admin")
                    {
                        context.Succeed(requirement);
                    }
                }
            }
            return Task.CompletedTask;
        }
    }
}
