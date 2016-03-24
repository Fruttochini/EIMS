using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EIMS.Models
{
    public class LessonPrecenseViewModel
    {
        public DateTime LessonDate { get; set; }
        public string StudentName { get; }
        public string TeacherName { get; set; }
        public string SubjectName { get; set; }
        public string Precense { get; }
        public string Mark { get; }

        public IEnumerable<LessonPrecenseList> RowList { get; set; }
    }

    public class LessonPrecenseList
    {
        public long LessonPrecenseID { get; set; }
        public long LessonDateID { get; set; }
        public long StudentID { get; set; }
        public bool Precense { get; set; }
        public byte? Mark { get; set; }

        public string StudentName { get; set; }
    }

    public class CreateEditPrecenseList
    {
        public long LessonDateID { get; set; }

        public IEnumerable<LessonPrecenseList> RowList { get; set; }
    }

    public class StudentLessonPressenceViewModel
    {
        public long LessonPrecenseID { get; set; }
        public long LessonDateID { get; set; }
        public long StudentID { get; set; }
        [Display(Name = "Present?")]
        public bool Precense { get; set; }

        public byte? Mark { get; set; }
        [Display(Name = "Student")]
        public string StudentName { get; set; }
    }

    public class GroupLessonPressenceViewModel
    {
        public DateTime Date { get; set; }
        public string SubjectName { get; set; }
        public int subjectID { get; set; }
        public string LessonOrder { get; set; }
        public int loid { get; set; }
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public IEnumerable<StudentLessonPressenceViewModel> StudentsPressense { get; set; }

        public long lessonDateID { get; set; }
        public CreateEditTaskViewModel Task { get; set; }
    }


}