using System;
using System.Collections;
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

    public class CartModel : GeneralModel
    {
        public CartModel()
        {
            CurrentPage = 1;
            Orders = new List<Order>();
        }
        public int CurrentPage { get; set; }
        public int PageLength { get; set; }
        public int PageNumber { get; set; }
        public List<Order> Orders { get; set; }
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