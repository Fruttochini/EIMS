using System;
using System.Collections.Generic;
using EIMS.Common;
using EIMS.Datalayer;
using EIMS.AuthorizationIdentity;

using System.Linq;
using System.Text;

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
                //var dct = new Dictionary<string, int>();
                //var tmpLst = item.CourseFill.Select(course => new { course.Subject.subjectName, course.subjectHoursPerWeek });
                //foreach (var anonim in tmpLst)
                //{
                //    dct.Add(anonim.subjectName, anonim.subjectHoursPerWeek);
                //}
                //tmpCrs.SubjectByHours = dct;
                result.Add(tmpCrs);
            }
            return result;
        }

        public IEnumerable<Common.CourseFill> GetAllCourseFill()
        {
            var dbLst = context.CourseFill.ToList();
            var result = new List<Common.CourseFill>();
            foreach (var item in dbLst)
            {
                var tmpCourseFill = new Common.CourseFill() { courseFillID = item.courseFillID, courseID = item.courseID, courseName = item.Course.courseName, subjectID = item.subjectID, subjectName = item.Subject.subjectName, SubjectHoursPerWeek = item.subjectHoursPerWeek };
                result.Add(tmpCourseFill);
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

        public IEnumerable<Common.Task> GetTaskForGroupByDate(int groupID, DateTime selectDate)
        {
			var dbLst = context.Task.Where(t => t.LessonDate.Lesson.groupID == groupID && t.LessonDate.date == selectDate).ToList();
            var result = new List<Common.Task>();
            foreach (var item in dbLst)
            {
                var tmpTsk = new Common.Task() { taskID = item.taskID, lessonDateID = item.lessonDateID, homeTask = item.homeTask, expiryDate = item.expiryDate, subjectName = item.LessonDate.Lesson.Subject.subjectName, groupName = item.LessonDate.Lesson.UniversityGroup.groupName };
                result.Add(tmpTsk);
            }
            return result;
        }

		public Common.LessonPresence GetLessonPrecenseByID(long id)
		{
			var dbItem = context.LessonPresence.Where(lp => lp.lessonPresenceID == id).Single();
			return dbItem.ToLessonPrecense();
		}

		public Common.Task GetTaskByID(long id)
		{
			var dbItem = context.Task.Where(t => t.taskID == id).Single();
			return dbItem.ToTask();
		}

        public IEnumerable<Common.LessonOrder> GetLessonOrder()
        {
            var dbLst = context.LessonOrder.ToList();
            var result = new List<Common.LessonOrder>();
            foreach (var item in dbLst)
            {
                var tmpLessOrder = new Common.LessonOrder() { lessonOrderID = item.ID, timeStart = item.TimeStart, timeEnd = item.TimeEnd };
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

        public IEnumerable<FacultyCommon> GetFaculties()
        {
            var dbLst = context.Faculty.ToList();
            var result = new List<FacultyCommon>();
            foreach (var item in dbLst)
            {
                var tmpFclt = new FacultyCommon() { FacultyID = item.facultyID, Name = item.Name };
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
                var tmpr = new Common.Room()
                {
                    ID = item.roomID,
                    Capacity = item.capacity,
                    IsAvailable = item.isAvailable,
                    RoomNo = item.roomNo,
                    SelectedPossibilities = item.SRRequirement.Select(r => r.ID).ToList()

                };
                result.Add(tmpr);
            }

            return result;
        }



        public IEnumerable<Common.Subject> GetSubjects()
        {
            var dbLst = context.Subject.ToList();
            var result = new List<Common.Subject>();
            foreach (var item in dbLst)
            {
                var tmpSubj = new Common.Subject()
                {
                    SubjectID = item.subjectID,
                    SubjectName = item.subjectName,
                    Requirements = item.SRRequirement
                    .Select(req => req.ID)
                    .ToList()

                };
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
                var sb = new StringBuilder();
                sb.AppendFormat("{0} {1} {2}", user.Surname, user.Name, user.MiddleName);
                tmpLesson.TeacherFullName = sb.ToString();
                result.Add(tmpLesson);
            }
            return result;
        }

        public IEnumerable<Common.LessonDate> GetLessonsByDate(DateTime date)
        {

            var result = new List<Common.LessonDate>();
            var dbLst = context.LessonDate.Where(lesson => lesson.date == date).Select(lDate => lDate).ToList();
            foreach (var item in dbLst)
            {
                var tmpLessDate = item.ToLessonDate();
                result.Add(tmpLessDate);
            }
            return result;
        }

        public void Dispose()
        {
            context.Dispose();
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

        public FacultyCommon GetFacultyByID(int id)
        {
            var dbusr = context.Faculty.Where(fclt => fclt.facultyID == id).Single();
            return dbusr.ToFaculty();
        }

        public IEnumerable<User> GetStudentByGroup(int groupID)
        {
            //var dbList = context.EIMSUser.Where(usr => usr.StudentGroup.Where(grp => grp.groupID == groupID) != null && usr.Role.Select(rl => rl.Name).Contains("Student"));
            var dbList = context.StudentGroup.Where(gr => gr.groupID == groupID).Select(st => st.EIMSUser);

            var tmpUser = new List<User>();
            foreach (var item in dbList)
            {
                tmpUser.Add(item.ToUser());
            }
            return tmpUser;
        }

        public bool? CreateFaculty(FacultyCommon faculty)
        {
            var dbItem = new Faculty()
            {
                Name = faculty.Name
            };
            context.Faculty.Add(dbItem);
            if (context.SaveChanges() > 0)
                return true;
            return false;
        }

        public bool? UpdateFaculty(FacultyCommon faculty)
        {
            var tmpFaculty = context.Faculty.Where(f => f.facultyID == faculty.FacultyID).Single();
            tmpFaculty.Name = faculty.Name;
            if (context.SaveChanges() > 0)
                return true;
            return false;
        }

        public bool? DeleteFaculty(int id)
        {
            var tmpFaculty = context.Faculty.Where(f => f.facultyID == id).Single();
            context.Faculty.Remove(tmpFaculty);
            if (context.SaveChanges() > 0)
                return true;
            return false;
        }
        public Common.Course GetCourseByID(int id)
        {
            var dbusr = context.Course.Where(crs => crs.courseID == id).Single();
            //var dct = new Dictionary<string, int>();
            var course = new Common.Course();
            //foreach (var item in dbusr.CourseFill.Where(cFill => cFill.courseID == id))
            //{
            //    dct.Add(item.Subject.subjectName, item.subjectHoursPerWeek);
            //}
            course.CourseID = dbusr.courseID;
            course.CourseName = dbusr.courseName;
            //course.SubjectByHours = dct;
            return course;
        }

        public bool? CreateCourse(Common.Course course)
        {
            var dbItem = new Datalayer.Course()
            {
                courseName = course.CourseName
            };
            context.Course.Add(dbItem);
            if (context.SaveChanges() > 0)
                return true;
            return false;
        }

        public bool? UpdateCourse(Common.Course course)
        {
            var tmpCourse = context.Course.Where(c => c.courseID == course.CourseID).Single();
            tmpCourse.courseName = course.CourseName;
            if (context.SaveChanges() > 0)
                return true;
            return false;
        }

        public bool? DeleteCourse(int id)
        {
            var tmpCourse = context.Course.Where(c => c.courseID == id).Single();
            context.Course.Remove(tmpCourse);
            if (context.SaveChanges() > 0)
                return true;
            return false;
        }

        public IEnumerable<Common.GroupCourse> GetGroupByCourse(int courseID)
        {
            var dbLst = context.GroupCourse.Where(gCourse => gCourse.courseID == courseID).ToList();
            var result = new List<Common.GroupCourse>();
            foreach (var item in dbLst)
            {
                var tmpGroupCourse = new Common.GroupCourse()
                {
                    GroupCourseID = item.groupCourseID,
                    CourseID = item.courseID,
                    CourseName = item.Course.courseName,
                    GroupID = item.groupID,
                    GroupName = item.UniversityGroup.groupName,
                    StartDate = item.startDate,
                    EndDate = item.endDate
                };
                result.Add(tmpGroupCourse);
            }
            return result;
        }

        public IEnumerable<Common.CourseFill> GetCourseFillByCourse(int id)
        {
            var dbLst = context.CourseFill.Where(cFill => cFill.courseID == id).ToList();
            var result = new List<Common.CourseFill>();
            foreach (var item in dbLst)
            {
                var tmpCourseFill = new Common.CourseFill()
                {
                    courseFillID = item.courseFillID,
                    courseID = item.courseID,
                    courseName = item.Course.courseName,
                    subjectID = item.subjectID,
                    subjectName = item.Subject.subjectName,
                    SubjectHoursPerWeek = item.subjectHoursPerWeek
                };
                result.Add(tmpCourseFill);
            }
            return result;
        }

        public bool? CreateCourseFill(Common.CourseFill courseFill)
        {
            var dbItem = new Datalayer.CourseFill()
            {
                courseID = courseFill.courseID,
                subjectID = courseFill.subjectID,
                subjectHoursPerWeek = courseFill.SubjectHoursPerWeek
            };
            context.CourseFill.Add(dbItem);
            if (context.SaveChanges() > 0)
                return true;
            return false;
        }

        public bool? UpdateCourseFill(Common.CourseFill courseFill)
        {
            var tmpCourseFill = context.CourseFill.Where(cFill => cFill.courseFillID == courseFill.courseFillID).Single();
            tmpCourseFill.courseID = courseFill.courseID;
            tmpCourseFill.subjectID = courseFill.subjectID;
            tmpCourseFill.subjectHoursPerWeek = courseFill.SubjectHoursPerWeek;
            if (context.SaveChanges() > 0)
                return true;
            return false;
        }

        public bool? DeleteCourseFill(int courseFillID)
        {
            var tmpCourseFill = context.CourseFill.Where(cFill => cFill.courseFillID == courseFillID).Single();
            context.CourseFill.Remove(tmpCourseFill);
            if (context.SaveChanges() > 0)
                return true;
            return false;
        }
        public Common.CourseFill GetCoursFillByID(int courseFillID)
        {
            var dbCourseFill = context.CourseFill.Where(cf => cf.courseFillID == courseFillID).Single();
            return dbCourseFill.ToCourseFill();
        }

        public Common.GroupCourse GetGroupCoursByID(int id)
        {
            var dbGroupCourse = context.GroupCourse.Where(gc => gc.groupCourseID == id).Single();
            return dbGroupCourse.ToGroupCourse();
        }

        public IEnumerable<Requirement> GetRequirements()
        {
            var dbList = context.SRRequirement.ToList();
            var reqList = new List<Requirement>();

            foreach (var item in dbList)
            {
                var req = new Requirement() { ID = item.ID, Name = item.Requirement };
                reqList.Add(req);
            }

            return reqList;
        }

        public bool AddRequirement(Common.Requirement model)
        {
            var dbreq = new Datalayer.SRRequirement()
            {
                Requirement = model.Name
            };
            context.SRRequirement.Add(dbreq);
            if (context.SaveChanges() > 0)
                return true;
            return false;

        }


        public bool? CreateSubject(Common.Subject subject)
        {
            var dbSubject = new Datalayer.Subject()
            {
                subjectName = subject.SubjectName
            };


            if (subject.Requirements != null)
            {
                var reqList = new List<Datalayer.SRRequirement>();
                foreach (var item in subject.Requirements)
                {
                    var srReq = context.SRRequirement.Where(req => req.ID == item).FirstOrDefault();
                    if (srReq != null)
                        reqList.Add(srReq);
                }
                dbSubject.SRRequirement = reqList;
            }
            context.Subject.Add(dbSubject);

            if (context.SaveChanges() > 0)
                return true;
            return false;

        }

        public bool? UpdateSubject(Common.Subject subject)
        {
            var dbSubj = context.Subject.Where(subj => subj.subjectID == subject.SubjectID).FirstOrDefault();
            if (dbSubj != null)
            {
                dbSubj.subjectName = subject.SubjectName;
                if (subject.Requirements != null)
                {
                    var removeList = new List<SRRequirement>();
                    foreach (var item in dbSubj.SRRequirement)
                    {
                        if (subject.Requirements.Contains(item.ID))
                            continue;
                        else
                            removeList.Add(item);
                    }
                    foreach (var item in removeList)
                    {
                        dbSubj.SRRequirement.Remove(item);
                    }
                    var reqList = dbSubj.SRRequirement.Select(r => r.ID);
                    var fullreqList = context.SRRequirement.ToList();
                    foreach (var item in subject.Requirements)
                    {
                        if (!reqList.Contains(item))
                        {
                            var tmp = fullreqList.Where(r => r.ID == item).FirstOrDefault();
                            if (tmp != null)
                                dbSubj.SRRequirement.Add(tmp);
                        }
                    }

                }
                else
                {
                    dbSubj.SRRequirement.Clear();
                }
            }
            if (context.SaveChanges() > 0)
                return true;
            return false;
        }

        public bool? DeleteSubject(int id)
        {
            var subj = context.Subject.Where(s => s.subjectID == id).FirstOrDefault();
            if (subj != null)
            {
                context.Subject.Remove(subj);
                if (context.SaveChanges() > 0)
                    return true;
            }
            return false;
        }

        public bool? CreateGroupCours(Common.GroupCourse gCourse)
        {
            var dbItem = new Datalayer.GroupCourse()
            {
                courseID = gCourse.CourseID,
                groupID = gCourse.GroupID,
                startDate = gCourse.StartDate,
                endDate = gCourse.EndDate
            };
            context.GroupCourse.Add(dbItem);
            if (context.SaveChanges() > 0)
                return true;
            return false;
        }

        public bool? UpdateGroupCours(Common.GroupCourse gCourse)
        {
            var tmpGroupCours = context.GroupCourse.Where(gc => gc.groupCourseID == gCourse.GroupCourseID).Single();
            tmpGroupCours.courseID = gCourse.CourseID;
            tmpGroupCours.groupID = gCourse.GroupID;
            tmpGroupCours.startDate = gCourse.StartDate;
            tmpGroupCours.endDate = gCourse.EndDate;
            if (context.SaveChanges() > 0)
                return true;
            return false;
        }

        public bool? DeleteGroupCours(int id)
        {
            var tmpGroupCours = context.GroupCourse.Where(gc => gc.groupCourseID == id).Single();
            context.GroupCourse.Remove(tmpGroupCours);
            if (context.SaveChanges() > 0)
                return true;
            return false;
        }

        public bool? CreateLessonOrder(Common.LessonOrder lOrder)
        {
            var dbItem = new Datalayer.LessonOrder()
            {
                ID = lOrder.lessonOrderID,
                TimeStart = lOrder.timeStart,
                TimeEnd = lOrder.timeEnd
            };
            context.LessonOrder.Add(dbItem);
            if (context.SaveChanges() > 0)
                return true;
            return false;
        }

        public bool? UpdateLessonOrder(Common.LessonOrder lOrder)
        {
            var tmpLessonOrder = context.LessonOrder.Where(lo => lo.ID == lOrder.lessonOrderID).Single();
            tmpLessonOrder.TimeStart = lOrder.timeStart;
            tmpLessonOrder.TimeEnd = lOrder.timeEnd;
            if (context.SaveChanges() > 0)
                return true;
            return false;
        }

        public bool? DeleteLessonOrder(int id)
        {
            var tmpLessonOrder = context.LessonOrder.Where(lo => lo.ID == id).Single();
            context.LessonOrder.Remove(tmpLessonOrder);
            if (context.SaveChanges() > 0)
                return true;
            return false;
        }

		public bool? CreateTask (Common.Task task)
		{
			var dbItem = new Datalayer.Task()
			{
				lessonDateID = task.lessonDateID,
				homeTask = task.homeTask,
				expiryDate = task.expiryDate
			};
			context.Task.Add(dbItem);
			if (context.SaveChanges() > 0)
				return true;
			return false;
		}

		public bool? UpdateTask (Common.Task task)
		{
			var tmpTask = context.Task.Where(t => t.taskID == task.taskID).Single();
			tmpTask.lessonDateID = task.lessonDateID;
			tmpTask.homeTask = task.homeTask;
			tmpTask.expiryDate = task.expiryDate;
			if (context.SaveChanges() > 0)
				return true;
			return false;
		}

		public bool? DeleteTask (long id)
		{
			var tmpTask = context.Task.Where(t => t.taskID == id).Single();
			context.Task.Remove(tmpTask);
			if (context.SaveChanges() > 0)
				return true;
			return false;
		}

        public Common.LessonOrder GetLessonOrderByID(int id)
        {
            var tmpLessonOrder = context.LessonOrder.Where(lo => lo.ID == id).Single();
            return tmpLessonOrder.ToLessonOrder();
        }

        public Common.Room GetRoomByID(int id)
        {
            var dbroom = context.Room.Where(r => r.roomID == id).Single();
            if (dbroom != null)
            {
                var rm = new Common.Room()
                {
                    ID = dbroom.roomID,
                    RoomNo = dbroom.roomNo,
                    Capacity = dbroom.capacity,
                    IsAvailable = dbroom.isAvailable,
                    SelectedPossibilities = dbroom.SRRequirement.Select(r => r.ID).ToList()
                };
                return rm;
            }
            return null;
        }

        public bool? AddRoom(Common.Room room)
        {
            var item = new Datalayer.Room()
            {
                capacity = room.Capacity,
                isAvailable = room.IsAvailable,
                roomNo = room.RoomNo
            };

            if (room.SelectedPossibilities != null)
            {
                var pList = new List<SRRequirement>();
                foreach (var p in room.SelectedPossibilities)
                {
                    var pos = context.SRRequirement.Where(ps => ps.ID == p).FirstOrDefault();
                    if (pos != null)
                        pList.Add(pos);
                    else
                        return false;

                }
                item.SRRequirement = pList;
            }
            context.Room.Add(item);
            if (context.SaveChanges() > 0)
                return true;
            return false;
        }

        public bool? EditRoom(Common.Room room)
        {
            var rm = context.Room.Where(r => r.roomID == room.ID).FirstOrDefault();
            if (rm != null)
            {
                if (!string.IsNullOrWhiteSpace(room.RoomNo) && !rm.roomNo.Equals(room.RoomNo))
                    rm.roomNo = room.RoomNo;
                if (room.Capacity > 0)
                    rm.capacity = room.Capacity;
                rm.isAvailable = room.IsAvailable;


                if (room.SelectedPossibilities != null)
                {
                    var removeList = new List<SRRequirement>();
                    foreach (var item in rm.SRRequirement)
                    {
                        if (room.SelectedPossibilities.Contains(item.ID))
                            continue;
                        else
                            removeList.Add(item);
                    }
                    foreach (var item in removeList)
                    {
                        rm.SRRequirement.Remove(item);
                    }
                    var reqList = rm.SRRequirement.Select(r => r.ID);
                    var fullreqList = context.SRRequirement.ToList();
                    foreach (var item in room.SelectedPossibilities)
                    {
                        if (!reqList.Contains(item))
                        {
                            var tmp = fullreqList.Where(r => r.ID == item).FirstOrDefault();
                            if (tmp != null)
                                rm.SRRequirement.Add(tmp);
                        }
                    }

                }
                else
                {
                    rm.SRRequirement.Clear();
                }
                if (context.SaveChanges() > 0)
                    return true;

            }

            return false;
        }

        public bool? DeleteRoom(int id)
        {
            var subj = context.Room.Where(s => s.roomID == id).FirstOrDefault();
            if (subj != null)
            {
                context.Room.Remove(subj);
                if (context.SaveChanges() > 0)
                    return true;
            }
            return false;
        }

        public Common.UniversityGroup GetGroupByID(int id)
        {
            var result = new Common.UniversityGroup();
            var dbgr = context.UniversityGroup.Where(g => g.groupID == id).FirstOrDefault();
            if (dbgr != null)
            {
                result.GroupID = id;
                result.GroupName = dbgr.groupName;
                result.SupervisorID = dbgr.supervisorID;
                result.CreationDate = dbgr.creationDate;
                result.elderID = dbgr.elderID;
                result.FacultyID = dbgr.facultyID;
            }
            return result;
        }

        public bool? AddGroup(Common.UniversityGroup group)
        {
            Datalayer.UniversityGroup dbGr = new Datalayer.UniversityGroup()
            {
                groupName = group.GroupName,
                facultyID = group.FacultyID,
                creationDate = group.CreationDate,
                supervisorID = group.SupervisorID,
                elderID = group.elderID

            };
            context.UniversityGroup.Add(dbGr);
            if (context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public bool? EditGroup(Common.UniversityGroup group)
        {
            var dbgr = context.UniversityGroup.Where(g => g.groupID == group.GroupID).FirstOrDefault();
            if (dbgr != null)
            {
                bool IsChanged = false;
                if (!dbgr.groupName.Equals(group.GroupName))
                { dbgr.groupName = group.GroupName; IsChanged = true; }
                if (dbgr.supervisorID != group.SupervisorID)
                {
                    if (group.SupervisorID == 0)
                        dbgr.supervisorID = null;
                    else
                        dbgr.supervisorID = group.SupervisorID;
                    IsChanged = true;
                }
                if (dbgr.elderID != group.elderID && group.elderID != 0)
                {
                    if (group.elderID == 0)
                        dbgr.elderID = null;
                    else
                        dbgr.elderID = group.elderID; IsChanged = true;
                }
                if (IsChanged)
                {
                    if (context.SaveChanges() > 0)
                        return true;
                    else return false;
                }

            }

            return false;
        }

        public bool? DeleteGroup(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetStudentsWOGroups()
        {
            //var role = context.Role.Where(rl => rl.Name == "Student").ToList().First();
            var studInGroupsList = context.StudentGroup.Select(st => st.EIMSUser).ToList();
            var dbStudList = context.EIMSUser.Where(usr => usr.Role.Select(r => r.Name).Contains("Student")).ToList().Except(studInGroupsList).ToList();

            List<Common.User> result = new List<User>();
            foreach (var item in dbStudList)
            {
                var tmp = item.ToUser();
                result.Add(tmp);
            }

            return result;
        }

        public void SeedValues()
        {

        }

        public bool AssignStudent(int groupID, long studentID)
        {
            StudentGroup assignment = new StudentGroup()
            {
                groupID = groupID,
                studentID = studentID,
                enrollmentDate = DateTime.Today.Date,
            };
            context.StudentGroup.Add(assignment);
            if (context.SaveChanges() > 0)
                return true;
            return false;
        }

        public bool DeassignStudent(int groupID, long studentID)
        {
            var deassignment = context.StudentGroup.Where(d => d.groupID == groupID && d.studentID == studentID).FirstOrDefault();
            if (deassignment != null)
            {
                context.StudentGroup.Remove(deassignment);
                if (context.SaveChanges() > 0)
                    return true;
            }
            return false;
        }
    }
}

