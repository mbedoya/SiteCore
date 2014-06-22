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
    public class BaseRoleBO
    {
        public virtual List<RoleDataModel> GetAll(int id=0)
        {
            return RoleDAL.GetAll();
        }

        public virtual RoleDataModel Get(int id)
        {
            return RoleDAL.Get(id);
        }

        public virtual void Update(RoleDataModel role)
        {
            if (role.ID > 0)
            {
                

                RoleDAL.Update(role);
            }
            else
            {
                throw new Exception("Page not found");
            }
            
        }

        public virtual void Create(RoleDataModel role)
        {
            

            RoleDAL.Create(role);
        }

        public virtual void Delete(int id)
        {
            RoleDAL.Delete(id);
        }

        public int GetCount(int roleID)
        {
            return RoleDAL.GetCount(roleID);
        }
    }
}