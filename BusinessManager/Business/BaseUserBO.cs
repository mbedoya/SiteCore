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
    public class BaseUserBO
    {
        public virtual List<UserDataModel> GetAll(int id=0)
        {
            return UserDAL.GetAll();
        }

        public virtual UserDataModel Get(int id)
        {
            return UserDAL.Get(id);
        }

        public virtual void Update(UserDataModel user)
        {
            if (user.ID > 0)
            {
                

                UserDAL.Update(user);
            }
            else
            {
                throw new Exception("Page not found");
            }
            
        }

        public virtual void Create(UserDataModel user)
        {
            

            UserDAL.Create(user);
        }

        public virtual void Delete(int id)
        {
            UserDAL.Delete(id);
        }

        public int GetUserCount(int userID)
        {
            return UserDAL.GetUserCount(userID);
        }
    }
}