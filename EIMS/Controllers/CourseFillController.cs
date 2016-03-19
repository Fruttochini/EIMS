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
        

		public ActionResult Index(CourseViewModel model)
        {
            
            return View(GetItemsPerPage(model));
        }

		public ActionResult GetCourseFill(CourseViewModel model, int? id)
		{
			int page = id ?? 0;
			if (Request.IsAjaxRequest())
			{
				return PartialView("GetCourseFill", GetItemsPerPage(model, page));
			}
			return PartialView(GetItemsPerPage(model));
		}

		public object GetItemsPerPage(CourseViewModel model, int page=0)
		{
			var itemToSkip = page * pageSize;
            var courseFillList = new List<CourseFillViewModel>();
            if (model.Subjects != null)
            {
                foreach (var item in model.Subjects)
                {
                    CourseFillViewModel cfvm = new CourseFillViewModel()
                    {
                        courseFillID = item.courseFillID,
                        courseID = item.courseID,
                        subjectID = item.subjectID,
                        courseName = item.courseName,
                        subjectName = item.subjectName,
                        SubjectHoursPerWeek = item.SubjectHoursPerWeek,
                    };
                    courseFillList.Add(cfvm);
                }
            }
            model.Subjects = courseFillList.OrderBy(cf => cf.courseID).Skip(itemToSkip).Take(pageSize).ToList();
            return model;
		}
        [HttpGet]
		public ActionResult CreateCourseFill(int courseID)
		{
            var courseFill = context.GetCourseByID(courseID);
            var dbCourseFill = context.GetCourseFillByCourse(courseID);
            var courseFillList = new List<CourseFillViewModel>();
            var dbSubject = context.GetSubjects().Select(x => new SelectListItem() { Text = x.SubjectName, Value = x.SubjectID.ToString() }).ToList();
            foreach (var item in dbCourseFill)
            {
                CourseFillViewModel tmpCourseFillViewModel = new CourseFillViewModel()
                {
                    courseFillID = item.courseFillID,
                    courseID = item.courseID,
                    courseName = item.courseName,
                    SubjectList = dbSubject,
                    SubjectHoursPerWeek = item.SubjectHoursPerWeek
                };
                courseFillList.Add(tmpCourseFillViewModel);
            }
            var tmpCourseFill = new CourseViewModel()
            {
                CourseID = courseFill.CourseID,
                CourseName = courseFill.CourseName,
                Subjects = courseFillList,
            };

            return View(tmpCourseFill);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult CreateCourseFill(CourseViewModel model )
		{
			if (ModelState.IsValid)
			{
				var tmpCourseFill = new Common.CourseFill()
				{
					courseID = model.selectedSubject.courseID,
					subjectID = model.selectedSubject.subjectID,
					SubjectHoursPerWeek = model.selectedSubject.SubjectHoursPerWeek
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
			return View(model);
		}

		public ActionResult EditCourseFill(int id)
		{
			var courseFill = context.GetCoursFillByID(id);
			var dbSubject = context.GetSubjects().Select(x => new SelectListItem() { Text = x.SubjectName, Value = x.SubjectID.ToString() }).ToList();
			var tmpCourseFill = new CourseFillViewModel()
			{
				courseFillID = courseFill.courseFillID,
				courseID = courseFill.courseID,
				subjectID = courseFill.subjectID,
				SubjectHoursPerWeek = courseFill.SubjectHoursPerWeek,
				SubjectList = dbSubject
			};
			return View(tmpCourseFill);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditCourseFill(CourseFillViewModel model)
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
			return RedirectToAction("Index");
		}

		public ActionResult DeleteCourseFill(int id)
		{
			context.DeleteCourseFill(id);
			return RedirectToAction("Index");
		}
	}
}