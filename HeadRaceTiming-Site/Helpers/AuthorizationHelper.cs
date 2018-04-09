using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.Helpers
{
    public class AuthorizationHelper : IAuthorizationHelper
    {
        private readonly IAuthorizationService _authorizationService;

        public AuthorizationHelper(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public async Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user, object resource, string policy)
        {
            return await _authorizationService.AuthorizeAsync(user, resource, policy);
        }
    }

    public interface IAuthorizationHelper
    {
        Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user, object resource, string policy);
    }
}
