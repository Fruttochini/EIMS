using EIMS.Common;
using EIMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EIMS.Controllers
{
    public class SubjectController : Controller
    {
        IRepository context;

        public SubjectController()
        {
            context = new Repository.Repository();
        }
        // GET: Subject
        public ActionResult GetSubjectList()
        {
            var subjList = context.GetSubjects();
            return View(subjList);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}