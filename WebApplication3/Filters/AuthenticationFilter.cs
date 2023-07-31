using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication3.Filters;

public class AuthenticationFilter: ActionFilterAttribute
{
    //action method execute huna agadi we need to check if session's value is there or not
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if(context.HttpContext.Session.GetInt32("UserId")==null)
        {
            string returnURL = context.HttpContext.Request.Path+context.HttpContext.Request.QueryString;

            //If session is null redirect it to Login page
            context.Result = new RedirectToRouteResult(new RouteValueDictionary
            {
                {"Controller", "Account"},
                {"Action", "Login" },
                {"returnURL", returnURL },
                {"errorMessage", "Invalid Attempt to Access the page" }

            });
        }
    }

}
