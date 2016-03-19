using EIMS.Common;
using EIMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EIMS.Controllers
{
    public class CourseFillController : Controller
    {
		private IRepository context = new Repository.Repository();
		const int pageSize = 25;

		public ActionResult Index(int courseID)
        {
            return View(GetItemsPerPage(courseID));
        }

		public ActionResult GetCourseFill(int courseID, int? id)
		{
			int page = id ?? 0;
			if (Request.IsAjaxRequest())
			{
				return PartialView("GetCourseFill", GetItemsPerPage(courseID, page));
			}
			return PartialView(GetItemsPerPage(courseID));
		}

		public object GetItemsPerPage(int courseID, int page=0)
		{
			var itemToSkip = page * pageSize;
			var subjectByCoursList = new List<CourseFillList>();
			var courseFill = new CourseFillViewModel();
			var dbLst = context.GetCourseFillByCourse(courseID);
			foreach(var item in dbLst)
			{
				CourseFillList cf = new CourseFillList()
				{
					courseFillID = item.courseFillID,
					courseID = item.courseID,
					subjectID = item.subjectID,
					subjectName = item.subjectName,
					SubjectHoursPerWeek = item.SubjectHoursPerWeek
				};
				subjectByCoursList.Add(cf);
			}
			var tmpCourse = context.GetCourseByID(courseID);
			CourseViewModel cvm = new CourseViewModel()
			{
				CourseID = tmpCourse.CourseID,
				CourseName = tmpCourse.CourseName
			};
			courseFill.SelectCourse = cvm;
			courseFill.subjectList = subjectByCoursList.OrderBy(cf => cf.courseFillID).Skip(itemToSkip).Take(pageSize).ToList();
			return courseFill;
		}

		public ActionResult CreateCourseFill(int id)
		{
			var dbSubject = context.GetSubjects().Select(x => new SelectListItem() { Text = x.SubjectName, Value = x.SubjectID.ToString() }).ToList();
			CreateEditCourseFillViewModel model = new CreateEditCourseFillViewModel()
			{
				courseID = id,
				SubjectList = dbSubject,
			};
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult CreateCourseFill(CreateEditCourseFillViewModel model)
		{
			if (ModelState.IsValid)
			{
				var tmpCourseFill = new Common.CourseFill()
				{
					courseID = model.courseID,
					subjectID = model.subjectID,
					SubjectHoursPerWeek = model.SubjectHoursPerWeek
				};
				if (context.CreateCourseFill(tmpCourseFill) == true)
				{
					return RedirectToAction("Index", new { courseID = model.courseID });
				}
				else
				{
					return View();
				}
			}
			return View(model);
		}

		public ActionResult EditCourseFill(int courseFillID)
		{
			var courseFill = context.GetCoursFillByID(courseFillID);
			var dbSubject = context.GetSubjects().Select(x => new SelectListItem() { Text = x.SubjectName, Value = x.SubjectID.ToString() }).ToList();
			var tmpCourseFill = new CreateEditCourseFillViewModel()
			{
				courseFillID = courseFill.courseFillID,
				courseID = courseFill.courseID,
				SubjectHoursPerWeek = courseFill.SubjectHoursPerWeek,
				SubjectList = dbSubject
			};
			return View(tmpCourseFill);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditCourseFill(CreateEditCourseFillViewModel model)
		{
			bool IsChanged = false;
			var courseFill = context.GetCoursFillByID(model.courseFillID);
			var tmpCourseFill = new Common.CourseFill();
			if(!courseFill.subjectID.Equals(model.subjectID))
			{
				tmpCourseFill.subjectID = model.subjectID;
				IsChanged = true;
			}
			if(!courseFill.SubjectHoursPerWeek.Equals(model.SubjectHoursPerWeek))
			{
				tmpCourseFill.SubjectHoursPerWeek = model.SubjectHoursPerWeek;
				IsChanged = true;
			}
			if (IsChanged)
			{
				tmpCourseFill.courseFillID = model.courseFillID;
				tmpCourseFill.courseID = model.courseID;
				tmpCourseFill.subjectID = model.subjectID;
				context.UpdateCourseFill(tmpCourseFill);
			}
			return RedirectToAction("Index", new { courseID = model.courseID });
		}

		public ActionResult DeleteCourseFill(int courseFillID)
		{
			var model = context.GetCoursFillByID(courseFillID);
			if(context.DeleteCourseFill(courseFillID) == true)
				return RedirectToAction("Index", new { courseID = model.courseID });
			return View();
		}
	}
}