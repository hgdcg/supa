using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Supa_Web.Models
{
    public class LogInModel : GeneralModel
    {
        public String UserName { get; set; }
        public String Password { get; set; }
    }

    public class ChangePasswordModel : GeneralModel
    {
        public String OldPassword { get; set; }
        public String NewPassword { get; set; }
    }

    public class RegisterModel : GeneralModel
    {
        public String UserName { get; set; }
        public String Password { get; set; }
    }
    public class SetPasswordModel : GeneralModel
    {
        public String Password { get; set; }
    }
}