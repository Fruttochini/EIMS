using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EIMS.Models
{
	public class TaskViewModel
	{
		public GroupInfoViewModel SelectGroup { get; set; }
		public DateTime SelectDate { get; set; }

		public IEnumerable<TaskList> taskList { get; set; }

		public string SubjectName { get; }
		public string GroupName { get; }
		public string HomeTask { get; }
		public string ExpireDate { get; }
	}

	public class CreateEditTaskViewModel
	{
		public long taskID { get; set; }
		public long lessonDateID { get; set; }
		public string homeTask { get; set; }
		public DateTime expireDate { get; set; }

		public int SelectGroup { get; set; }
		public DateTime SelectDate { get; set; }
	}

	public class TaskList
	{
		public long taskID { get; set; }
		public long lessonDateID { get; set; }
		public string homeTask { get; set; }
		public DateTime expireDate { get; set; }

		public string SubjectName { get; set; }
		public string GroupName { get; set; }
	}
}