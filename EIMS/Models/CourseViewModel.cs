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
        public string subjectName { get; set; }
        public string subjectHoursPerWeek { get; set; }

        public CourseFillViewModel selectedSubject { get; set; }
        public IEnumerable<CourseFillViewModel> Subjects { get; set; }
    }
}