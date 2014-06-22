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
    public class UserroleBO : BaseUserroleBO
    {
        private static UserroleBO instance;

        public static UserroleBO GetInstance()
        {
            if(instance == null)
            {
                instance = new UserroleBO();
            }

            return instance;
        }

        public override void Create(UserroleDataModel userrole)
        {
                    
            

            if (HttpContext.Current.Session["userroleParentID"] != null)
            {
                userrole.RoleID = Convert.ToInt32(HttpContext.Current.Session["userroleParentID"]);
            }

            base.Create(userrole);
        }    

        
	 public override List<UserroleDataModel> GetAll(int id=0)
	 {
	 if(id > 0)
	 {
	  HttpContext.Current.Session["userroleParentID"] = id;
	 return GetByRole(id);
	 }else 
	 { 
	 HttpContext.Current.Session["userroleParentID"] = null;
	 return base.GetAll(id);
	 }
	 }
	 public List<UserroleDataModel> GetByRole(int id)
	 {
	 return UserroleDAL.GetByRole(id);
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
