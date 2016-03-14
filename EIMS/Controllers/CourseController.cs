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
		// GET: Course
		public ActionResult GetCourse()
        {
			var courseList = new List<CourseViewModel>();
			var dblst = context.GetCourses();
			foreach (var item in dblst)
			{
				CourseViewModel cvm = new CourseViewModel()
				{
					CourseID = item.CourseID,
					CourseName = item.CourseName,
					SubjectByHours = item.SubjectByHours
				};
				courseList.Add(cvm);
			}
            return View(courseList);
        }


    }
}