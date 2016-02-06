﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class EIMSEntitiesContext : DbContext
    {
        public EIMSEntitiesContext()
            : base("name=EIMSEntitiesContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<CourseFill> CourseFill { get; set; }
        public virtual DbSet<Faculty> Faculty { get; set; }
        public virtual DbSet<GroupCourse> GroupCourse { get; set; }
        public virtual DbSet<Lesson> Lesson { get; set; }
        public virtual DbSet<LessonDate> LessonDate { get; set; }
        public virtual DbSet<LessonPresence> LessonPresence { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<StudentGroup> StudentGroup { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<UniversityGroup> UniversityGroup { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<DayOfWeek> DayOfWeek { get; set; }
        public virtual DbSet<LessonOrder> LessonOrder { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
    
        public virtual ObjectResult<UserInfo> GetUsersByRole(Nullable<byte> role)
        {
            var roleParameter = role.HasValue ?
                new ObjectParameter("Role", role) :
                new ObjectParameter("Role", typeof(byte));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UserInfo>("GetUsersByRole", roleParameter);
        }
    
        public virtual ObjectResult<UserInfo> GetUsersByRole(Nullable<byte> role, MergeOption mergeOption)
        {
            var roleParameter = role.HasValue ?
                new ObjectParameter("Role", role) :
                new ObjectParameter("Role", typeof(byte));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UserInfo>("GetUsersByRole", mergeOption, roleParameter);
        }
    
        public virtual ObjectResult<Course> GetCourseByID(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Course>("GetCourseByID", iDParameter);
        }
    
        public virtual ObjectResult<Course> GetCourseByID(Nullable<int> iD, MergeOption mergeOption)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Course>("GetCourseByID", mergeOption, iDParameter);
        }
    
        public virtual ObjectResult<UniversityGroup> GetGroupByID(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UniversityGroup>("GetGroupByID", iDParameter);
        }
    
        public virtual ObjectResult<UniversityGroup> GetGroupByID(Nullable<int> iD, MergeOption mergeOption)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UniversityGroup>("GetGroupByID", mergeOption, iDParameter);
        }
    
        public virtual int GetSubjectByID(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetSubjectByID", iDParameter);
        }
    
        public virtual int GetSubjects()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetSubjects");
        }
    }
}
