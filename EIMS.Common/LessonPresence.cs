using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Common
{
	public class LessonPresence
	{
		public long lessonPresenseID { get; set; }
		public long lessonDateID { get; set; }
		public long studentID { get; set; }
		public bool presence { get; set; }
		public byte? mark { get; set; }

		public DateTime LessonDate { get; set; }
		public string StudentName { get; set; }
		public string TeacherName { get; set; }
		public string SubjectName { get; set; }
	}
}
