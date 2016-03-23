using EIMS.AuthorizationIdentity;
using EIMS.Common;
using EIMS.Datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Repository
{
    public static class Extensions
    {

        public static User ToUser(this Datalayer.EIMSUser usr)
        {
            var tmpUsr = new Common.User()
            {
                ID = usr.Id,
                Email = usr.Email,
                Username = usr.Login,
                Password = usr.Password,
                Roles = usr.Role.Select(rol => rol.Name),
                PhoneNumber = usr.PhoneNumber
            };
            IDictionary<string, string> dict = new Dictionary<string, string>();
            var ClaimCol = usr.UserClaim.Select(cl => cl).ToList();
            foreach (var claim in ClaimCol)
            {
                dict.Add(claim.ClaimType, claim.ClaimValue);
            }
            tmpUsr.Name = dict.Keys.Contains("Name") ?
                dict["Name"] : null;
            tmpUsr.Surname = dict.Keys.Contains("Surname") ?
                dict["Surname"] : null;
            tmpUsr.Gender = dict.Keys.Contains("Gender") ?
                dict["Gender"] : null;
            tmpUsr.DateOfBirth = dict.Keys.Contains("DateOfBirth") ?
                dict["DateOfBirth"] : null;


            tmpUsr.MiddleName = dict.Keys.Contains("MiddleName") ?
                dict["MiddleName"] : null;
            tmpUsr.photoLink = dict.Keys.Contains("photoLink") ?
                dict["photoLink"] : null;

            tmpUsr.Country = dict.Keys.Contains("Country") ?
                dict["Country"] : null;
            tmpUsr.StateOrProvince = dict.Keys.Contains("StateOrProvince") ?
                dict["StateOrProvince"] : null;
            tmpUsr.StreetAddress = dict.Keys.Contains("StreetAddress") ?
                dict["StreetAddress"] : null;
            tmpUsr.PostalCode = dict.Keys.Contains("PostalCode") ?
                dict["PostalCode"] : null;

            tmpUsr.CreationDate = dict.Keys.Contains("CreationDate") ?
                DateTime.Parse(dict["CreationDate"]) : new DateTime();
            tmpUsr.LastLoginDate = dict.Keys.Contains("LastLoginDate") ?
                dict["LastLoginDate"] : null;
            return tmpUsr;
        }

        public static Common.LessonDate ToLessonDate(this Datalayer.LessonDate lsd)
        {
            var tmpDate = new Common.LessonDate()
            {
                lessonDateID = lsd.lessonDateID,
                lessonID = lsd.lessonID,
                date = lsd.date,
                TaskID = lsd.Task.Select(task => task.taskID),
                StudentID = lsd.LessonPresence.Select(stud => stud.studentID)
            };
            return tmpDate;
        }

		public static FacultyCommon ToFaculty(this Datalayer.Faculty fclt)
		{
			var tmpFaculty = new FacultyCommon()
			{
				FacultyID = fclt.facultyID,
				Name = fclt.Name
			};
			return tmpFaculty;
		}

		public static Common.CourseFill ToCourseFill(this Datalayer.CourseFill cFill)
		{
			var tmpCourseFill = new Common.CourseFill()
			{
				courseID = cFill.courseID,
				subjectID = cFill.subjectID,
				SubjectHoursPerWeek = cFill.subjectHoursPerWeek
			};
			return tmpCourseFill;
		}

		public static Common.GroupCourse ToGroupCourse(this Datalayer.GroupCourse gCourse)
		{
			var tmpGroupCourse = new Common.GroupCourse()
			{
				GroupCourseID = gCourse.groupCourseID,
				CourseID = gCourse.courseID,
				GroupID = gCourse.groupID,
				StartDate = gCourse.startDate,
				EndDate = gCourse.endDate
			};
			return tmpGroupCourse;
		}

		public static Common.LessonOrder ToLessonOrder(this Datalayer.LessonOrder lOrder)
		{
			var tmpLessonOrder = new Common.LessonOrder()
			{
				lessonOrderID = lOrder.ID,
				timeStart = lOrder.TimeStart,
				timeEnd = lOrder.TimeEnd
			};
			return tmpLessonOrder;
		}

		public static Common.LessonPresence ToLessonPrecense(this Datalayer.LessonPresence lPrecense)
		{
			var tmpLessonPrecense = new Common.LessonPresence()
			{
				lessonPresenseID = lPrecense.lessonPresenceID,
				lessonDateID = lPrecense.lessonDateID,
				studentID = lPrecense.studentID,
				presence = lPrecense.presence,
				mark = lPrecense.mark
			};
			return tmpLessonPrecense;
		}

		public static Common.Task ToTask(this Datalayer.Task task)
		{
			var tmpTask = new Common.Task()
			{
				taskID = task.taskID,
				lessonDateID = task.lessonDateID,
				homeTask = task.homeTask,
				expiryDate = task.expiryDate
			};
			return tmpTask;
		}

		public static Common.Subject ToSubject(this Datalayer.Subject subject)
		{
			var tmpSubject = new Common.Subject()
			{
				SubjectID = subject.subjectID,
				SubjectName = subject.subjectName
			};
			return tmpSubject;
		}
	}
}
