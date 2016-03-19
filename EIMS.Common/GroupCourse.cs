using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Common
{
	public class GroupCourse
	{
		public int GroupCourseID { get; set; }
		public int CourseID { get; set; }
		public int GroupID { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public string CourseName { get; set; }
		public string GroupName { get; set; }
	}
}
