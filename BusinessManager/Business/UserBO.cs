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
    public class UserBO : BaseUserBO
    {
        private static UserBO instance;

        public static UserBO GetInstance()
        {
            if (instance == null)
            {
                instance = new UserBO();
            }

            return instance;
        }

        public override void Create(UserDataModel user)
        {
            if (!SecurityManager.SesionStarted())
            {
                throw new Exception("Session not started");
            }
            user.CreatedBy = SecurityManager.GetLoggedUser().ID;
            user.DateCreated = DateTime.Now;

            user.Password = EncryptionManager.MD5Encrypt(user.Password);

            base.Create(user);
        }

        public override void Update(UserDataModel user)
        {
            if (!String.IsNullOrEmpty(user.NewPassword))
            {
                user.Password = EncryptionManager.MD5Encrypt(user.NewPassword);
            }

            base.Update(user);
        }


        public override void Delete(int id)
        {
            if (!SecurityManager.SesionStarted() || SecurityManager.GetLoggedUser().Role != UserRole.Admin)
            {
                throw new Exception("Action not allowed");
            }

            base.Delete(id);
        }

        public UserDataModel CheckUser(string email, string password)
        {
            return UserDAL.CheckUser(email, EncryptionManager.MD5Encrypt(password));
        }

    }
}
