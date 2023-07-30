using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;

namespace WebApplication3.Controllers
{
    public class StateManagementController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StateManagementController(ApplicationDbContext context)
        {
            _context = context;
        }

        int counter = 0;
        public IActionResult Index()
        {
            //counter++;

            //view bata counter directly access garna mildaina so, using ViewBag
            //so that we can pass counter(can be a message or data) to view from controller
            ViewBag.UserRole = _context.UserRoles;

            ViewBag.SingleUserRole = _context.UserRoles.FirstOrDefault();
            return View();
        }
    }
}
