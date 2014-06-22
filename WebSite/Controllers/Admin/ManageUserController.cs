using BusinessManager.Business;
using BusinessManager.Models;
using WebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers.Admin
{
    public class ManageUserController : Controller
    {
        //
        // GET: /ManageUser/

        public ActionResult Index(int id=0)
        {
            return View(UserBO.GetInstance().GetAll(id));
        }

        public ActionResult Edit(int id)
        {
            return View(UserBO.GetInstance().Get(id));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(UserDataModel user)
        {
            UserBO.GetInstance().Update(user);

            if (Session["userParentID"] != null)
            {
                return RedirectToAction("Index", new { id = Convert.ToInt32(Session["userParentID"]) });
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(UserDataModel user)
        {
            UserBO.GetInstance().Create(user);

            if (Session["userParentID"] != null)
            {
                return RedirectToAction("Index", new { id = Convert.ToInt32(Session["userParentID"]) });
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            UserBO.GetInstance().Delete(id);

            return Json(new { success=true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UserChildrenField(int id)
        {
            int count = UserBO.GetInstance().GetUserCount(id);

            ChildrenFieldUIModel model = new ChildrenFieldUIModel()
            {
                ID = id,
                Count = count,
                ClassName = "User"
            };

            return View("ChildrenField", model);
        }
    }
}
