using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Common
{
	public class LessonPresence
	{
		public long lessonDateID { get; set; }
		public long studentID { get; set; }
		public bool presence { get; set; }
		public byte? mark { get; set; }
	}
}
