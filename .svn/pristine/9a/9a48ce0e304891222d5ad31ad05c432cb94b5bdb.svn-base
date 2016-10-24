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
            ForClaims idenConfig = new ForClaims(_claimsFactory.GetClaims(), ForClaims.ExternalCookie);

            //---加入驗證邏輯---
            if (true)
            {
                await _context.Authentication.SignOutAsync(schema);
                await _context.Authentication.SignInAsync(schema, new ForPrincipal(idenConfig), properties);
                //_context.User = new ForPrincipal(idenConfig);
                result.Succeeded = true;
            }
            else
            {
                result.Succeeded = false;
            }
            return result;
        }
        public async Task SignOut(string schema)
        {
            await _context.Authentication.SignOutAsync(schema);
        }
    }
}
