using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ImperialRegister.Security
{
    public class AuthorizationFilter : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["username"] == null)
            {
                //filterContext.Result = new HttpUnauthorizedResult();
                filterContext.Result = new RedirectToRouteResult(
                                       new RouteValueDictionary
                                       {
                                           { "action", "Index" },
                                           { "controller", "Home" }
                                       });
            }
        }
    }
}