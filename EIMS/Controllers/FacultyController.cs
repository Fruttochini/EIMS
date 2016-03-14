using EIMS.Common;
using EIMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EIMS.Controllers
{
	public class FacultyConroller : Controller
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

		public ActionResult CreateFaculty(FacultyViewModel faculty)
		{
			CreateFaculty(faculty);
			return View(faculty);
		}

		public ActionResult UpdateFaculty(FactorViewModel faculty)
		{
			UpdateFaculty(faculty);
			return View(faculty);
		}

		public ActionResult DeleteFaculty(int id)
		{
			DeleteFaculty(id);
			return View();
		}

		public ActionResult GetFacultyByID(int id)
		{
			return View(context.GetFacultyByID(id));
		}
	}
}