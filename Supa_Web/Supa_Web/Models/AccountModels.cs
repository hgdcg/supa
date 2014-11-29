using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Supa_Web.Models
{
    public class LogInModel
    {
        [Required(ErrorMessage = "用户名不能为空")]
        public String UserName { get; set; }
        [Required(ErrorMessage = "密码不能为空")]
        public String Password { get; set; }
    }

    public class CartModel
    {
        public CartModel()
        {
            CurrentPage = 1;
            PageLength = 5;
            TotalAmount = 0;
            Orders = new List<Order>();
            GoodNames = new List<String>();
        }
        public int CurrentPage { get; set; }
        public int PageLength { get; set; }
        public int PageNumber { get; set; }
        public double TotalAmount { get; set; }
        public List<Order> Orders { get; set; }
        // We need this because we cannot dive deep in View
        public List<String> GoodNames { get; set; }
    }

    public class RegisterModel
    {
        [Required(ErrorMessage = "用户名不能为空")]
        public String UserName { get; set; }
        [Required(ErrorMessage = "密码不能为空")]
        public String Password { get; set; }
        [Compare("Password", ErrorMessage = "确认密码与密码不相符")]
        public String ConfirmPassword { get; set; }
    }

    public class ChangePasswordModel{
        [Required(ErrorMessage = "旧密码不能为空")]
        public String OldPassword { get; set; }
        [Required(ErrorMessage = "新密码不能为空")]
        public String NewPassword { get; set; }
        [Compare("NewPassword", ErrorMessage = "确认密码与密码不相符")]
        public String ConfirmPassword { get; set; }
    }
}