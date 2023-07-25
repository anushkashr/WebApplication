using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.ViewModel;

namespace WebApplication3.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateUser()
        {
            UserViewModel model = new UserViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateUser(UserViewModel model)
        {
            if(ModelState.IsValid)
            {

            }
            return View(model);
        }


    }
}
