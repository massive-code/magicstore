using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace magicstore.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        public ActionResult image_slider()
        {
            return View();
        }
        public ActionResult fixed_menu()
        {
            return View();
        }
    }
}