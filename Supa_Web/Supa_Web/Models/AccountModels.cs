﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Supa_Web.Models
{
    public class LogInModel
    {
        public String UserName { get; set; }
        public String Password { get; set; }
    }

    public class CartModel
    {
        public CartModel()
        {
            CurrentPage = 1;
            PageLength = 15;
            Orders = new List<Order>();
        }
        public int CurrentPage { get; set; }
        public int PageLength { get; set; }
        public int PageNumber { get; set; }
        public List<Order> Orders { get; set; }
    }

    public class RegisterModel
    {
        public String UserName { get; set; }
        public String Password { get; set; }
    }
}