using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
