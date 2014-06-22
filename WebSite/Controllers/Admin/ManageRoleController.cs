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
    public class ManageRoleController : Controller
    {
        //
        // GET: /ManageRole/

        public ActionResult Index(int id=0)
        {
            return View(RoleBO.GetInstance().GetAll(id));
        }

        public ActionResult Edit(int id)
        {
            return View(RoleBO.GetInstance().Get(id));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(RoleDataModel role)
        {
            RoleBO.GetInstance().Update(role);

            if (Session["roleParentID"] != null)
            {
                return RedirectToAction("Index", new { id = Convert.ToInt32(Session["roleParentID"]) });
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
        public ActionResult Create(RoleDataModel role)
        {
            RoleBO.GetInstance().Create(role);

            if (Session["roleParentID"] != null)
            {
                return RedirectToAction("Index", new { id = Convert.ToInt32(Session["roleParentID"]) });
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            RoleBO.GetInstance().Delete(id);

            return Json(new { success=true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UserroleChildrenField(int id)
        {
            int count = RoleBO.GetInstance().GetUserroleCount(id);

            ChildrenFieldUIModel model = new ChildrenFieldUIModel()
            {
                ID = id,
                Count = count,
                ClassName = "Userrole"
            };

            return View("ChildrenField", model);
        }
    }
}
