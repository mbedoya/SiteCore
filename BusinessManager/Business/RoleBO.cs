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
    public class RoleBO : BaseRoleBO
    {
        private static RoleBO instance;

        public static RoleBO GetInstance()
        {
            if (instance == null)
            {
                instance = new RoleBO();
            }

            return instance;
        }

        public override void Create(RoleDataModel role)
        {

            if (!SecurityManager.SesionStarted())
            {
                throw new Exception("Session not started");
            }
            role.CreatedBy = SecurityManager.GetLoggedUser().ID;
            role.DateCreated = DateTime.Now;

            base.Create(role);
        }

        public override void Delete(int id)
        {
            if (!SecurityManager.SesionStarted() || SecurityManager.GetLoggedUser().Role != UserRole.Admin)
            {
                throw new Exception("Action not allowed");
            }

            base.Delete(id);
        }

    }
}
