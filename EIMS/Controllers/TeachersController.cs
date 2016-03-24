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

        public ActionResult PersonalSchedule()
        {
            var id = long.Parse(User.Identity.GetUserId());
            var dbList = context.GetLessonByTeacher(id);
            var teacher = context.GetTeacherByID(id);

            var model = new TeacherScheduleViewModel()
            {
                ID = id,
                FullName = teacher.Name + " " + teacher.Surname
            };

            List<LessonInfoViewModel> lessons = new List<LessonInfoViewModel>();
            foreach (var item in dbList)
            {
                LessonInfoViewModel lesson = new LessonInfoViewModel()
                {
                    LessonID = item.LessonID,
                    DayID = item.DayOfWeek,
                    OrderID = item.LessonOrder,
                    RoomNo = item.RoomNo,
                    Subject = item.SubjectName,
                    Teacher = item.TeacherFullName,
                    GroupID = item.GroupID,
                    GroupName = item.GroupName,
                    LessonDateID = context.GetLessonDateByLessonAndDate(item.LessonID, DateTime.Today),
                    SubjectID = item.SubjectID

                };
                lessons.Add(lesson);
            }

            var dbDays = context.GetDayOfWeek();
            List<DayVm> days = new List<DayVm>();
            foreach (var item in dbDays)
            {
                var tmp = new DayVm()
                {
                    ID = item.DayID,
                    Name = item.DayName
                };
                days.Add(tmp);
            }
            days.OrderBy(f => f.ID);

            var dbOrdnung = context.GetLessonOrder();
            List<LessonOrderViewModel> order = new List<LessonOrderViewModel>();
            foreach (var item in dbOrdnung)
            {
                var tmp = new LessonOrderViewModel()
                {
                    lessonOrderID = item.lessonOrderID,
                    timeStart = item.timeStart,
                    timeEnd = item.timeEnd
                };
                order.Add(tmp);
            }
            order.OrderBy(o => o.timeStart);

            model.Order = order;
            model.LessonList = lessons;
            model.Days = days;
            return View(model);


        }


    }
}