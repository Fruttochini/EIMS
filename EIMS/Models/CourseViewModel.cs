using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EIMS.Models
{
    public class CourseViewModel
    {
        [Display(Name = "ID")]
        public int CourseID { get; set; }
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        //public Dictionary<string,int> SubjectByHours { get; set; } 
    }

    public class CreateEditCourseFillViewModel
    {
        public int courseFillID { get; set; }
        public int courseID { get; set; }
        public int subjectID { get; set; }
        [Display(Name = "Hours/Week")]
        public int SubjectHoursPerWeek { get; set; }
        [Display(Name = "Subject")]
        public string Subject { get; }

        public IEnumerable<SelectListItem> SubjectList { get; set; }
    }

    public class CourseFillList
    {
        public int courseFillID { get; set; }
        public int courseID { get; set; }
        public string subjectName { get; set; }
        public int subjectID { get; set; }
        public int SubjectHoursPerWeek { get; set; }
    }

    public class CourseFillViewModel
    {
        public CourseViewModel SelectCourse { get; set; }
        [Display(Name = "Subject")]
        public string SubjectName { get; }
        [Display(Name = "Hours/Week")]
        public string SubjectHoursPerWeek { get; }

        public IEnumerable<CourseFillList> subjectList { get; set; }
    }

    public class CreateEditGroupCourseViewModel
    {
        public int groupCourseID { get; set; }
        public int courseID { get; set; }
        public int groupID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start date")]
        public DateTime? startDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "End date")]
        public DateTime? endDate { get; set; }

        public string Group { get; }

        public IEnumerable<SelectListItem> GroupList { get; set; }
    }

    public class GroupCoursList
    {
        public int groupCourseID { get; set; }
        public int courseID { get; set; }
        public int groupID { get; set; }
        [Display(Name = "Group")]
        public string GroupName { get; set; }
        [Display(Name = "Start date")]
        public DateTime? startDate { get; set; }
        [Display(Name = "End date")]
        public DateTime? endDate { get; set; }
    }

    public class GroupCoursViewModel
    {
        public CourseViewModel SelectCourse { get; set; }

        [Display(Name = "Group")]
        public string GroupName { get; }
        [Display(Name = "Start date")]
        public string StartDate { get; }
        [Display(Name = "End date")]
        public string EndDate { get; }

        public IEnumerable<GroupCoursList> groupList { get; set; }
    }
}