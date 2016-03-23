using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Common
{
    public class DayOfWeek
    {
        public byte DayID { get; set; }
        public string DayName { get; set; }

        public IEnumerable<long> LessonID { get; set; }
    }
}
