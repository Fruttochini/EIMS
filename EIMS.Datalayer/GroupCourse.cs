//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EIMS.Datalayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class GroupCourse
    {
        public int groupCourseID { get; set; }
        public int courseID { get; set; }
        public int groupID { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual UniversityGroup UniversityGroup { get; set; }
    }
}
