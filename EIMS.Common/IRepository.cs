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
		IEnumerable<Task> GetTaskForGroupByDate(int groupID, DateTime selectDate);
        IEnumerable<LessonOrder> GetLessonOrder();
        IEnumerable<LessonPresence> GetLessonPresence();
        IEnumerable<FacultyCommon> GetFaculties();
        IEnumerable<UniversityGroup> GetGroups();
		IEnumerable<LessonDate> GetLessonsByDate(DateTime date);
        IEnumerable<CourseFill> GetCourseFillByCourse(int id);
        IEnumerable<CourseFill> GetAllCourseFill();
        IEnumerable<Requirement> GetRequirements();
        IEnumerable<GroupCourse> GetGroupByCourse(int courseID);
        IEnumerable<User> GetStudentByGroup(int groupID);
		IEnumerable<User> GetUserForGroup(long lessonDateID);



        bool AddRequirement(Requirement model);


        User GetUserByID(long ID);
        FacultyCommon GetFacultyByID(int id);
        Course GetCourseByID(int id);
        CourseFill GetCoursFillByID(int courseFillID);
        LessonOrder GetLessonOrderByID(int id);
        Room GetRoomByID(int id);
		LessonPrecenseWithOptions GetLessonPrecenseByLessonDate(long lessonDate);
		UniversityGroup GetGroupByID(int id);
		LessonPresence GetLessonPrecenseByID(long id);
		Task GetTaskByID(long id);
		LessonDate GetLessonDateByID(long id);



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
        bool? CreateCourseFill(CourseFill courseFill);
        bool? UpdateCourseFill(CourseFill courseFill);
        bool? DeleteCourseFill(int courseFillID);

        ///LessonOrder ops
        bool? CreateLessonOrder(LessonOrder lOrder);
        bool? UpdateLessonOrder(LessonOrder lOrder);
        bool? DeleteLessonOrder(int id);

        ///Subject ops
        bool? CreateSubject(Subject subject);
        bool? UpdateSubject(Subject subject);
        bool? DeleteSubject(int id);

        ///Room ops
        bool? AddRoom(Room room);
        bool? EditRoom(Room room);
        bool? DeleteRoom(int id);

        ///Groups ops
        bool? AddGroup(UniversityGroup group);
        bool? EditGroup(UniversityGroup group);
        bool? DeleteGroup(int id);

        ///GroupCours ops
        IEnumerable<Subject> GetSubjectsByGroupID(int id);
        GroupCourse GetGroupCoursByID(int id);
        bool? CreateGroupCours(GroupCourse gCourse);
        bool? UpdateGroupCours(GroupCourse gCourse);
        bool? DeleteGroupCours(int id);

        ///Studnet ops
        IEnumerable<User> GetStudentsWOGroups();
        bool AssignStudent(int groupID, long studentID);
        bool DeassignStudent(int groupID, long studentID);

        ///Lesson - Schedule ops
        IEnumerable<Lesson> GetLessonsByGroup(int id);
        IEnumerable<Lesson> GetLessonByTeacher(long id);
        IEnumerable<Lesson> GetLessonByDay(byte dayid);
        bool CreateLesson(Lesson lesson);

        ///Teacher ops
        IEnumerable<User> GetTeacherBySubject(int id);
        Teacher GetTeacherByID(long id);
        bool AssignTeacherSubjects(Teacher teacher);

		///Task ops
		bool? CreateTask(Task task);
		bool? UpdateTask(Task task);
		bool? DeleteTask(long id);

		///LessonPrecense ops
		LessonPrecenseWithOptions GetLessonPrecenseOption(long lessonDateID);
		bool? CreateLessonPrecense(Common.LessonPresence lessonPrecense);
		bool? UpdateLessonPrecense(Common.LessonPresence lessonPrecense);
	}
}
