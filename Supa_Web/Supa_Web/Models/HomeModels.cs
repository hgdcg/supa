using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Supa_Web.Models
{
    public class IndexModel
    {
        public IndexModel()
        {
           Types1 = new List<Types1>();
           Types2 = new List<Types2>();
           Types3 = new List<Types3>();
        }
        public List<Types1> Types1 { get; set; }
        public List<Types2> Types2 { get; set; }
        public List<Types3> Types3 { get; set; }
    }
    public class GoodsListModel
    {
        public GoodsListModel()
        {
            Types1 = new List<Types1>();
            Types2 = new List<Types2>();
            Types3 = new List<Types3>();
            Good = new List<Good>();
            Prices = new List<double>();
            CurrentPage = 1;
            PageLength = 5;
        }
        public List<Types1> Types1 { get; set; }
        public List<Types2> Types2 { get; set; }
        public List<Types3> Types3 { get; set; }
        public List<Good> Good { get; set; }
        public List<double> Prices { get; set; }
        public int CurrentPage { get; set; }
        public int PageLength { get; set; }
        public int PageNumber { get; set; }
        public String TypeName { get; set; }
    }
}