using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class UserRoleController : Controller
    {
        private readonly ApplicationDbContext _context;

        //constructor
        public UserRoleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<UserRole> userRoles=_context.UserRoles;

            return View(userRoles);
        }
    }
}
