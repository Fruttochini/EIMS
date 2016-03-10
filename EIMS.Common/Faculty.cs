using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Common
{
    public class Faculty
    {
        public int FacultyID { get; set; }
        public string Name { get; set; }

		public IEnumerable<int> GroupID { get; set; }
    }
}
