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
    public class BaseUserroleBO
    {
        public virtual List<UserroleDataModel> GetAll(int id=0)
        {
            return UserroleDAL.GetAll();
        }

        public virtual UserroleDataModel Get(int id)
        {
            return UserroleDAL.Get(id);
        }

        public virtual void Update(UserroleDataModel userrole)
        {
            if (userrole.RoleID > 0 && userrole.UserID > 0)
            {               

                UserroleDAL.Update(userrole);
            }
            else
            {
                throw new Exception("Page not found");
            }
            
        }

        public virtual void Create(UserroleDataModel userrole)
        {
            

            UserroleDAL.Create(userrole);
        }

        public virtual void Delete(int id)
        {
            UserroleDAL.Delete(id);
        }

        public int GetCount(int userroleID)
        {
            return UserroleDAL.GetCount(userroleID);
        }
    }
}