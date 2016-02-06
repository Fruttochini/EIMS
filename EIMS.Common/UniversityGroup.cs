using System;
using System.Collections.Generic;

namespace EIMS.Common
{
    public class UniversityGroup
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public Nullable<long> SupervisorID { get; set; }
        public System.DateTime CreationDate { get; set; }
        public Nullable<long> elderID { get; set; }
        public int FacultyID { get; set; }

        //public IEnumerable<Student> Students { get; set; }
        //public IEnumerable<Lesson> Lessons { get; set; }
    }
}