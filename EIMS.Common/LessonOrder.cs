using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Common
{
	public class LessonOrder
	{
		public int lessonOrderID { get; set; }
		public TimeSpan timeStart { get; set; }
		public TimeSpan timeEnd { get; set; }

		public IEnumerable<long> GetLessonID { get; set; }
	}
}
