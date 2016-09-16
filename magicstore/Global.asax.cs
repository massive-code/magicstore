using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using magicstore.Models;

namespace magicstore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            prv_CreateDB();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start()
        {
            CheckUserAuthorization();
        }
        private void prv_CreateDB()
        {
            cl_DB_Users db_Users = new cl_DB_Users();
            if (db_Users.Database.Exists() == false)
            {
                db_Users.Database.Create();
                cl_Cryptography Crypto = new cl_Cryptography();
                cl_Table_User User = new cl_Table_User()
                {
                    Login = "Administrator".ToLower(),
                    EMail = "support@massivecode.ru".ToLower(),
                    EMailConfirm = true,
                    Address = "null",
                    Name = "Артур",
                    Surname = "Хусаинов",
                    Password = Crypto.ps_MD5("123"),
                    UID = Guid.NewGuid(),
                    Permission = "administrator",
                    Blocked = false,
                    Registration = DateTime.Now,
                    LastIn = DateTime.Now
                };
                db_Users.Users.Add(User);
                db_Users.SaveChanges();
            }

        }
        public void CheckUserAuthorization()
        {
            Session["Authorization"] = false;
            HttpCookie l_Cookie = Request.Cookies["UserUID"];
            if (l_Cookie == null)
            {
                Session["Authorization"] = false;
                Session["User"] = null;
            }
            else
            {
                cl_DB_Users db_Users = new cl_DB_Users();
                cl_Table_User l_User = db_Users.Users.FirstOrDefault(User => User.UID.ToString() == l_Cookie.Value);
                if (l_User != null)
                {
                    cl_User CurrentUser = new cl_User() { Name = l_User.Name, Surname = l_User.Surname, Login = l_User.Login, UID = l_User.UID, Address = l_User.Address, EMail = l_User.EMail, Permission = l_User.Permission };
                    Session["User"] = CurrentUser;
                    l_Cookie.Expires = DateTime.Now.AddHours(6);
                    Response.Cookies.Add(l_Cookie);
                    Session["Authorization"] = true;
                }
            }
        }
    }
}
