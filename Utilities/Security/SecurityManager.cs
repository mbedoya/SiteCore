using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;

namespace Utilities.Security
{
    public class SecurityManager
    {
        public static bool SesionStarted()
        {
            if (SecurityEnabled())
            {
                if (HttpContext.Current.Session["SecurityAuth"] != null &&
                Convert.ToBoolean(HttpContext.Current.Session["SecurityAuth"]))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }            
        }

        public static bool SecurityEnabled()
        {
            if (ConfigurationManager.AppSettings["SecurityEnabled"] != null &&
                Convert.ToBoolean(ConfigurationManager.AppSettings["SecurityEnabled"]))
            {
                return true;
            }
            else
            {
                return false;
            }            
        }

        public static void Login(SecurityUserModel user)
        {
            HttpContext.Current.Session["SecurityAuthUser"] = user;
            HttpContext.Current.Session["SecurityAuth"] = true;
        }

        public static void Logout()
        {
            HttpContext.Current.Session["SecurityAuth"] = null;
            HttpContext.Current.Session["SecurityAuthUser"] = null;
        }

        public static SecurityUserModel GetLoggedUser()
        {
            if (SecurityEnabled())
            {
                if (HttpContext.Current.Session["SecurityAuthUser"] != null)
                {
                    return (SecurityUserModel)HttpContext.Current.Session["SecurityAuthUser"];
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return GetMockUser();
            }
        }

        private static SecurityUserModel GetMockUser()
        {
            return new SecurityUserModel()
            {
                ID = 1,
                Name = "Mauricio",
                Email = "mauro",
                Role =  UserRole.Admin
            };
        }
    }
}
