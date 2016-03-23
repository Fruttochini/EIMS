using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using EIMS.Models;
using EIMS.Common;

namespace EIMS.Controllers
{
    public class TeachersController : Controller
    {
		IRepository context = new Repository.Repository();

        public ActionResult Index()
        {
			var teacherID = long.Parse(User.Identity.GetUserId());
			var lessons = new List<TeachersViewModel>();
			var dateNow = DateTime.Now.Date;
			var lessonList = context.GetLessonByTeacherAndDate(teacherID, dateNow);
			foreach(var item in lessonList)
			{
				var teacher = context.GetTeacherByID(item.TeacherID);
				var dateOfWeek = context.GetDayOfWeek(item.DayOfWeek);
				var orderDate = context.GetLessonOrderByID(item.LessonOrder);
				TeachersViewModel tvm = new TeachersViewModel()
				{
					LessonID = item.LessonID,
					Subject = item.SubjectName,
					RoomNo = item.RoomNo,
					DateOfWeek = dateOfWeek,
					Teacher = teacher.Surname + " " + teacher.Name + " " + teacher.MiddleName,
					LessonDateID = context.GetLessonDateByLessonAndDate(item.LessonID, dateNow),
					LessonEnd = orderDate.timeEnd,
					LessonStart = orderDate.timeStart,
					LessonDate = dateNow
				};
				lessons.Add(tvm);
			}
            return View(lessons);
        }
    }
}