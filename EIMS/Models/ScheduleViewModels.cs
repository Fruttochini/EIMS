using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EIMS.Models
{
    public class ScheduleViewModel
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public IEnumerable<DayVm> Days { get; set; }
        public IEnumerable<LessonOrderViewModel> Order { get; set; }
        public IEnumerable<LessonInfoViewModel> LessonList
        { get; set; }
        public IEnumerable<LessonInfoViewModel> tmpList { get; set; }

    }

    public class LessonInfoViewModel
    {
        public long LessonID { get; set; }
        public byte DayID { get; set; }
        public int OrderID { get; set; }
        public string Subject { get; set; }
        public string Teacher { get; set; }
        public string RoomNo { get; set; }
        //Added for Personal teacher schedule
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public long LessonDateID { get; set; }
        public int SubjectID { get; set; }

    }

    public class DayVm
    {
        public byte ID { get; set; }
        public string Name { get; set; }
    }

    public class NewLessonViewModel
    {
        public GroupInfoViewModel Group { get; set; }
        public LessonOrderViewModel LesOrd { get; set; }
        public DayVm Day { get; set; }
        //public int SelectedDay { get; set; }
        public IEnumerable<SubjectInfoViewModel> Subjects { get; set; }
        public int SelectedSubject { get; set; }

        public IEnumerable<GroupUserInfo> Teachers { get; set; }
        public long SelectedTeacher { get; set; }

        public IEnumerable<RoomInfoViewModel> Rooms { get; set; }
        public int SelectedRoom { get; set; }

    }

    public class TeacherVM
    {
        public IEnumerable<GroupUserInfo> Teachers { get; set; }
        public long SelectedTeacher { get; set; }
    }
}