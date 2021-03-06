﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EIMS.Models
{
    public class TeachersViewModel
    {
        public long LessonID { get; set; }
        public byte DayID { get; set; }
        public int OrderID { get; set; }
        public string Subject { get; set; }
        public string Teacher { get; set; }
        public string RoomNo { get; set; }

        public long LessonDateID { get; set; }
        public TimeSpan LessonStart { get; set; }
        public TimeSpan LessonEnd { get; set; }
        public string DateOfWeek { get; set; }
        public DateTime LessonDate { get; set; }
    }

    public class TeacherScheduleViewModel
    {
        public long ID { get; set; }
        public string FullName { get; set; }
        public IEnumerable<DayVm> Days { get; set; }
        public IEnumerable<LessonOrderViewModel> Order { get; set; }
        public IEnumerable<LessonInfoViewModel> LessonList
        { get; set; }
        public IEnumerable<LessonInfoViewModel> tmpList { get; set; }
    }
}