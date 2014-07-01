using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utilities.Cache;

namespace WebSite.Controllers.Admin
{
    public class ManageCacheController : Controller
    {
        //
        // GET: /ManageCache/

        public ActionResult Index()
        {
            return View(CacheManager.GetInstance().GetCollectionObjects());
        }

        public ActionResult Delete(string id)
        {
            CacheManager.GetInstance().RemoveObject(id);

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

    }
}
