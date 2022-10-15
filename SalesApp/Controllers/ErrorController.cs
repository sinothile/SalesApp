using Microsoft.AspNetCore.Mvc;

namespace SalesApp.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
