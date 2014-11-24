using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Supa_Web.Models
{
    public class LogInModel
    {
        public String UserName { get; set; }
        public String Password { get; set; }
        public Boolean RememberMe { get; set; }
    }

    public class ChangePasswordModel
    {
        public String OldPassword { get; set; }
        public String NewPassword { get; set; }
    }

    public class RegisterModel
    {
        public String UserName { get; set; }
        public String Password { get; set; }
    }
    public class SetPasswordModel
    {
        public String Password { get; set; }
    }
}