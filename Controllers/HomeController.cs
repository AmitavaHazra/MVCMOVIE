using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_Windows.Models;

namespace MVC_Windows.Controllers
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
            string xt = "";
            if (User.IsInGroup("MIM\\Domain Admins"))
            {
                string t = "Domain Admins";
               xt  = t;
                
            }
            Record rc = new Record
            {
                RecordName = xt        
            };
            //To Pass data to view from controller use ViewBag. Also we need a model class.
            ViewBag.Message = rc;
            return View();
        }

        [Authorize(Roles = "MIM\\Domain Admins")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
