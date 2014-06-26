using BusinessManager.Business;
using BusinessManager.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utilities.Cache;
using WebSite.Models;

namespace WebSite.Controllers.Admin
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Menu()
        {
            List<MenuDataModel> menus = MenuBO.GetInstance().GetParentMenus();
            List<MenuUIModel> model = new List<MenuUIModel>();
            foreach (var item in menus)
            {
                model.Add(new MenuUIModel()
                {
                    Item = item
                    ,Children = MenuBO.GetInstance().GetByMenu(item.ID)
                });
            }

            return View(model);
        }

        public ActionResult FileDisplay(string url)
        {
            FileUIModel model = new FileUIModel();
            model.URL = url;

            return View(model);
        }

        public ActionResult ForeignKeyDisplay(string fieldName, int? fieldValue, string primaryTable, bool readOnly)
        {            
            Type t = Type.GetType("BusinessManager.Business." + primaryTable + "BO, BusinessManager_Core");
            List<BaseUIModel> list = null;

            if (t != null)
            {
                object instance = t.GetMethod("GetInstance").Invoke(null, null);
                object[] parametersArray = new object[] { 0 };
                var collection = (IEnumerable)t.GetMethod("GetAll").Invoke(instance, parametersArray);

                list = new List<BaseUIModel>();


                foreach (var item in collection)
                {
                    list.Add(new BaseUIModel()
                    {
                        ID = Convert.ToInt32(item.GetType().GetProperty("ID").GetValue(item, null)),
                        Name = Convert.ToString(item.GetType().GetProperty("Name").GetValue(item, null))
                    });
                }
            }            

            ForeignKeyUIModel model = new ForeignKeyUIModel();
            model.Value = fieldValue;
            model.Collection = list;
            model.Name = fieldName;
            model.ReadOnly = readOnly;

            return View(model);
        }
    }
}
