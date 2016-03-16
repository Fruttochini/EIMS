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
		const int pageSize = 9;

		public ActionResult Index()
		{
			return View();
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
			return View();
		}



    }
}