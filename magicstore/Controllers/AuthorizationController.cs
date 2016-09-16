using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using magicstore.Models;

namespace magicstore.Controllers
{
    public class AuthorizationController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult In(String Login, String Password)
        {
            cl_DB_Users db_Users = new cl_DB_Users();
            cl_Cryptography l_Crypto = new cl_Cryptography();
            Password = l_Crypto.ps_MD5(Password);
            cl_Table_User l_User = db_Users.Users.FirstOrDefault(User => User.Login == Login && User.Password == Password && User.Blocked == false);
            if (l_User != null)
            {
                l_User.LastIn = DateTime.Now;
                db_Users.SaveChanges();

                cl_User CurrentUser = new cl_User() { Name = l_User.Name, Surname = l_User.Surname, Login = l_User.Login, UID = l_User.UID, Address = l_User.Address, EMail = l_User.EMail, Permission = l_User.Permission,};
                Session["User"] = CurrentUser;
                HttpCookie l_Cookie = new HttpCookie("UserUID", CurrentUser.UID.ToString());
                l_Cookie.Expires = DateTime.Now.AddHours(6);
                Response.Cookies.Add(l_Cookie);
                Session["Authorization"] = true;
                Object s_Data = "sign_in_success";
                return RedirectToAction("Index", "Information", new { s_Data });
            }
            else
            {
                Object s_Data = "sign_in_failed";
                return RedirectToAction("Index", "Information", new { s_Data });
            }

        }
        public ActionResult Out(String ID)
        {
            if (Session["User"] != null && (Session["User"] as cl_User).UID.ToString() == ID)
            {
                Session["User"] = new cl_User();
                Session["Authorization"] = false;
                HttpCookie l_Cookie = Request.Cookies["UserUID"];
                l_Cookie.Expires = DateTime.Now.AddHours(-1);
                Response.Cookies.Add(l_Cookie);
                Object s_Data = "sign_out_success";
                return RedirectToAction("Index", "Information", new { s_Data });
            }
            else
            {
                Object s_Data = "sign_out_failed";
                return RedirectToAction("Index", "Information", new { s_Data });
            }
        }
    }
}