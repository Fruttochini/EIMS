using EIMS.Common;
using EIMS.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EIMS.Controllers
{
    public class StudentsController : Controller
    {
        IRepository context = new Repository.Repository();

        [Authorize(Roles = "Student")]
        public ActionResult PersonalSchedule()
        {

            var id = long.Parse(User.Identity.GetUserId());
            var usr = context.GetUserByID(id);
            var grop = context.GetGroupByStudent(id);
            var model = new StudentScheduleViewModel();
            if (grop != null)
            {

                var dbList = context.GetLessonsByGroup(grop.GroupID);


                model = new StudentScheduleViewModel()
                {
                    ID = id,
                    FullName = usr.Name + " " + usr.Surname,
                    groupID = grop.GroupID,
                    GroupName = grop.GroupName
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
            return View(model);
        }


        [Authorize(Roles = "Student")]
        public ActionResult GetTasks()
        {
            var id = long.Parse(User.Identity.GetUserId());
            var usr = context.GetUserByID(id);
            var grop = context.GetGroupByStudent(id);
            var model = new TaskViewModel();
            if (grop != null)
            {
                var tsks = context.GetTasksByGroupID(grop.GroupID);
                var resTasks = new List<TaskList>();
                foreach (var item in tsks)
                {
                    var tmp = new TaskList()
                    {
                        GroupName = item.groupName,
                        expireDate = item.expiryDate,
                        homeTask = item.homeTask,
                        lessonDateID = item.lessonDateID,
                        SubjectName = item.subjectName,
                        taskID = item.taskID
                    };
                    resTasks.Add(tmp);
                }
                model.taskList = resTasks;
            }

            return View(model);
        }
    }
}