using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using For.SSO.DB.Models;
using For.SSO.Services.Repository;
using For.SSO.Services;
using Microsoft.AspNetCore.Authorization;
using For.Authentication;

namespace For.SSO.Web.Controllers
{
    public class HomeController : _baseController
    {

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            return RedirectToAction(nameof(AccountController.LogOff), "Account");
        }

    }
}
