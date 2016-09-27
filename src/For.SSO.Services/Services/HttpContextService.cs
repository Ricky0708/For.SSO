using For.SSO.AuthenticationManager;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
namespace For.SSO.Services
{
    public class HttpContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IExceptionHandlerFeature GetExceptionHandlerFeature()
        {
            return _httpContextAccessor.HttpContext.Features.Get<IExceptionHandlerFeature>();
        }
        private HttpContext GetContext()
        {
            return _httpContextAccessor.HttpContext;
        }
    }
}
