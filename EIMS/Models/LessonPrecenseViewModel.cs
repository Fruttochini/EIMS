using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EIMS.Models
{
	public class LessonPrecenseViewModel
	{
		public DateTime LessonDate { get; set; }
		public string StudentName { get; }
		public string TeacherName { get; set; }
		public string SubjectName { get; set; }
		public string Precense { get; }
		public string Mark { get; }

		public IEnumerable<LessonPrecenseList> RowList { get; set; }
	}

	public class LessonPrecenseList
	{
		public long LessonPrecenseID { get; set; }
		public long LessonDateID { get; set; }
		public long StudentID { get; set; }
		public bool Precense { get; set; }
		public byte? Mark { get; set; }

		public string StudentName { get; set; }
	}

	public class CreateEditPrecenseList
	{
		public long LessonDateID { get; set; }

		public IEnumerable<LessonPrecenseList> RowList { get; set; }
	}
}