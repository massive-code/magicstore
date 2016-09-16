using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using magicstore.Models;
using GridMvc;

namespace magicstore.Controllers
{
    public class PersonalController : Controller
    {
        public ActionResult Index()
        {
            cl_DB_Users db_Users = new cl_DB_Users();
            List<cl_Table_User> Users = db_Users.Users.ToList();
            return View(Users);
        }
    }
}