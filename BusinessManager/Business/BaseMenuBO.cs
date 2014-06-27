using BusinessManager.Data;
using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using System.Web;

namespace BusinessManager.Business
{
    public class BaseMenuBO
    {
        public virtual List<MenuDataModel> GetAll(int id=0)
        {
            return MenuDAL.GetAll();
        }

        public virtual MenuDataModel Get(int id, bool useCache = false)
        {
            return MenuDAL.Get(id);
        }

        public virtual void Update(MenuDataModel menu)
        {
            if (menu.ID > 0)
            {
                

                MenuDAL.Update(menu);
            }
            else
            {
                throw new Exception("Page not found");
            }
            
        }

        public virtual void Create(MenuDataModel menu)
        {
            

            MenuDAL.Create(menu);
        }

        public virtual void Delete(int id)
        {
            MenuDAL.Delete(id);
        }

        public int GetMenuCount(int menuID)
        {
            return MenuDAL.GetMenuCount(menuID);
        }
    }
}