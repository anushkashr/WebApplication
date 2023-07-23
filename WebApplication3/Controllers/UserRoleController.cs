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
            //IEnumerable<UserRole> userRoles=_context.UserRoles;
            var userRoles = _context.UserRoles.ToList();

            return View(userRoles);
        }

        //GET
        [HttpGet] //action selector
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] 
        public IActionResult Create(UserRole role)
        {
            if(ModelState.IsValid)
            {
                _context.UserRoles.Add(role);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
        }
    }
}
