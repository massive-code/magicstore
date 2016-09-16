using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using magicstore.Models;

namespace magicstore.Controllers
{
    public class InformationController : Controller
    {
        public ActionResult Index(String s_Data)
        {
            cl_Information l_Info = new cl_Information();
            ViewBag.Information_Data = l_Info.Information(s_Data);
            return View();
        }
    }
}