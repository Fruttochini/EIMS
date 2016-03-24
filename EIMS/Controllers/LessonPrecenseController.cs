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

        [Authorize(Roles = "Teacher")]
        public ActionResult CreateLessonPrecense(long lessonDateID, int groupID, int subjectID, int loid)
        {

            var group = context.GetGroupByID(groupID);
            var stdlist = context.GetStudentByGroup(groupID);
            var subject = context.GetSubjectByID(subjectID);
            var lo = context.GetLessonOrderByID(loid);

            List<StudentLessonPressenceViewModel> stPresList = new List<StudentLessonPressenceViewModel>();
            foreach (var item in stdlist)
            {
                var dbpres = context.GetLessonPressenseByLDIDandSID(lessonDateID, item.ID);
                if (dbpres == null)
                {
                    var tmpPressense = new Common.LessonPresence()
                    {
                        lessonDateID = lessonDateID,
                        studentID = item.ID,
                        presence = false

                    };
                    context.CreateLessonPrecense(tmpPressense);

                    var slpvm = new StudentLessonPressenceViewModel()
                    {
                        LessonDateID = lessonDateID,
                        Precense = false,
                        StudentID = item.ID,
                        StudentName = item.Name + " " + item.Surname
                    };
                    stPresList.Add(slpvm);
                }
                else
                {
                    var slpvm = new StudentLessonPressenceViewModel()
                    {
                        LessonDateID = dbpres.lessonDateID,
                        Precense = dbpres.presence,
                        StudentID = dbpres.studentID,
                        StudentName = item.Name + " " + item.Surname,
                        Mark = dbpres.mark,
                        LessonPrecenseID = dbpres.lessonPresenseID

                    };
                    stPresList.Add(slpvm);
                }
            }
            var result = new GroupLessonPressenceViewModel()
            {
                Date = DateTime.Today,
                GroupID = group.GroupID,
                GroupName = group.GroupName,
                LessonOrder = lo.timeStart.Hours.ToString() + ":" + lo.timeStart.Minutes.ToString() + " - " + lo.timeEnd.Hours.ToString() + ":" + lo.timeEnd.Minutes.ToString(),
                StudentsPressense = stPresList,
                SubjectName = subject.SubjectName,
                lessonDateID = lessonDateID

            };
            return View(result);
        }

        [HttpGet]
        public JsonResult SetPressense(long studentID, long lessonDateID, bool pressense, byte? mark)
        {
            context.UpdateLessonPrecense(new LessonPresence()
            {
                lessonDateID = lessonDateID,
                studentID = studentID,
                mark = mark,
                presence = pressense
            });
            return null;
        }


        //var studentList = new List<LessonPrecenseList>();
        //var option = context.GetLessonPrecenseOption(lessonDateID);
        //var tmpList = context.GetUserForGroup(lessonDateID);
        //foreach (var item in tmpList)
        //{
        //    LessonPrecenseList lpl = new LessonPrecenseList()
        //    {
        //        StudentID = item.ID,
        //        StudentName = item.Surname + " " + item.Name + " " + item.MiddleName,
        //        LessonDateID = lessonDateID,
        //    };
        //    studentList.Add(lpl);
        //}
        //lessonPrecens.RowList = studentList;
        //lessonPrecens.SubjectName = option.SubjectName;
        //lessonPrecens.LessonDate = option.LessonDate;
        //lessonPrecens.TeacherName = option.TeacherName;


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateLessonPrecense(IEnumerable<LessonPrecenseList> models)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in models)
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
            foreach (var item in tmpLessonPrecense.StudentList)
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
            foreach (var item in models)
            {
                var lessonPrecense = context.GetLessonPrecenseByID(item.LessonPrecenseID);
                var tmpLessonPrecense = new Common.LessonPresence();
                if (!lessonPrecense.presence.Equals(item.Precense))
                {
                    tmpLessonPrecense.presence = item.Precense;
                    IsChange = true;
                }
                if (!lessonPrecense.mark.Equals(item.Mark))
                {
                    tmpLessonPrecense.mark = item.Mark;
                    IsChange = true;
                }
                if (IsChange)
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