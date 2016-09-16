using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using magicstore.Models;

namespace magicstore.Controllers
{
    public class RegistrationController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(String name, String surname, String login, String address, String email, String password)
        {
            login = login.ToLower();
            email = email.ToLower();
            cl_DB_Users db_Users = new cl_DB_Users();
            cl_Cryptography l_Crypto = new cl_Cryptography();
            cl_Table_User l_UserExist = db_Users.Users.FirstOrDefault(User => User.Login == login || User.EMail == email);
            Object s_Data = null;
            if (l_UserExist == null)
            {
                cl_Table_User l_User = new cl_Table_User()
                {
                    Name = name,
                    Surname = surname,
                    Login = login,
                    Address = address,
                    EMail = email,
                    Password = l_Crypto.ps_MD5(password),
                    UID = Guid.NewGuid(),
                    Permission = "user",
                    Blocked = false,
                    EMailConfirm = false,
                    LastIn = DateTime.Now,
                    Registration = DateTime.Now
                };

                db_Users.Users.Add(l_User);
                db_Users.SaveChanges();
                s_Data = "registration_success";
            }
            else
            {
                s_Data = "registration_failed";
            }
            return RedirectToAction("Index", "Information", new { s_Data });
        }
    }
}