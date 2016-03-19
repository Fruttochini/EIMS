using EIMS.Common;
using EIMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EIMS.Controllers
{
    public class GroupCourseController : Controller
    {
		private IRepository context = new Repository.Repository();
		const int pageSize = 25;

        public ActionResult Index(int courseID)
        {
            return View(GetItemsPerPage(courseID));
        }

		public ActionResult GetGroupCourse(int courseID, int? id)
		{
			int page = id ?? 0;
			if(Request.IsAjaxRequest())
			{
				return PartialView("GetGroupCourses", GetItemsPerPage(courseID, page));
			}
			return PartialView(GetItemsPerPage(courseID));
		}

		private object GetItemsPerPage(int courseID, int page = 0)
		{
			var itemToSkip = page * pageSize;
			var groupByCourseList = new List<GroupCoursList>();
			var groupCourse = new GroupCoursViewModel();
			var dbLst = context.GetGroupByCourse(courseID);
			foreach(var item in dbLst)
			{
				GroupCoursList gcl = new GroupCoursList()
				{
					groupCourseID = item.GroupCourseID,
					courseID = item.CourseID,
					groupID = item.GroupID,
					GroupName = item.GroupName,
					startDate = item.StartDate,
					endDate = item.EndDate
				};
				groupByCourseList.Add(gcl);
			}
			var tmpCourse = context.GetCourseByID(courseID);
			CourseViewModel cvm = new CourseViewModel()
			{
				CourseID = tmpCourse.CourseID,
				CourseName = tmpCourse.CourseName
			};
			groupCourse.SelectCourse = cvm;
			groupCourse.groupList = groupByCourseList.OrderBy(gc => gc.groupCourseID).Skip(itemToSkip).Take(pageSize).ToList();
			return groupCourse;
		}

		public ActionResult CreateGroupCourse(int id)
		{
			var dbGroups = context.GetGroups().Select(x => new SelectListItem() { Text = x.GroupName, Value = x.GroupID.ToString() }).ToList();
			CreateEditGroupCourseViewModel model = new CreateEditGroupCourseViewModel()
			{
				courseID = id,
				GroupList = dbGroups
			};
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult CreateGroupCourse(CreateEditGroupCourseViewModel model)
		{
			if(ModelState.IsValid)
			{
				var tmpGroupCourse = new Common.GroupCourse()
				{
					CourseID = model.courseID,
					GroupID = model.groupID,
					StartDate = model.startDate,
					EndDate = model.endDate
				};
				if(context.CreateGroupCours(tmpGroupCourse)==true)
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

		public ActionResult EditGroupCourse(int id)
		{
			var groupCourse = context.GetGroupCoursByID(id);
			var dbGroups = context.GetGroups().Select(x => new SelectListItem() { Text = x.GroupName, Value = x.GroupID.ToString() }).ToList();
			var tmpGroupCourse = new CreateEditGroupCourseViewModel()
			{
				groupCourseID = groupCourse.GroupCourseID,
				courseID = groupCourse.CourseID,
				groupID = groupCourse.GroupID,
				startDate = groupCourse.StartDate,
				endDate = groupCourse.EndDate,
				GroupList = dbGroups
			};
			return View(tmpGroupCourse);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditGroupCourse(CreateEditGroupCourseViewModel model)
		{
			bool IsChanged = false;
			var groupCourse = context.GetGroupCoursByID(model.groupCourseID);
			var tmpGroupCours = new Common.GroupCourse();
			if(!groupCourse.GroupID.Equals(model.groupID))
			{
				IsChanged = true;
				tmpGroupCours.GroupID = model.groupID;
			}
			if(!groupCourse.StartDate.Equals(model.startDate))
			{
				IsChanged = true;
				tmpGroupCours.StartDate = model.startDate;
			}
			if(!groupCourse.EndDate.Equals(model.endDate))
			{
				IsChanged = true;
				tmpGroupCours.EndDate = model.endDate;
			}
			if(IsChanged)
			{
				tmpGroupCours.GroupCourseID = model.groupCourseID;
				tmpGroupCours.CourseID = model.courseID;
				context.UpdateGroupCours(tmpGroupCours);
			}
			return RedirectToAction("Index", new { courseID = model.courseID });
		}

		public ActionResult DeleteGroupCourse(int id)
		{
			var model = context.GetGroupCoursByID(id);
			if (context.DeleteGroupCours(id) == true)
				return RedirectToAction("Index", new { courseID = model.CourseID });
			return View();
		}
	}
}