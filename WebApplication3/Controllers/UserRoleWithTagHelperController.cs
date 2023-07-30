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
            //ViewBag.Message = "Hello from Index View using ViewBag";
            //ViewData["Message"] = "Hello from Index View using ViewData";

            IEnumerable<UserRole> roles=_context.UserRoles.ToList();
            return View(roles);
        }
        [HttpGet]
        public IActionResult CreateRole() 
        { 
            return View();
        }


        [HttpPost]
        public IActionResult CreateRole(UserRole model)
        {
            if(ModelState.IsValid)
            {
                _context.UserRoles.Add(model);
                _context.SaveChanges();

                int lastId = model.RoleID;
                if (lastId > 0)
                {
                    return RedirectToAction("Index");
                }
            }
           
            return View(model);
        }

        public IActionResult EditRole(int? roleID)
        {
            if(roleID == null)
            {
                return NotFound();
            }

            //find user role by id
            var userRole = _context.UserRoles.Where(role => role.RoleID == roleID).FirstOrDefault();


            return View(userRole);
        }
        [HttpPost]
        public IActionResult UpdateRole(UserRole model)
        {
            if (ModelState.IsValid)
            {
                var currentRole = _context.UserRoles.Find(model.RoleID);    //directly using Update method is bad practice

                if (currentRole != null)
                {
                    currentRole.RoleName = model.RoleName;
                    currentRole.RoleDesc = model.RoleDesc;

                    _context.UserRoles.Update(currentRole);
                    _context.SaveChanges();

                    ViewBag.Message = "Role updated successfully";
                    ViewData["Message"] = "Role updated successfully";
                    TempData["Message"] = "Role updated successfully";

                    return RedirectToAction("Index");
                }

            }
            return View(model);

        }

        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userRole = _context.UserRoles.Where(y => y.RoleID == id).FirstOrDefault();
            return View(userRole);
        }


        public IActionResult DeleteRole(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var currentRole=_context.UserRoles.Where(x=> x.RoleID == id).FirstOrDefault();
            if(currentRole != null)
            {
                _context.UserRoles.Remove(currentRole);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
