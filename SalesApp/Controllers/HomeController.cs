using Microsoft.AspNetCore.Mvc;
using SalesApp.Models;
using System.Diagnostics;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace SalesApp.Controllers
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
        }

        public IActionResult Login(LoginViewModel userDetails)
        {
            if (ModelState.IsValid)
            {
                if (userDetails != null)
                {
                    int userId = 0;
                    if (userDetails.UserName.ToLower() == "zane" && userDetails.Password == "123@pass")
                    {
                        userId = 1;
                        Response.Cookies.Append("userId", $"{userId}");
                        return RedirectToAction("Index", "Products");
                    }
                    if (userDetails.UserName.ToLower() == "lerato" && userDetails.Password == "Nunit@321")
                    {
                        userId = 2;
                        Response.Cookies.Append("userId", $"{userId}");
                        return RedirectToAction("Index", "Products");
                    }
                }
            }

            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}