﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Common
{
    public class Subject
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }

        public IEnumerable<int> Requirements { get; set; }

    }
}
