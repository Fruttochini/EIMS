using EIMS.Common;
using EIMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EIMS.Controllers
{
    public class LessonPrecenseController : Controller
    {
		private IRepository context = new Repository.Repository();
		const int pageSize = 25;

        public ActionResult Index(long lessonDateID)
        {
            return View(GetItemsPerPage(lessonDateID));
        }

		private object GetItemsPerPage(long lessonDateID, int page = 0)
		{
			var itemToSkip = page * pageSize;
			var lessonPrecense = new List<LessonPrecenseList>();
			var lesson = new LessonPrecenseViewModel();
			var dbList = context.GetLessonPrecenseByLessonDate(lessonDateID);
			foreach(var item in dbList.StudentList)
			{
				LessonPrecenseList lpl = new LessonPrecenseList()
				{
					LessonPrecenseID = item.lessonPresenseID,
					LessonDateID = item.lessonDateID,
					StudentID = item.studentID,
					StudentName = item.StudentName,
					Precense = item.presence,
					Mark = item.mark
				};
				lessonPrecense.Add(lpl);
			}
			lesson.RowList = lessonPrecense.OrderBy(lp=>lp.StudentName).Skip(itemToSkip).Take(pageSize).ToList();
			lesson.LessonDate = dbList.LessonDate;
			lesson.SubjectName = dbList.SubjectName;
			lesson.TeacherName = dbList.TeacherName;
			return lesson;
		}

		public ActionResult GetLessonPrecense (long lessonDateID, int? id)
		{
			int page = id ?? 0;
			if(Request.IsAjaxRequest())
			{
				return PartialView("GetLessonPrecense", GetItemsPerPage(lessonDateID, page));
			}
			return PartialView(GetItemsPerPage(lessonDateID));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult GetLessonPrecense (IEnumerable<LessonPrecenseList> models)
		{
			if(ModelState.IsValid)
			{
				foreach(var item in models)
				{
					var tmpLessonPrecense = new Common.LessonPresence()
					{
						lessonDateID = item.LessonDateID,
						studentID = item.StudentID,
						presence = item.Precense,
						mark = item.Mark
					};
					context.CreateLessonPrecense(tmpLessonPrecense);
				}
				return RedirectToAction("Lesson", "Lesson");
			}
			return View(models);
		}

		public ActionResult EditLessonPrecense(long lessonDateID, int? id)
		{
			int page = id ?? 0;
			if (Request.IsAjaxRequest())
			{
				return PartialView("EditLessonPrecense", GetItemsPerPage(lessonDateID, page));
			}
			return PartialView(GetItemsPerPage(lessonDateID));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditLessonPrecense(IEnumerable<LessonPrecenseList> models)
		{
			bool IsChange = false;
			foreach(var item in models)
			{
				var lessonPrecense = context.GetLessonPrecenseByID(item.LessonPrecenseID);
				var tmpLessonPrecense = new Common.LessonPresence();
				if(!lessonPrecense.presence.Equals(item.Precense))
				{
					tmpLessonPrecense.presence = item.Precense;
					IsChange = true;
				}
				if(!lessonPrecense.mark.Equals(item.Mark))
				{
					tmpLessonPrecense.mark = item.Mark;
					IsChange = true;
				}
				if(IsChange)
				{
					tmpLessonPrecense.lessonPresenseID = item.LessonPrecenseID;
					tmpLessonPrecense.lessonDateID = item.LessonDateID;
					tmpLessonPrecense.studentID = item.StudentID;
					context.UpdateLessonPrecense(tmpLessonPrecense);
				}
			}
			return RedirectToAction("Lesson", "Lesson");
		}
	}
}