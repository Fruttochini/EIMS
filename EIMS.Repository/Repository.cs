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
            foreach (var item in dblst)
            {
                var tmpRoom = new Common.Room()
                {
                    Capacity = item.capacity,
                    ID = item.roomID,
                    IsAvailable = item.isAvailable,
                    RoomNo = item.roomNo
                };
                int arrLength = item.features.Length;
                var featLst = new bool[arrLength];
                for (int i = 0; i < arrLength; i++)
                {
                    featLst[i] = item.features[i] == 1 ? true : false;
                }
                tmpRoom.Features = featLst;
                result.Add(tmpRoom);
            }
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
            var dbUL = context.EIMSUser.Select(usr => usr);
            foreach (var usr in dbUL)
            {
                var tmpUsr = usr.ToUser();

                result.Add(tmpUsr);
            }
            return result;
        }

        public User GetUserByID(long ID)
        {
            throw new NotImplementedException();
        }
    }
}

