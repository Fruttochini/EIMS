//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EIMS.Datalayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class UniversityGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UniversityGroup()
        {
            this.GroupCourse = new HashSet<GroupCourse>();
            this.Lesson = new HashSet<Lesson>();
            this.StudentGroup = new HashSet<StudentGroup>();
        }
    
        public int groupID { get; set; }
        public string groupName { get; set; }
        public Nullable<long> supervisorID { get; set; }
        public System.DateTime creationDate { get; set; }
        public Nullable<long> elderID { get; set; }
        public int facultyID { get; set; }
    
        public virtual EIMSUser EIMSUser { get; set; }
        public virtual EIMSUser EIMSUser1 { get; set; }
        public virtual Faculty Faculty { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GroupCourse> GroupCourse { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lesson> Lesson { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentGroup> StudentGroup { get; set; }
    }
}
