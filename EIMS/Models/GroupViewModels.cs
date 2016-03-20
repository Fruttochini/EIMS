using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EIMS.Models
{
    public class GroupInfoViewModel
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Group name")]
        public string Name { get; set; }

        public string Faculty { get; set; }
        [Display(Name = "Date of Creation")]
        public string CreationDate { get; set; }

        public string Supervisor { get; set; }
        public string Elder { get; set; }
    }

    public class CRUGroupViewModel
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Group name")]
        public string Name { get; set; }


        public IEnumerable<FacultyViewModel> Faculties { get; set; }

        [Required]
        [Display(Name = "Faculty")]
        public int SelectedFaculty { get; set; }

        public IEnumerable<GroupUserInfo> TeacherList { get; set; }
        public long Supervisor { get; set; }
    
        public IEnumerable<GroupUserInfo> Students { get; set; }
        public long Elder { get; set; }
    }
    //source model
    //public class GroupViewModel
    //{
    //    public int ID { get; set; }

    //    [Required]
    //    [Display(Name = "Group name")]
    //    public string Name { get; set; }

    //    public FacultyViewModel Faculty { get; set; }
    //    public string CreationDate { get; set; }

    //    public GroupUserInfo Supervisor { get; set; }
    //    public GroupUserInfo Elder { get; set; }
    //}
}