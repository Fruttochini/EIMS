using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Common
{
    public class Task
    {
        public long taskID { get; set; }
        public long lessonDateID { get; set; }
        public string homeTask { get; set; }
        public DateTime expiryDate { get; set; }

        public string subjectName { get; set; }
        public string groupName { get; set; }
    }
}
