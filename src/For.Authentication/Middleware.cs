using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace For.Authentication
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ReplacePrincipal
    {
        private readonly RequestDelegate _next;

        public ReplacePrincipal(RequestDelegate next)
        {
             
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            if (httpContext.User.Identity.IsAuthenticated)
            {
                //AntiForgeryConfig.UniqueClaimTypeIdentifier = IdentityConfig.UserNoClaimType;
                var claimsIdentity = new IdentityClaims(((ClaimsPrincipal)httpContext.User).Claims,
                    IdentityClaims.ExternalCookie);
                IdentityPrincipal newUser = new IdentityPrincipal(claimsIdentity);

                httpContext.User = newUser;
            }
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseReplacePrincipal(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ReplacePrincipal>();
        }
    }
}
