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
    
    public partial class LessonPresence
    {
        public long lessonPresenceID { get; set; }
        public long lessonDateID { get; set; }
        public long studentID { get; set; }
        public bool presence { get; set; }
        public Nullable<byte> mark { get; set; }
    
        public virtual EIMSUser EIMSUser { get; set; }
        public virtual LessonDate LessonDate { get; set; }
    }
}
