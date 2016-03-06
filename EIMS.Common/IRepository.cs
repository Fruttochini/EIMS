using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Common
{
    public interface IRepository : IDisposable
    {
        IEnumerable<Teacher> GetTeachers();
        IEnumerable<Student> GetStudents();
        IEnumerable<Subject> GetSubjects();
        IEnumerable<Room> GetRooms();
        IEnumerable<Course> GetCourses();
        IEnumerable<Faculty> GetFaculties();

        Teacher GetTeacherByID(long ID);

    }
}
