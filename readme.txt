1. Copy dlls (Website, BusinessManager, Utilities)
2. Copy web.config keys and change as neceesary
3. Install System.Web.Optimization (Install-Package Microsoft.AspNet.Web.Optimization)
4. Add UI Files (Content, Scripts, Files, Views)
5. Add Route Config
routes.MapRoute(
               name: "Administration",
               url: "admin/{controller}/{action}/{id}",
               defaults: new { controller = "ManageMenu", action = "Index", id = UrlParameter.Optional }
           );  
6. Add HomeController