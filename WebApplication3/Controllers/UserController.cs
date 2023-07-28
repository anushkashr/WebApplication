using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.ViewModel;


namespace WebApplication3.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
               _context = context;
        }
        public IActionResult Index()
        {
            var _users = _context.Users.ToList();

            //Joining User and UseRole table to get the Role name
            var userWithRole = from u in _context.Users
                               join r in _context.UserRoles 
                               on u.RoleID equals r.RoleID
                               select new UserViewModel()
                               {
                                   UserID = u.UserID,
                                   RoleID = r.RoleID,
                                   FirstName = u.FirstName,
                                   LastName = u.LastName,
                                   Email = u.Email,
                                   Age = u.Age,
                                   UserRole = new UserRole()
                                   {
                                       RoleID = u.RoleID,
                                       RoleName=r.RoleName,
                                       RoleDesc = r.RoleDesc,
                                   }
                               };

            return View(userWithRole);
        }

        public IActionResult CreateUser()
        {
            UserViewModel model = new UserViewModel();

            //to bind User Roles in te drop down 
            model.UserRoles = GetUserRoles();
            //here UserRoles is of Enumerable type so we cannot do any CRUD operations, it is readonly
            //so above we used .ToList() after we provided Text and value to the drop down functionality 

            return View(model);
        }

        [HttpPost]
        public IActionResult CreateUser(UserViewModel model)
        {
            if(ModelState.IsValid)
            {
                //after creating new user, to map new user to DbSet User
                User _user = new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password,
                    Age = model.Age,
                    RoleID = Convert.ToInt32(model.RoleID),
                    Dob = Convert.ToDateTime(model.Dob),
                };

                _context.Users.Add(_user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            model.UserRoles = GetUserRoles();
            return View(model);
        }

        private List<SelectListItem> GetUserRoles()
        {
            var userRoles = _context.UserRoles.Select(roles => new SelectListItem()
            {
                Text = roles.RoleName,
                Value = roles.RoleID.ToString(),
            }).ToList();

            //To insert "Select by User Role" in the USer Role drop down
            userRoles.Insert(0, new SelectListItem()
            {
                Text = "Select User Role",
                Value = ""
            });
            return userRoles;
        }
    }
}
