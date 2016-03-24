using EIMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EIMS.Models;

namespace EIMS.Controllers
{
    public class ScheduleController : Controller
    {
        IRepository context;

        public ScheduleController()
        {
            context = new Repository.Repository();
        }

        public ScheduleController(IRepository repo)
        {
            context = repo;
        }


        // GET: Schedule
        //public ActionResult GetTeachers(int subjectID, int loid, byte dayofWeek)
        //{
        //    var dblist = context.GetTeacherBySubject(subjectID);
        //    var lessonlist = context.GetLessonByDay(dayofWeek);
        //    lessonlist = lessonlist.Where(l => l.LessonOrder == loid);
        //    var exceptTeacherList = lessonlist.Select(l => l.TeacherID);
        //    var tidList = dblist.Select(t => t.ID).Except(exceptTeacherList);

        //    TeacherVM result = new TeacherVM();
        //    List<GroupUserInfo> list = new List<GroupUserInfo>();
        //    foreach (var item in tidList)
        //    {
        //        var teach = context.GetUserByID(item);
        //        GroupUserInfo tmp = new GroupUserInfo()
        //        {
        //            ID = teach.ID,
        //            Name = teach.Name,
        //            Surname = teach.Surname,
        //            MiddleName = teach.MiddleName
        //        };
        //        list.Add(tmp);
        //    }
        //    result.Teachers = list;
        //    return View(result);
        //}



        public JsonResult GetTeachersJSON(int subjectID, int loid, byte dayofweek)
        {
            var dblist = context.GetTeacherBySubject(subjectID);
            var lessonlist = context.GetLessonByDay(dayofweek);
            lessonlist = lessonlist.Where(l => l.LessonOrder == loid);
            var exceptTeacherList = lessonlist.Select(l => l.TeacherID);
            var tidList = dblist.Select(t => t.ID).Except(exceptTeacherList);


            List<GroupUserInfo> list = new List<GroupUserInfo>();
            foreach (var item in tidList)
            {
                var teach = context.GetUserByID(item);
                GroupUserInfo tmp = new GroupUserInfo()
                {
                    ID = teach.ID,
                    Name = teach.Name,
                    Surname = teach.Surname,
                    MiddleName = teach.MiddleName
                };
                list.Add(tmp);
            }

            return Json(list, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetRoomsJSON(int subjectID, int loid, byte dayofweek, int stCount)
        {
            List<Room> result = new List<Room>();
            var subjReqs = context.GetSubjects().Single(s => s.SubjectID == subjectID).Requirements;
            var PossibleRooms = context.GetRooms()
                .Where(r => r.IsAvailable == true)
                .Where(r => r.Capacity > stCount);

            List<int> PossibleRoomsID = new List<int>();
            foreach (var item in PossibleRooms)
            {
                bool toogle = true;
                foreach (var req in subjReqs)
                {
                    if (!item.SelectedPossibilities.Contains(req))
                        toogle &= false;
                }
                if (toogle)
                    PossibleRoomsID.Add(item.ID);

            }

            var exceptionList = context.GetLessonByDay(dayofweek).Where(l => l.LessonOrder == loid).Select(r => r.RoomID);
            var resRooms = PossibleRoomsID.Except(exceptionList);
            foreach (var item in resRooms)
            {
                result.Add(context.GetRoomByID(item));
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: Schedule/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Schedule/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Schedule/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Schedule/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Schedule/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Schedule/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Schedule/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
