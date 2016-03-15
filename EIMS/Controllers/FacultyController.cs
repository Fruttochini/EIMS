using EIMS.Common;
using EIMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EIMS.Controllers
{
    public class FacultyController : Controller
    {
        private IRepository context = new Repository.Repository();
		const int pageSize = 10;

        public ActionResult GetFaculties(int? id)
        {
			int page = id ?? 0;
			if (Request.IsAjaxRequest())
			{
				return PartialView("GetDaculties", GetItemsPerPage(page));
			}
			return View(GetItemsPerPage());
        }

		private object GetItemsPerPage(int page=1)
		{
			var itemToSkip = page * pageSize;
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
			return facultyList.OrderBy(f=>f.FacultyID).Skip(itemToSkip).Take(pageSize).ToList();
		}

		public ActionResult CreateFaculty(FacultyViewModel faculty)
        {
			var tmpFaculty = new FacultyCommon()
			{
				Name = faculty.Name
			};
			if (context.CreateFaculty(tmpFaculty) == true)
			{
				ViewBag.Result = "Success Added!";
				return RedirectToAction("GetFaculties", "Faculty");
			}
			else
			{
				ViewBag.Result = "Failed Adding to DataBase!";
				return View();
			}
        }

        public ActionResult EditFaculty(int id)
        {
            var faculty = context.GetFacultyByID(id);
			var tmpFaculty = new FacultyViewModel()
			{
				FacultyID = faculty.FacultyID,
				Name = faculty.Name
			};
            return View(tmpFaculty);
        }

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult EditFaculty(FacultyViewModel model)
		{
			bool IsChanged = false;
			var faculty = context.GetFacultyByID(model.FacultyID);
			var tmpFaculty = new FacultyCommon();
			if (!faculty.Name.Equals(model.Name))
			{
				tmpFaculty.Name = model.Name;
				IsChanged = true;
			}
			if (IsChanged)
			{
				tmpFaculty.FacultyID = model.FacultyID;
				context.UpdateFaculty(tmpFaculty);
			}
			return RedirectToAction("GetFaculties");
		}

        public ActionResult DeleteFaculty(int id)
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