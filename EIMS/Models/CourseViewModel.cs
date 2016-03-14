using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EIMS.Models
{
	public class CourseViewModel
	{
		public int CourseID { get; set; }
		public string CourseName { get; set; }

		public Dictionary<int,int> SubjectByHours { get; set; } 
	}
}