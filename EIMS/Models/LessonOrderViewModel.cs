using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EIMS.Models
{
	public class LessonOrderViewModel
	{
		public int lessonOrderID { get; set; }
		public TimeSpan timeStart { get; set; }
		public TimeSpan timeEnd { get; set; }
	}
}