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

		public ActionResult CreateLessonPrecense (long lessonDateID)
		{
			var lessonPrecens = new LessonPrecenseViewModel();
			var studentList = new List<LessonPrecenseList>();
			var option = context.GetLessonPrecenseOption(lessonDateID);
			var tmpList = context.GetUserForGroup(lessonDateID);
			foreach(var item in tmpList)
			{
				LessonPrecenseList lpl = new LessonPrecenseList()
				{
					StudentID = item.ID,
					StudentName = item.Surname + " " + item.Name + " " + item.MiddleName,
					LessonDateID = lessonDateID,
				};
				studentList.Add(lpl);
			}
			lessonPrecens.RowList = studentList;
			lessonPrecens.SubjectName = option.SubjectName;
			lessonPrecens.LessonDate = option.LessonDate;
			lessonPrecens.TeacherName = option.TeacherName;
			return View(lessonPrecens);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult CreateLessonPrecense (IEnumerable<LessonPrecenseList> models)
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

		public ActionResult EditLessonPrecense(long lessonDateID)
		{
			var lessonPrecense = new LessonPrecenseViewModel();
			var editList = new List<LessonPrecenseList>();
			var tmpLessonPrecense = context.GetLessonPrecenseByLessonDate(lessonDateID);
			foreach(var item in tmpLessonPrecense.StudentList)
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
				editList.Add(lpl);
			}
			lessonPrecense.RowList = editList;
			lessonPrecense.LessonDate = tmpLessonPrecense.LessonDate;
			lessonPrecense.SubjectName = tmpLessonPrecense.SubjectName;
			lessonPrecense.TeacherName = tmpLessonPrecense.TeacherName;
			return View(lessonPrecense);
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