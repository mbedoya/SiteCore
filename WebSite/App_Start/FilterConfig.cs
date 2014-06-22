﻿using System.Web;
using System.Web.Mvc;
using WebSite.App_Start.Filters;

namespace WebSite
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            filters.Add(new CheckAuthentication());
        }
    }
}