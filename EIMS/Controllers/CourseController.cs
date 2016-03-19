using EIMS.Common;
using EIMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EIMS.Controllers
{
    public class CourseController : Controller
    {
		private IRepository context = new Repository.Repository();
		const int pageSize = 25;

		public ActionResult Index()
		{
			return View(GetItemsPerPage());
		}

		public ActionResult GetCourse(int? id)
        {
			int page = id ?? 0;
			if (Request.IsAjaxRequest())
			{
				return PartialView("GetCourse", GetItemsPerPage(page));
			}
			return PartialView(GetItemsPerPage());
        }

		public object GetItemsPerPage(int page = 0)
		{
			var itemToSkip = page * pageSize;
			var courseList = new List<CourseViewModel>();
			var dblst = context.GetCourses();
			foreach (var item in dblst)
			{
				CourseViewModel cvm = new CourseViewModel()
				{
					CourseID = item.CourseID,
					CourseName = item.CourseName,
				};
				courseList.Add(cvm);
			}
			return courseList.OrderBy(c=>c.CourseID).Skip(itemToSkip).Take(pageSize).ToList();
		}

		public ActionResult CreateCourse()
		{
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult CreateCourse(CourseViewModel course)
		{
			if(ModelState.IsValid)
			{
				var tmpCourse = new Common.Course()
				{
					CourseName = course.CourseName
				};
				if (context.CreateCourse(tmpCourse) == true)
				{
					return RedirectToAction("Index", "Course");
				}
				else
				{
					return View();
				}
			}
			return View(course);
		}

		public ActionResult EditCourse(int id)
		{
			var course = context.GetCourseByID(id);
			var tmpCourse = new CourseViewModel()
			{
				CourseID = course.CourseID,
				CourseName = course.CourseName
			};
			return View(tmpCourse);
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult EditCourse(CourseViewModel model)
		{
			bool IsChanged = false;
			var course = context.GetCourseByID(model.CourseID);
			var tmpCourse = new Common.Course();
			if (!course.CourseName.Equals(model.CourseName))
			{
				tmpCourse.CourseName = model.CourseName;
				IsChanged = true;
			}
			if (IsChanged)
			{
				tmpCourse.CourseID = model.CourseID;
				context.UpdateCourse(tmpCourse);
			}
			return RedirectToAction("Index");
		}

		public ActionResult DeleteCourse(int id)
		{
			context.DeleteCourse(id);
			return RedirectToAction("Index");
		}

		public ActionResult DetailCourse(int id)
		{
			var courseFill = context.GetCourseByID(id);
			var tmpCourseFill = new CourseViewModel()
			{
				CourseID = courseFill.CourseID,
				CourseName = courseFill.CourseName,
				//SubjectByHours = courseFill.SubjectByHours
			};
			return View(tmpCourseFill);
		}
    }
}