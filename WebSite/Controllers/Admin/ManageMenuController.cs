using BusinessManager.Business;
using BusinessManager.Models;
using WebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utilities.Cache;
using WebSite.WebUtilities;

namespace WebSite.Controllers.Admin
{
    public class ManageMenuController : Controller
    {
        //
        // GET: /ManageMenu/

        public ActionResult Index(int id=0)
        {
            List<MenuDataModel> menus = MenuBO.GetInstance().GetAll(id);

            string title = Misc.GetURLString("Mi Mascota, su alimentación y nosotros");

            List<MenuDataModel> menuBlogItems = MenuBO.GetInstance().GetMenuItems("MenuBlog");            

            //int count=1000000;

            //DateTime start = DateTime.Now;
            //for (int i = 1; i <= count; i++)
            //{
            //    MenuDataModel m = new MenuDataModel();
            //    m.ID = i;
            //    m.Name = menus[0].Name;
            //    m.MenuOrder = menus[0].MenuOrder;

            //    cache.AddObject<MenuDataModel>(m);                
            //}            

            //DateTime end = DateTime.Now;
            //System.IO.File.AppendAllText(@"C:\Temp\Diff.txt", count.ToString() + " Difference to Add " + Misc.GetDateDifferenceInMiliseconds(start, end) + " \r\n");

            //start = DateTime.Now;
            //for (int i = 1; i <= count; i++)
            //{
            //    int second = 0;
            //    MenuDataModel cachedMenu = cache.GetObject<MenuDataModel>(i + second);
            //    if (cachedMenu == null)
            //    {
            //        menus[0].ID = i + second;
            //        cache.AddObject<MenuDataModel>(menus[0]);
            //    }
            //}
            //end = DateTime.Now;
            //System.IO.File.AppendAllText(@"C:\Temp\Diff.txt", count.ToString() + " Difference to Get " + Misc.GetDateDifferenceInMiliseconds(start, end) + " \r\n");

            return View(menus);
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
