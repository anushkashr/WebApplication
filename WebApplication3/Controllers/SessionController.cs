using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;

namespace WebApplication3.Controllers
{
    public class SessionController : Controller
    {
        int counter = 0;
        public IActionResult SessionIndex()
        {
            if (HttpContext.Session.GetInt32("CounterKey") != null)
            {
                counter = (int)HttpContext.Session.GetInt32("CounterKey");
            }
           
            counter++;
            TempData["Counter"] = counter;

            HttpContext.Session.SetInt32("CounterKey", counter);
            return View();
        }
    }
}
