using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Common
{
	public class LessonDate
	{
		public long lessonDateID { get; set; }
		public long lessonID { get; set; }
		public DateTime date { get; set; }

		public IEnumerable<long> TaskID { get; set; }
		public IEnumerable<long> StudentID { get; set; }
	}
}
