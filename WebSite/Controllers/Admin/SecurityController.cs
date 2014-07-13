using BusinessManager.Business;
using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utilities.Security;

namespace WebSite.Controllers.Admin
{
    public class SecurityController : Controller
    {
        //
        // GET: /Security/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string email, string password)
        {
            UserDataModel user = UserBO.GetInstance().CheckUser(email, password);

            if (user != null)
            {
                SecurityManager.Login(new SecurityUserModel()
                {
                    ID = user.ID,
                    Name = user.FirstName + " " + user.LastName,
                    Email = user.Email,
                    Role = !String.IsNullOrEmpty(user.Rol) && user.Rol == UserRole.Admin.ToString() ? UserRole.Admin : UserRole.Visitor
                });

                return RedirectToAction("Index", "ManageMenu");
            }
            else
            {
                ViewBag.error = true;
                return View();
            }
            
        }

    }
}
