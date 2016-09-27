using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using For.SSO.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace For.SSO.Web.Controllers
{
    public class ErrorsController : _baseController
    {
        public ErrorsController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
        public IActionResult ErrorHandler()
        {
            var n = _contextService.GetExceptionHandlerFeature();
            ViewBag.Error = n.Error;
            return PartialView();
        }

        public IActionResult ErrorStatusCode(string id)
        {
            ViewBag.Error = id;
            return PartialView();
        }
    }
}
