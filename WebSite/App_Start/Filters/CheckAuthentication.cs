using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utilities.Security;

namespace WebSite.App_Start.Filters
{
    public class CheckAuthentication : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(filterContext.HttpContext.Request.Path.ToLower().Contains("/admin/") ||
                filterContext.HttpContext.Request.Path.ToLower().EndsWith("/admin"))
            {
                if (SecurityManager.SecurityEnabled() && !SecurityManager.SesionStarted())
                {
                    filterContext.Result = new RedirectResult("~/Security/");
                }
                
            }
        }
    }
}