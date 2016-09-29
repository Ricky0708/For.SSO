using For.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace For.Authentication
{
    public class SignInManager
    {
        private HttpContext _context;
        private IClaimsFactory _claimsFactory;
        public SignInManager(IHttpContextAccessor accessor, IClaimsFactory claimsFactory)
        {
            _context = accessor.HttpContext;
            _claimsFactory = claimsFactory;
        }
        public async Task<SignInResult> SignIn(string schema, AuthenticationProperties properties, params ClaimsIdentity[] identities)
        {
            SignInResult result = new SignInResult();
            IdentityClaims idenConfig = new IdentityClaims(_claimsFactory.GetClaims(), IdentityClaims.ExternalCookie);
            await _context.Authentication.SignInAsync(schema, new IdentityPrincipal(idenConfig), properties);
            result.Succeeded = true;
            _context.User = new IdentityPrincipal(idenConfig);
            return result;
        }
        public async Task SignOut(string schema)
        {
            await _context.Authentication.SignOutAsync(schema);
        }
        //internal List<Claim> GetClaims()
        //{
        //    List<Claim> claims = new List<Claim>();
        //    claims.Add(new Claim(IdentityClaims.UserIdClaimType, "1"));
        //    claims.Add(new Claim(IdentityClaims.UserNameClaimType, "RickyClaim"));
        //    claims.Add(new Claim(IdentityClaims.GroupsClaimType, "GroupA"));
        //    claims.Add(new Claim(IdentityClaims.GroupsClaimType, "GroupB"));
        //    claims.Add(new Claim(IdentityClaims.ProgramsClaimType, "ProgramA"));
        //    claims.Add(new Claim(IdentityClaims.ProgramsClaimType, "ProgramB"));
        //    return claims;
        //}
    }
}
