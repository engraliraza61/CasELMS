using CasELMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CasELMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
            //if (Request.Cookies["userIdentity"] == null)
            //{
            //    return RedirectToActionPermanent("LoginPage");
            //}
            //else
            //{
            //    return View();
            //}
        }
        public IActionResult Pricing()
        {
            return View();
        }
        public IActionResult TimeLine()
        {
            return View();
        }
        public IActionResult LoginPage()
        {
            return View();
        }
        public IActionResult RegisterPage()
        {
            return View();
        }
        public IActionResult LockScreenPage()
        {
            return View();
        }
        public IActionResult UserProfile ()
        {
            return View();
        }
        public IActionResult AllStudent()
        {
            return View();
        }
        public IActionResult AddStudent()
        {
            return View();
        }

        public IActionResult UpdateStudent(string id)
        {
            ViewBag.id = id;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
