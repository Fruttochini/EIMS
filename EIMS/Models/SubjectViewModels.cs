﻿using EIMS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EIMS.Models
{
    public class SubjectInfoViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

    }
    public class CreateSubjectViewModel
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public IEnumerable<Requirement> Requirements { get; set; }
        public IEnumerable<int> SelectedRequirements { get; set; }

    }

    public class RequirementViewModel
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}