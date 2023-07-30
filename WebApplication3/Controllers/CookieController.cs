using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    public class CookieController : Controller
    {
        public IActionResult CreateCookie()
        {
            //cookie server bata client lai dirako
            this.HttpContext.Response.Cookies.Append("MyCookieKey", "Hello World!",
                //CookieOptions can set certain parameters
                new CookieOptions()
                {
                    Expires = DateTime.Now.AddSeconds(30)
                });
            return Content("Cookie created successfully");
        }

        public IActionResult GetCookie() 
        {
            string cookieValue = "";
            if(this.HttpContext.Request.Cookies.ContainsKey("MyCookieKey"))
            {
                cookieValue = this.HttpContext.Request.Cookies["MyCookieKey"].ToString();
            }
            return Content(cookieValue);
        }
    }
}
