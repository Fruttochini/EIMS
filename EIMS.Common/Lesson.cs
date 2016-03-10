using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Common
{
    public class Lesson
    {
        public long LessonID { get; set; }
        public int SubjectID { get; set; }
        public int GroupID { get; set; }
        public long TeacherID { get; set; }
        public int RoomID { get; set; }

        public string SubjectName { get; set; }
        public string GroupName { get; set; }
        public string TeacherFullName { get; set; }
        public string RoomNo { get; set; }

		public IEnumerable<long> LessonDateID { get; set; }
    }
}