using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Hello(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                ViewBag.Message = "Hello, please enter your name. Supply it as a GET parameter. (e.g. /Hello?name=Mickey Mouse&)";
            }
            else
            {
                ViewBag.Message = "Hello " + name;
            }


            return View();
        }
    }
}