using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EIMS.Models
{
	public class CourseViewModel
	{
		public int CourseID { get; set; }
		public string CourseName { get; set; }

		//public Dictionary<string,int> SubjectByHours { get; set; } 
	}

	public class CreateEditCourseFillViewModel
	{
		public int courseFillID { get; set; }
		public int courseID { get; set; }
		public int subjectID { get; set; }
		public int SubjectHoursPerWeek { get; set; }
		public string Subject { get; }

		public IEnumerable<SelectListItem> SubjectList { get; set; }
	}

	public class CourseFillList
	{
		public int courseFillID { get; set; }
		public int courseID { get; set; }
		public string subjectName { get; set; }
		public int subjectID { get; set; }
		public int SubjectHoursPerWeek { get; set; }
	}

	public class CourseFillViewModel
	{
		public CourseViewModel SelectCourse { get; set; }

		public string SubjectName { get; }
		public string SubjectHoursPerWeek { get; }

		public IEnumerable<CourseFillList> subjectList { get; set; }
	}
}