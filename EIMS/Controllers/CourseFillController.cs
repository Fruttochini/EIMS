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
			var courseFillList = new List<CourseFillViewModel>();
			var dbLst = context.GetCourseFillByCourse(courseID);
			foreach(var item in dbLst)
			{
				CourseFillViewModel cfvm = new CourseFillViewModel()
				{

					courseID=item.courseID,
					subjectID=item.subjectID,
					courseName=item.courseName,
					subjectName=item.subjectName,
					SubjectHoursPerWeek=item.SubjectHoursPerWeek,
				};
				courseFillList.Add(cfvm);
			}
			return courseFillList.OrderBy(cf => cf.courseID).Skip(itemToSkip).Take(pageSize).ToList();
		}

		public ActionResult CreateCourseFill()
		{
			var dbSubject = context.GetSubjects().Select(x => new SelectListItem() { Text = x.SubjectName, Value = x.SubjectID.ToString() }).ToList();
			var dbCourse = context.GetCourses().Select(x => new SelectListItem() { Text = x.CourseName, Value = x.CourseID.ToString() }).ToList();
			CourseFillViewModel cfvm = new CourseFillViewModel()
			{
				SubjectList = dbSubject,
				CourseList = dbCourse,
			};
			return View(cfvm);
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult CreateCourseFill(CourseFillViewModel courseFill)
		{
			if (ModelState.IsValid)
			{
				var tmpCourseFill = new Common.CourseFill()
				{
					courseID = courseFill.courseID,
					subjectID = courseFill.subjectID,
					SubjectHoursPerWeek = courseFill.SubjectHoursPerWeek
				};
				if (context.CreateCourseFill(tmpCourseFill) == true)
				{
					return RedirectToAction("Index", "CourseFill");
				}
				else
				{
					return View();
				}
			}
			return View(courseFill);
		}

		public ActionResult EditCourseFill(int courseID, int subjectID)
		{
			var courseFill = context.GetCoursFillByCourseSubject(courseID, subjectID);
			var dbSubject = context.GetSubjects().Select(x => new SelectListItem() { Text = x.SubjectName, Value = x.SubjectID.ToString() }).ToList();
			var dbCourse = context.GetCourses().Select(x => new SelectListItem() { Text = x.CourseName, Value = x.CourseID.ToString() }).ToList();
			var tmpCourseFill = new CourseFillViewModel()
			{
				courseFillID = courseFill.courseFillID,
				courseID = courseFill.courseID,
				subjectID = courseFill.subjectID,
				SubjectHoursPerWeek = courseFill.SubjectHoursPerWeek,
				SubjectList = dbSubject,
				CourseList = dbCourse
			};
			return View(tmpCourseFill);
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult EditCourseFill(CourseFillViewModel model)
		{
			bool IsChanged = false;
			var courseFill = context.GetCoursFillByCourseSubject(model.courseID, model.subjectID);
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
			return RedirectToAction("Index");
		}

		public ActionResult DeleteCourseFill(int courseID, int subjectID)
		{
			context.DeleteCourseFill(courseID, subjectID);
			return RedirectToAction("Index");
		}
	}
}