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
    public class ManageMenuController : Controller
    {
        //
        // GET: /ManageMenu/

        public ActionResult Index(int id=0)
        {
            return View(MenuBO.GetInstance().GetAll(id));
        }

        public ActionResult Edit(int id)
        {
            return View(MenuBO.GetInstance().Get(id));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(MenuDataModel menu)
        {
            MenuBO.GetInstance().Update(menu);

            if (Session["menuParentID"] != null)
            {
                return RedirectToAction("Index", new { id = Convert.ToInt32(Session["menuParentID"]) });
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
        public ActionResult Create(MenuDataModel menu)
        {
            MenuBO.GetInstance().Create(menu);

            if (Session["menuParentID"] != null)
            {
                return RedirectToAction("Index", new { id = Convert.ToInt32(Session["menuParentID"]) });
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            MenuBO.GetInstance().Delete(id);

            return Json(new { success=true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult MenuChildrenField(int id)
        {
            int count = MenuBO.GetInstance().GetMenuCount(id);

            ChildrenFieldUIModel model = new ChildrenFieldUIModel()
            {
                ID = id,
                Count = count,
                ClassName = "Menu"
            };

            return View("ChildrenField", model);
        }
    }
}
