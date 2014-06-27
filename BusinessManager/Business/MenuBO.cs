using BusinessManager.Data;
using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using Utilities.Security;
using System.Web;
using Utilities.Cache;

namespace BusinessManager.Business
{
    public class MenuBO : BaseMenuBO
    {
        private static MenuBO instance;

        public static MenuBO GetInstance()
        {
            if (instance == null)
            {
                instance = new MenuBO();
            }

            return instance;
        }


        public override void Create(MenuDataModel menu)
        {
            if (HttpContext.Current.Session["menuParentID"] != null)
            {
                menu.MenuID = Convert.ToInt32(HttpContext.Current.Session["menuParentID"]);
            }

            base.Create(menu);
        }

        public override List<MenuDataModel> GetAll(int id = 0)
        {
            if (id > 0)
            {
                HttpContext.Current.Session["menuParentID"] = id;
                return GetByMenu(id);
            }
            else
            {
                HttpContext.Current.Session["menuParentID"] = null;
                return base.GetAll(id);
            }
        }

        public override MenuDataModel Get(int id, bool useCache = false)
        {
            if (useCache)
            {
                CacheManager cache = CacheManager.GetInstance();
                MenuDataModel item = cache.GetObject<MenuDataModel>(id);
                if (item == null)
                {
                    item = base.Get(id);
                    cache.AddObject<MenuDataModel>(item);
                }
                return item;
            }

            return base.Get(id);
        }

        public List<MenuDataModel> GetByMenu(int? id)
        {
            return MenuDAL.GetByMenu(id);
        }

        public override void Update(MenuDataModel menu)
        {
            CacheManager cache = CacheManager.GetInstance();
            cache.UpdateObject<MenuDataModel>(menu);

            base.Update(menu);
        }

        public override void Delete(int id)
        {
            CacheManager cache = CacheManager.GetInstance();
            cache.RemoveObject<MenuDataModel>(id);

            if (!SecurityManager.SesionStarted() || SecurityManager.GetLoggedUser().Role != UserRole.Admin)
            {
                throw new Exception("Action not allowed");
            }

            base.Delete(id);
        }

        public List<MenuDataModel> GetParentMenus()
        {
            return MenuDAL.GetParentMenus();
        }

        public List<MenuDataModel> GetMenuItems(string menuName)
        {
            CacheManager cache = CacheManager.GetInstance();
            List<MenuDataModel> list = cache.GetObject<MenuDataModel>("Menu_" + menuName);
            if (list == null)
            {
                list = MenuDAL.GetMenuItems(menuName);
                cache.AddObject("Menu_" + menuName, list);
            }

            return list;
        }

    }
}
