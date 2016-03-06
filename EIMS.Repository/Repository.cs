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
            throw new NotImplementedException();
        }

        public IEnumerable<Common.Faculty> GetFaculties()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Common.Room> GetRooms()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetStudents()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Common.Subject> GetSubjects()
        {
            throw new NotImplementedException();
        }

        public Teacher GetTeacherByID(long ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Teacher> GetTeachers()
        {
            throw new NotImplementedException();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Repository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion



        //public void Dispose()
        //{
        //    context.Dispose();
        //}



        //public IEnumerable<Common.Course> GetCourses()
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<Common.Faculty> GetFaculties()
        //{
        //    var DBFacultyList = context.Faculty.ToList();
        //    var FacultyList = new List<Common.Faculty>();

        //    foreach (var item in DBFacultyList)
        //    {
        //        var tmpf = new Common.Faculty()
        //        {
        //            FacultyID = item.facultyID,
        //            Name = item.Name
        //        };
        //        FacultyList.Add(tmpf);
        //    }

        //    return FacultyList;
        //}



        //public IEnumerable<Common.Room> GetRooms()
        //{
        //    var DBRoomsList = context.Room.ToList();
        //    var RoomsList = new List<Common.Room>();

        //    foreach (var item in DBRoomsList)
        //    {
        //        var room = new Common.Room()
        //        {
        //            ID = item.roomID,
        //            RoomNo = item.roomNo,
        //            Capacity = item.capacity,
        //            Features = item.features,
        //            IsAvailable = item.isAvailable
        //        };
        //        RoomsList.Add(room);
        //    }
        //    return RoomsList;
        //}

        //public IEnumerable<Common.Student> GetStudents()
        //{
        //    var DBStudentList = context.GetUsersByRole(4);
        //    var StudentList = new List<Common.Student>();

        //    foreach (var item in DBStudentList)
        //    {
        //        var stud = new Student()
        //        {
        //            ID = item.ID,
        //            Username = item.Username,
        //            Name = item.Name,
        //            Surname = item.Surname,
        //            MiddleName = item.MiddleName,
        //            Email = item.Email,
        //            Password = item.Password,
        //            address = item.address,
        //            RoleID = item.RoleID,
        //            CreationDate = item.CreationDate,
        //            LastEditDate = item.LastEdit,
        //            photoLink = item.photoLink,
        //            sex = item.sex
        //        };

        //        StudentList.Add(stud);
        //    }

        //    return StudentList;
        //}

        //public IEnumerable<Common.Subject> GetSubjects()
        //{
        //    var SubjectList = new List<Common.Subject>();
        //    var DBSubjectList = context.Subject.ToList();

        //    foreach (var item in DBSubjectList)
        //    {
        //        Common.Subject subj = new Common.Subject()
        //        {
        //            SubjectID = item.subjectID,
        //            SubjectName = item.subjectName,
        //            Requirements = item.requirements
        //        };

        //        SubjectList.Add(subj);
        //    }

        //    return SubjectList;
        //}

        //public Teacher GetTeacherByID(long ID)
        //{
        //    var tmpTeacher = context.GetUsersByRole(3).Where(t => t.ID == ID).First();
        //    return tmpTeacher.ToTeacher();
        //}

        //public IEnumerable<Common.Teacher> GetTeachers()
        //{
        //    var DBTeacherList = context.GetUsersByRole(3);
        //    List<Teacher> TeacherList = new List<Teacher>();
        //    foreach (var item in DBTeacherList)
        //    {
        //        Teacher tmpTeacher = item.ToTeacher();
        //        TeacherList.Add(tmpTeacher);
        //    }
        //    return TeacherList;

        //}


    }
}

