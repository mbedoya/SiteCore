using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BusinessManager.Models
{
    public class UserDataModel
    {

        public int? ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
        public int? CreatedBy { get; set; }
        public string NewPassword { get; set; }

        public string Name 
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}