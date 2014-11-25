using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Supa_Web.Models
{
    public class GeneralModel
    {
        public GeneralModel()
        {
            LogInState = false;
            UserName = String.Empty;
        }
        public Boolean LogInState { set; get; }
        public String UserName { set; get; }
    }
}