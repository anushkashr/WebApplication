using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class UserRoleWithTagHelperController : Controller
    {

        public readonly ApplicationDbContext _context;
        public UserRoleWithTagHelperController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<UserRole> roles=_context.UserRoles.ToList();
            return View(roles);
        }
        public IActionResult CreateRole()
        {
            return View();
        }

        public IActionResult SaveRole(UserRole model)
        {
            _context.UserRoles.Add(model);
            _context.SaveChanges();

            int lastId = model.RoleID;
            if(lastId>0)
            {
                return RedirectToAction("Index");
            }

            return View("CreateRole");
        }
    }
}
