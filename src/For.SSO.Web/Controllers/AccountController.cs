using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using For.SSO.Services;
using For.SSO.Services.Repository;
using For.SSO.DB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using For.SSO.AuthenticationManager;
using Microsoft.AspNetCore.Diagnostics;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace For.SSO.Web.Controllers
{
    public class AccountController : _baseController
    {
        IAccountRepository repo = (IAccountRepository)RepositoryHelper.GetRepository<Account>();
        SignInManager _signInManager;

        public AccountController(IServiceProvider serviceProvider, SignInManager signInManager) : base(serviceProvider)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Login(AccountViewModel model, [FromQuery] string returnUrl)
        {

            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var p = _signInManager.SignIn("AA",
                    new Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties()
                    {
                        IsPersistent = true
                    }).Result;
                //return View(model);
                if (p.Succeeded)
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }


        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOut("AA");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
