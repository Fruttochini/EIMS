using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EIMS.Models
{
	public class CourseFillViewModel
	{
		public int courseID { get; set; }
		public int subjectID { get; set; }

		public string courseName { get; set; }
		public string subjectName { get; set; } 
		public int SubjectHoursPerWeek { get; set; }
	}
}