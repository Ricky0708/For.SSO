using For.Authentication;
using For.SSO.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace For.SSO.Web.Controllers
{
    public class _baseController : Controller
    {
        protected HttpContextService _contextService;

        public _baseController(IServiceProvider serviceProvider)
        {
            _contextService = (HttpContextService)serviceProvider.GetService(typeof(HttpContextService));
        }

    }
}
