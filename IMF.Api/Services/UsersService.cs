using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace IMF.Api.Services
{
    public static class UsersService
    {
        public static string GetLoginUser(HttpContext httpContext)
        {
            string userName = httpContext.User.Identity?.Name ?? "Anonymous";

            if (userName.Equals("Anonymous"))
            {
                var claimsIdentity = httpContext.User.Identity as ClaimsIdentity;
                userName = claimsIdentity?.FindFirst(ClaimTypes.Email)?.Value;
            }
            return userName;
        }
    }
}
