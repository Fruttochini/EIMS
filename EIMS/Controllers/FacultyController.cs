using EIMS.Common;
using EIMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EIMS.Controllers
{
    public class FacultyController : Controller
    {
        private IRepository context = new Repository.Repository();


        public ActionResult GetFaculties()
        {
            var facultyList = new List<FacultyViewModel>();
            var dblst = context.GetFaculties();
            foreach (var fac in dblst)
            {
                FacultyViewModel tmp = new FacultyViewModel()
                {
                    FacultyID = fac.FacultyID,
                    Name = fac.Name
                };
                facultyList.Add(tmp);
            }
            return View(facultyList);
        }

        public ActionResult Create(FacultyViewModel faculty)
        {
			var tmpFaculty = new FacultyCommon()
			{
				Name = faculty.Name
			};
            if(context.CreateFaculty(tmpFaculty))
				return RedirectToAction("GetFaculties", "")
        }

        public ActionResult Edit(int id)
        {
            context.UpdateFaculty(faculty);
            return View();
        }

        public ActionResult Delete(int id)
        {
            context.DeleteFaculty(id);
            return View();
        }

        public ActionResult GetFacultyByID(int id)
        {
            return View(context.GetFacultyByID(id));
        }
    }
}