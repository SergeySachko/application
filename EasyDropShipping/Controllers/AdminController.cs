using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    public class AdminController : Controller
    {
        private readonly SignInManager<ApplicationUser> signManager;

        public AdminController(SignInManager<ApplicationUser> _signInManager)
        {
            signManager = _signInManager;
        }

        public IActionResult Index()
        {
            if (signManager.IsSignedIn(HttpContext.User))
            {
                return RedirectToAction("Admin", "Account");
            }
            else
            {
                return RedirectToAction("Login", "Account", new { returnUrl = Request.Path });
            }
        }
    }
}