using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Properties.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
