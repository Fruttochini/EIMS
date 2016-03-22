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

        IEnumerable<LessonDate> GetLessonsByDate(DateTime date);
        IEnumerable<Common.CourseFill> GetCourseFillByCourse(int id);
        IEnumerable<Common.CourseFill> GetAllCourseFill();
        IEnumerable<Common.Requirement> GetRequirements();
        IEnumerable<Common.GroupCourse> GetGroupByCourse(int courseID);

        IEnumerable<User> GetStudentByGroup(int groupID);


        bool AddRequirement(Common.Requirement model);

        User GetUserByID(long ID);
        FacultyCommon GetFacultyByID(int id);
        Course GetCourseByID(int id);
        Common.CourseFill GetCoursFillByID(int courseFillID);
        Common.LessonOrder GetLessonOrderByID(int id);
        Common.Room GetRoomByID(int id);

        UniversityGroup GetGroupByID(int id);

        void SeedValues();


        ///Faculty ops
        bool? CreateFaculty(FacultyCommon faculty);
        bool? UpdateFaculty(FacultyCommon faculty);
        bool? DeleteFaculty(int id);

        ///Course ops
        bool? CreateCourse(Course course);
        bool? UpdateCourse(Course course);
        bool? DeleteCourse(int id);

        ///CourseFill ops
        bool? CreateCourseFill(Common.CourseFill courseFill);
        bool? UpdateCourseFill(Common.CourseFill courseFill);
        bool? DeleteCourseFill(int courseFillID);

        ///LessonOrder ops
        bool? CreateLessonOrder(Common.LessonOrder lOrder);
        bool? UpdateLessonOrder(Common.LessonOrder lOrder);
        bool? DeleteLessonOrder(int id);

        ///Subject ops
        bool? CreateSubject(Common.Subject subject);
        bool? UpdateSubject(Common.Subject subject);
        bool? DeleteSubject(int id);

        ///Room ops
        bool? AddRoom(Common.Room room);
        bool? EditRoom(Common.Room room);
        bool? DeleteRoom(int id);

        ///Groups ops
        bool? AddGroup(Common.UniversityGroup group);
        bool? EditGroup(Common.UniversityGroup group);
        bool? DeleteGroup(int id);

        ///GroupCours ops
        IEnumerable<Common.Subject> GetSubjectsByGroupID(int id);
        Common.GroupCourse GetGroupCoursByID(int id);
        bool? CreateGroupCours(Common.GroupCourse gCourse);
        bool? UpdateGroupCours(Common.GroupCourse gCourse);
        bool? DeleteGroupCours(int id);

        ///Studnet ops
        IEnumerable<User> GetStudentsWOGroups();
        bool AssignStudent(int groupID, long studentID);
        bool DeassignStudent(int groupID, long studentID);

        ///Lesson - Schedule ops
        IEnumerable<Lesson> GetLessonsByGroup(int id);
        IEnumerable<Lesson> GetLessonByTeacher(long id);
        IEnumerable<Lesson> GetLessonByDay(byte dayid);

        ///Teacher ops
        IEnumerable<User> GetTeacherBySubject(int id);

    }
}
