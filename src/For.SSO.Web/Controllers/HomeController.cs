using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using For.SSO.DB.Models;
using For.SSO.Services.Repository;
using For.SSO.Services;
using Microsoft.AspNetCore.Authorization;

namespace For.SSO.Web.Controllers
{
    public class HomeController : Controller
    {
      

        public HomeController()
        {
        }

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
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
