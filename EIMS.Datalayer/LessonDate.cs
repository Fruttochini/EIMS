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
    
    public partial class LessonDate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LessonDate()
        {
            this.LessonPresence = new HashSet<LessonPresence>();
            this.Task = new HashSet<Task>();
        }
    
        public long lessonDateID { get; set; }
        public long lessonID { get; set; }
        public System.DateTime date { get; set; }
    
        public virtual Lesson Lesson { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LessonPresence> LessonPresence { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Task> Task { get; set; }
    }
}
