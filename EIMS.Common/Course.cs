using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Common
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }

		public Dictionary<int, int> SubjectByHours { get; set; }
    }
}
