using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EIMS.Common;

namespace EIMS.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IRepository context)
        {
            this.context = context;
        }

        IRepository context;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            ViewBag.Message = "Your application description page.";



            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}