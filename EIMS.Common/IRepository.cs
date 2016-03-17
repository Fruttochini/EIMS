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
        IEnumerable<Common.CourseFill> GetCourseFillByCourse(int id);
        IEnumerable<Common.CourseFill> GetAllCourseFill();
        IEnumerable<Common.Requirement> GetRequirements();

        User GetUserByID(long ID);
        FacultyCommon GetFacultyByID(int id);
        Course GetCourseByID(int id);
        Common.CourseFill GetCoursFillByCourseSubject(int courseID, int subjectID);

        bool? CreateFaculty(FacultyCommon faculty);
        bool? UpdateFaculty(FacultyCommon faculty);
        bool? DeleteFaculty(int id);
        bool? CreateCourse(Course course);
        bool? UpdateCourse(Course course);
        bool? DeleteCourse(int id);
        bool? CreateCourseFill(Common.CourseFill courseFill);
        bool? UpdateCourseFill(Common.CourseFill courseFill);
        bool? DeleteCourseFill(int courseID, int subjectID);

        bool? CreateSubject(Common.Subject subject);
        bool? UpdateSubject(Common.Subject subject);
        bool? DeleteSubject(int id);
    }
}
