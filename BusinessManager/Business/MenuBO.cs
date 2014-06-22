using BusinessManager.Data;
using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using Utilities.Security;
using System.Web;

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
            if (HttpContext.Current.Session["ParentID"] != null)
            {
                menu.MenuID = Convert.ToInt32(HttpContext.Current.Session["ParentID"]);
            }

            base.Create(menu);
        }


        public override List<MenuDataModel> GetAll(int id = 0)
        {
            if (id > 0)
            {
                HttpContext.Current.Session["ParentID"] = id;
                return GetByMenu(id);
            }
            else
            {
                HttpContext.Current.Session["ParentID"] = null;
                return base.GetAll(id);
            }
        }
        public List<MenuDataModel> GetByMenu(int? id)
        {
            return MenuDAL.GetByMenu(id);
        }

        public override void Delete(int id)
        {
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

    }
}
