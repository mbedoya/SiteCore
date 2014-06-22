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
    public class ManageUserroleController : Controller
    {
        //
        // GET: /ManageUserrole/

        public ActionResult Index(int id=0)
        {
            return View(UserroleBO.GetInstance().GetAll(id));
        }

        public ActionResult Edit(int id)
        {
            return View(UserroleBO.GetInstance().Get(id));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(UserroleDataModel userrole)
        {
            UserroleBO.GetInstance().Update(userrole);

            if (Session["userroleParentID"] != null)
            {
                return RedirectToAction("Index", new { id = Convert.ToInt32(Session["userroleParentID"]) });
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
        public ActionResult Create(UserroleDataModel userrole)
        {
            UserroleBO.GetInstance().Create(userrole);

            if (Session["userroleParentID"] != null)
            {
                return RedirectToAction("Index", new { id = Convert.ToInt32(Session["userroleParentID"]) });
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            UserroleBO.GetInstance().Delete(id);

            return Json(new { success=true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ChildrenField(int id)
        {
            int count = UserroleBO.GetInstance().GetCount(id);

            ChildrenFieldUIModel model = new ChildrenFieldUIModel()
            {
                ID = id,
                Count = count,
                ClassName = ""
            };

            return View("ChildrenField", model);
        }
    }
}
