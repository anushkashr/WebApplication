using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
