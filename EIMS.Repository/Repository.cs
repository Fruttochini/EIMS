using System;
using System.Collections.Generic;
using EIMS.Common;
using EIMS.Datalayer;
using EIMS.AuthorizationIdentity;

using System.Linq;

namespace EIMS.Repository
{

    public class Repository : IRepository
    {
        private EIMSEntitiesContext context;

        public Repository()
        {
            this.context = new EIMSEntitiesContext();
        }

        public IEnumerable<Common.Course> GetCourses()
        {
            var dbLst = context.Course.ToList();
            var result = new List<Common.Course>();
            foreach (var item in dbLst)
            {
                var tmpCrs = new Common.Course() { CourseID = item.courseID, CourseName = item.courseName };
                var dct = new Dictionary<int, int>();
                var tmpLst = item.CourseFill.Select(course => new { course.subjectID, course.subjectHoursPerWeek });
                foreach (var anonim in tmpLst)
                {
                    dct.Add(anonim.subjectID, anonim.subjectHoursPerWeek);
                }
                tmpCrs.SubjectByHours = dct;
                result.Add(tmpCrs);
            }
            return result;
        }

        public IEnumerable<Common.DayOfWeek> GetDayOfWeek()
        {
            var dbLst = context.DayOfWeek.ToList();
            var result = new List<Common.DayOfWeek>();
            foreach (var item in dbLst)
            {
                var tmpDOW = new Common.DayOfWeek() { DayID = item.ID, DayName = item.Name };
                var idLst = item.Lesson.Select(less => less.lessonID);
                tmpDOW.LessonID = idLst;
                result.Add(tmpDOW);
            }
            return result;
        }

        public IEnumerable<Common.Task> GetTask()
        {
            var dbLst = context.Task.ToList();
            var result = new List<Common.Task>();
            foreach (var item in dbLst)
            {
                var tmpTsk = new Common.Task() { taskID = item.taskID, lessonDateID = item.lessonDateID, homeTask = item.homeTask, expiryDate = item.expiryDate };
                result.Add(tmpTsk);
            }
            return result;
        }

        public IEnumerable<Common.LessonOrder> GetLessonOrder()
        {
            var dbLst = context.LessonOrder.ToList();
            var result = new List<Common.LessonOrder>();
            foreach (var item in dbLst)
            {
                var tmpLessOrder = new Common.LessonOrder() { lessonOrderID = item.ID, timeStart = item.TimeStart, timeEnd = item.TimeEnd };
                var idLst = item.Lesson.Select(lessOrder => lessOrder.lessonID);
                tmpLessOrder.GetLessonID = idLst;
                result.Add(tmpLessOrder);
            }
            return result;
        }

        public IEnumerable<Common.LessonPresence> GetLessonPresence()
        {
            var dbLst = context.LessonPresence.ToList();
            var result = new List<Common.LessonPresence>();
            foreach (var item in dbLst)
            {
                var tmpLessPresence = new Common.LessonPresence() { lessonDateID = item.lessonDateID, studentID = item.studentID, presence = item.presence, mark = item.mark };
                result.Add(tmpLessPresence);
            }
            return result;
        }

        public IEnumerable<Common.LessonDate> GetLessonDate()
        {
            var dbLst = context.LessonDate.ToList();
            var result = new List<Common.LessonDate>();
            foreach (var item in dbLst)
            {
                var tmpLessDate = new Common.LessonDate() { lessonDateID = item.lessonDateID, lessonID = item.lessonID, date = item.date };
                var tid = item.Task.Select(t => t.taskID);
                var sid = item.LessonPresence.Select(s => s.studentID);
                tmpLessDate.TaskID = tid;
                tmpLessDate.StudentID = sid;
                result.Add(tmpLessDate);
            }
            return result;
        }

        public IEnumerable<Common.Faculty> GetFaculties()
        {
            var dbLst = context.Faculty.ToList();
            var result = new List<Common.Faculty>();
            foreach (var item in dbLst)
            {
                var tmpFclt = new Common.Faculty() { FacultyID = item.facultyID, Name = item.Name };
                var idList = item.UniversityGroup.Select(grp => grp.groupID);
                tmpFclt.GroupID = idList;
                result.Add(tmpFclt);
            }
            return result;
        }

        public IEnumerable<Common.Room> GetRooms()
        {
            var dblst = context.Room.ToList();
            var result = new List<Common.Room>();

            return result;
        }



        public IEnumerable<Common.Subject> GetSubjects()
        {
            var dbLst = context.Subject.ToList();
            var result = new List<Common.Subject>();
            foreach (var item in dbLst)
            {
                var tmpSubj = new Common.Subject() { SubjectID = item.subjectID, SubjectName = item.subjectName };
                int arrLength = item.requirements.Length;
                var reqList = new bool[arrLength];
                for (int i = 0; i < arrLength; i++)
                {
                    reqList[i] = item.requirements[i] == 1 ? true : false;
                }
                tmpSubj.Requirements = reqList;
                result.Add(tmpSubj);
            }
            return result;
        }


        public IEnumerable<Common.UniversityGroup> GetGroups()
        {
            var result = new List<Common.UniversityGroup>();
            var dbList = context.UniversityGroup.ToList();
            foreach (var item in dbList)
            {
                var tmpGroup = new Common.UniversityGroup()
                {
                    GroupID = item.groupID,
                    CreationDate = item.creationDate,
                    FacultyID = item.facultyID,
                    GroupName = item.groupName,
                    elderID = item.elderID,
                    SupervisorID = item.supervisorID
                };
                result.Add(tmpGroup);
            }
            return result;
        }

        public IEnumerable<Common.Lesson> GetLessons()
        {
            var dbLst = context.Lesson.ToList();
            var result = new List<Common.Lesson>();
            foreach (var item in dbLst)
            {
                var tmpLesson = new Common.Lesson() { LessonID = item.lessonID, SubjectID = item.subjectID, GroupID = item.groupID, TeacherID = item.teacherID, RoomID = item.roomID, LessonOrder = item.LessonOrder, DayOfWeek = item.DayOfWeek, SubjectName = item.Subject.subjectName, GroupName = item.UniversityGroup.groupName, RoomNo = item.Room.roomNo };
                var user = GetUserByID(tmpLesson.TeacherID);

            }
            throw new NotImplementedException();
        }

        public IEnumerable<Common.Lesson> GetLessonsByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            var result = new List<User>();
            var dbList = context.EIMSUser.Select(usr => usr);

            foreach (var user in dbList)
            {
                var tmpUser = user.ToUser();
                result.Add(tmpUser);
            }

            return result;
        }

        public User GetUserByID(long ID)
        {
            var dbusr = context.EIMSUser.Where(usr => usr.Id == ID).Single();
            return dbusr.ToUser();
        }
    }
}

