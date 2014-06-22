using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities.Security
{
    public enum UserRole
        {
            Admin,
            Visitor
        }

    public class SecurityUserModel
    {
        public int? ID { get; set; }
        public string  Name { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
    }
}
