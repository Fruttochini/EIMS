﻿using System;
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

        public int StudentCount { get; set; }
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

    public class StudentGroupAssignmentViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Faculty { get; set; }

        public IEnumerable<GroupUserInfo> GroupStudents { get; set; }
        public IEnumerable<long> StudinGroupIDs { get; set; }

        public IEnumerable<GroupUserInfo> Students { get; set; }
        public IEnumerable<long> StudentsToAssign { get; set; }

    }




}