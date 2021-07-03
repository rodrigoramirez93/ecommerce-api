using Ecommerce.BusinessLogic.Interfaces;
using Ecommerce.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Security.Claims;

namespace Ecommerce.API.Filters
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        private readonly ILoggedUserService _loggedUserService;
        public AuthorizationFilter(
            ILoggedUserService loggedUserService)
        {
            _loggedUserService = loggedUserService; 
        }
        
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool hasAllowAnonymous =
                context
                    .ActionDescriptor
                    .EndpointMetadata
                        .Any(attribute => attribute.GetType() == typeof(AllowAnonymousAttribute));

            if (hasAllowAnonymous)

                return;
            var claims = ((ClaimsIdentity)context.HttpContext.User.Identity).Claims;
            var tenantClaim = claims.Where(x => x.Type == Constants.Claim.Tenant);
            var idClaim = claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();

            _loggedUserService.SetUserId(idClaim);
            _loggedUserService.SetEmail(context.HttpContext.User.Identity.Name);
            _loggedUserService.SetClaims(claims.Except(tenantClaim));
            _loggedUserService.SetTenants(tenantClaim);
        }
    }
}
