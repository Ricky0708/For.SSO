using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace For.SSO.AuthenticationManager
{
    public class SignInManager
    {
        private HttpContext _context;
        public SignInManager(IHttpContextAccessor accessor)
        {
            _context = accessor.HttpContext;
        }
        public async Task<SignInResult> SignIn(string schema, AuthenticationProperties properties, params ClaimsIdentity[] identities)
        {
            SignInResult result = new SignInResult();
            IdentityConfig idenConfig = new IdentityConfig(GetClaims(), IdentityConfig.ExternalCookie);
            await _context.Authentication.SignInAsync(schema, new IdentityPrincipal(idenConfig), properties);
            result.Succeeded = true;
            _context.User = new IdentityPrincipal(idenConfig);
            return result;
        }
        public async Task SignOut(string schema)
        {
            await _context.Authentication.SignOutAsync(schema);
        }
        internal List<Claim> GetClaims()
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(IdentityConfig.UserIdClaimType, "1"));
            claims.Add(new Claim(IdentityConfig.UserNameClaimType, "RickyClaim"));
            claims.Add(new Claim(IdentityConfig.GroupsClaimType, "GroupA"));
            claims.Add(new Claim(IdentityConfig.GroupsClaimType, "GroupB"));
            claims.Add(new Claim(IdentityConfig.ProgramsClaimType, "ProgramA"));
            claims.Add(new Claim(IdentityConfig.ProgramsClaimType, "ProgramB"));
            return claims;
        }
    }
}
