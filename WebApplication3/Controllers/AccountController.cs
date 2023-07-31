using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;


namespace WebApplication3.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;


        //constructor injection
        public AccountController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
                _context = context;
                _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.Message = "Please enter email and password";
                return View();
            }

            var user = _context.Users.Where(user => user.Email == email.Trim() 
            && user.Password == password.TrimEnd()).FirstOrDefault();
            if (user == null)
            {
                ViewBag.Message = "Invalid email or password provided";
            }

            string fullName = string.Format("{0} {1}", user.FirstName, user.LastName);

            //if valid Set session
            _httpContextAccessor.HttpContext.Session.SetInt32("UserId", user.UserID);
            _httpContextAccessor.HttpContext.Session.SetString("UserName", fullName);

            //we'll pass this to HomeController's Index
            return RedirectToAction("Index", "Home");
        }
    }

}
