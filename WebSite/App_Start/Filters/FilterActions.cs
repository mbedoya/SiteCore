using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utilities.Log;
using Utilities.Security;

namespace WebSite.App_Start.Filters
{
    public class FilterActions : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            LogManager.GetInstance().Info("OnActionExecuting: " + filterContext.RouteData.Values["controller"].ToString() + " - " + filterContext.RouteData.Values["action"].ToString() + " - ChildAction:" + filterContext.IsChildAction.ToString());

            if(filterContext.HttpContext.Request.Path.ToLower().Contains("/admin/") ||
                filterContext.HttpContext.Request.Path.ToLower().EndsWith("/admin"))
            {
                if (SecurityManager.SecurityEnabled() && !SecurityManager.SesionStarted() || 
                    SecurityManager.SecurityEnabled() && SecurityManager.SesionStarted() && SecurityManager.GetLoggedUser().Role != UserRole.Admin)
                {
                    filterContext.Result = new RedirectResult("~/Security/");
                }
            }

            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            LogManager.GetInstance().Info("OnActionExecuted: " + filterContext.RouteData.Values["controller"].ToString() + " - " + filterContext.RouteData.Values["action"].ToString() + " - ChildAction:" + filterContext.IsChildAction.ToString());

            base.OnActionExecuted(filterContext);
        }
    }
}