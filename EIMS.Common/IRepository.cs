using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Common
{
    public interface IRepository : IDisposable
    {
        IEnumerable<User> GetUsers();

        IEnumerable<Subject> GetSubjects();
        IEnumerable<Room> GetRooms();

        IEnumerable<Course> GetCourses();
		IEnumerable<DayOfWeek> GetDayOfWeek();
		IEnumerable<Task> GetTask();
        IEnumerable<LessonOrder> GetLessonOrder();
		IEnumerable<LessonPresence> GetLessonPresence();
        IEnumerable<FacultyCommon> GetFaculties();
        IEnumerable<UniversityGroup> GetGroups();
        IEnumerable<Lesson> GetLessons();
        IEnumerable<LessonDate> GetLessonsByDate(DateTime date);

        User GetUserByID(long ID);

		FacultyCommon GetFacultyByID(int id);
		bool? CreateFaculty(FacultyCommon faculty);
		bool? UpdateFaculty(FacultyCommon faculty);
		bool? DeleteFaculty(int id);

	}
}
