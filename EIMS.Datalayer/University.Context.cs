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
        public virtual DbSet<DayOfWeek> DayOfWeek { get; set; }
        public virtual DbSet<EIMSUser> EIMSUser { get; set; }
        public virtual DbSet<Faculty> Faculty { get; set; }
        public virtual DbSet<GroupCourse> GroupCourse { get; set; }
        public virtual DbSet<Lesson> Lesson { get; set; }
        public virtual DbSet<LessonDate> LessonDate { get; set; }
        public virtual DbSet<LessonOrder> LessonOrder { get; set; }
        public virtual DbSet<LessonPresence> LessonPresence { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<SRRequirement> SRRequirement { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<UniversityGroup> UniversityGroup { get; set; }
        public virtual DbSet<UserClaim> UserClaim { get; set; }
        public virtual DbSet<UserLogin> UserLogin { get; set; }
        public virtual DbSet<StudentGroup> StudentGroup { get; set; }
    
        public virtual int GetUsersByRole(Nullable<byte> role)
        {
            var roleParameter = role.HasValue ?
                new ObjectParameter("Role", role) :
                new ObjectParameter("Role", typeof(byte));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetUsersByRole", roleParameter);
        }
    
        public virtual int GetCourseByID(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetCourseByID", iDParameter);
        }
    
        public virtual int GetGroupByID(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetGroupByID", iDParameter);
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
    
        public virtual int DeleteCourse(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteCourse", iDParameter);
        }
    
        public virtual int DeleteCourseFill(Nullable<int> courseID, Nullable<int> subjectID)
        {
            var courseIDParameter = courseID.HasValue ?
                new ObjectParameter("courseID", courseID) :
                new ObjectParameter("courseID", typeof(int));
    
            var subjectIDParameter = subjectID.HasValue ?
                new ObjectParameter("subjectID", subjectID) :
                new ObjectParameter("subjectID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteCourseFill", courseIDParameter, subjectIDParameter);
        }
    
        public virtual int DeleteDayOfWeek(Nullable<byte> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(byte));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteDayOfWeek", iDParameter);
        }
    
        public virtual int DeleteFaculty(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteFaculty", iDParameter);
        }
    
        public virtual int DeleteGroupCourse(Nullable<int> courseID, Nullable<int> groupID)
        {
            var courseIDParameter = courseID.HasValue ?
                new ObjectParameter("courseID", courseID) :
                new ObjectParameter("courseID", typeof(int));
    
            var groupIDParameter = groupID.HasValue ?
                new ObjectParameter("groupID", groupID) :
                new ObjectParameter("groupID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteGroupCourse", courseIDParameter, groupIDParameter);
        }
    
        public virtual int DeleteLesson(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteLesson", iDParameter);
        }
    
        public virtual int DeleteLessonDate(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteLessonDate", iDParameter);
        }
    
        public virtual int DeleteLessonOrder(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteLessonOrder", iDParameter);
        }
    
        public virtual int DeleteLessonPresence(Nullable<int> lessonDateID, Nullable<long> studentID)
        {
            var lessonDateIDParameter = lessonDateID.HasValue ?
                new ObjectParameter("lessonDateID", lessonDateID) :
                new ObjectParameter("lessonDateID", typeof(int));
    
            var studentIDParameter = studentID.HasValue ?
                new ObjectParameter("studentID", studentID) :
                new ObjectParameter("studentID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteLessonPresence", lessonDateIDParameter, studentIDParameter);
        }
    
        public virtual int DeleteRoom(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteRoom", iDParameter);
        }
    
        public virtual int DeleteStudentGroup(Nullable<int> groupID, Nullable<long> studentID)
        {
            var groupIDParameter = groupID.HasValue ?
                new ObjectParameter("groupID", groupID) :
                new ObjectParameter("groupID", typeof(int));
    
            var studentIDParameter = studentID.HasValue ?
                new ObjectParameter("studentID", studentID) :
                new ObjectParameter("studentID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteStudentGroup", groupIDParameter, studentIDParameter);
        }
    
        public virtual int DeleteSubject(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteSubject", iDParameter);
        }
    
        public virtual int DeleteTask(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteTask", iDParameter);
        }
    
        public virtual int DeleteTeacherSubject(Nullable<int> subjectID, Nullable<int> teacherID)
        {
            var subjectIDParameter = subjectID.HasValue ?
                new ObjectParameter("subjectID", subjectID) :
                new ObjectParameter("subjectID", typeof(int));
    
            var teacherIDParameter = teacherID.HasValue ?
                new ObjectParameter("teacherID", teacherID) :
                new ObjectParameter("teacherID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteTeacherSubject", subjectIDParameter, teacherIDParameter);
        }
    
        public virtual int DeleteUniversityGroup(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteUniversityGroup", iDParameter);
        }
    
        public virtual int DeleteUser(Nullable<long> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteUser", iDParameter);
        }
    
        public virtual int GetDayOfWeekByID(Nullable<int> dayOfWeek)
        {
            var dayOfWeekParameter = dayOfWeek.HasValue ?
                new ObjectParameter("dayOfWeek", dayOfWeek) :
                new ObjectParameter("dayOfWeek", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetDayOfWeekByID", dayOfWeekParameter);
        }
    
        public virtual int GetFacultyByID(Nullable<int> facultyID)
        {
            var facultyIDParameter = facultyID.HasValue ?
                new ObjectParameter("facultyID", facultyID) :
                new ObjectParameter("facultyID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetFacultyByID", facultyIDParameter);
        }
    
        public virtual int GetLessonByID(Nullable<int> lessonID)
        {
            var lessonIDParameter = lessonID.HasValue ?
                new ObjectParameter("lessonID", lessonID) :
                new ObjectParameter("lessonID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetLessonByID", lessonIDParameter);
        }
    
        public virtual int GetLessonOrderByID(Nullable<int> orderID)
        {
            var orderIDParameter = orderID.HasValue ?
                new ObjectParameter("orderID", orderID) :
                new ObjectParameter("orderID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetLessonOrderByID", orderIDParameter);
        }
    
        public virtual int GetLessonPreesenceByID(Nullable<int> lessonPresenceID)
        {
            var lessonPresenceIDParameter = lessonPresenceID.HasValue ?
                new ObjectParameter("lessonPresenceID", lessonPresenceID) :
                new ObjectParameter("lessonPresenceID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetLessonPreesenceByID", lessonPresenceIDParameter);
        }
    
        public virtual int GetRoleByID(Nullable<int> role)
        {
            var roleParameter = role.HasValue ?
                new ObjectParameter("role", role) :
                new ObjectParameter("role", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetRoleByID", roleParameter);
        }
    
        public virtual int GetRoomByID(Nullable<int> roomID)
        {
            var roomIDParameter = roomID.HasValue ?
                new ObjectParameter("roomID", roomID) :
                new ObjectParameter("roomID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetRoomByID", roomIDParameter);
        }
    
        public virtual int GetStudentByID(Nullable<int> studentID)
        {
            var studentIDParameter = studentID.HasValue ?
                new ObjectParameter("studentID", studentID) :
                new ObjectParameter("studentID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetStudentByID", studentIDParameter);
        }
    
        public virtual int GetSuperuserByID(Nullable<int> superuserID)
        {
            var superuserIDParameter = superuserID.HasValue ?
                new ObjectParameter("superuserID", superuserID) :
                new ObjectParameter("superuserID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetSuperuserByID", superuserIDParameter);
        }
    
        public virtual int GetTaskByID(Nullable<int> taskID)
        {
            var taskIDParameter = taskID.HasValue ?
                new ObjectParameter("taskID", taskID) :
                new ObjectParameter("taskID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetTaskByID", taskIDParameter);
        }
    
        public virtual int GetTeacherByID(Nullable<int> teacherID)
        {
            var teacherIDParameter = teacherID.HasValue ?
                new ObjectParameter("teacherID", teacherID) :
                new ObjectParameter("teacherID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetTeacherByID", teacherIDParameter);
        }
    
        public virtual int InsertCourse(string coursename)
        {
            var coursenameParameter = coursename != null ?
                new ObjectParameter("coursename", coursename) :
                new ObjectParameter("coursename", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertCourse", coursenameParameter);
        }
    
        public virtual int InsertCourseFill(Nullable<int> courseID, Nullable<int> subjectID, Nullable<int> subjectHPW)
        {
            var courseIDParameter = courseID.HasValue ?
                new ObjectParameter("courseID", courseID) :
                new ObjectParameter("courseID", typeof(int));
    
            var subjectIDParameter = subjectID.HasValue ?
                new ObjectParameter("subjectID", subjectID) :
                new ObjectParameter("subjectID", typeof(int));
    
            var subjectHPWParameter = subjectHPW.HasValue ?
                new ObjectParameter("subjectHPW", subjectHPW) :
                new ObjectParameter("subjectHPW", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertCourseFill", courseIDParameter, subjectIDParameter, subjectHPWParameter);
        }
    
        public virtual int InsertDayOfWeek(string dayName)
        {
            var dayNameParameter = dayName != null ?
                new ObjectParameter("dayName", dayName) :
                new ObjectParameter("dayName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertDayOfWeek", dayNameParameter);
        }
    
        public virtual int InsertFaculty(string facultyName)
        {
            var facultyNameParameter = facultyName != null ?
                new ObjectParameter("facultyName", facultyName) :
                new ObjectParameter("facultyName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertFaculty", facultyNameParameter);
        }
    
        public virtual int InsertGroupCourse(Nullable<int> groupID, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var groupIDParameter = groupID.HasValue ?
                new ObjectParameter("groupID", groupID) :
                new ObjectParameter("groupID", typeof(int));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("startDate", startDate) :
                new ObjectParameter("startDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("endDate", endDate) :
                new ObjectParameter("endDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertGroupCourse", groupIDParameter, startDateParameter, endDateParameter);
        }
    
        public virtual int InsertLesson(Nullable<int> subjectID, Nullable<int> groupID, Nullable<long> teacherID, Nullable<int> roomID, Nullable<int> lessonOrder, Nullable<byte> dayOfWeek)
        {
            var subjectIDParameter = subjectID.HasValue ?
                new ObjectParameter("subjectID", subjectID) :
                new ObjectParameter("subjectID", typeof(int));
    
            var groupIDParameter = groupID.HasValue ?
                new ObjectParameter("groupID", groupID) :
                new ObjectParameter("groupID", typeof(int));
    
            var teacherIDParameter = teacherID.HasValue ?
                new ObjectParameter("teacherID", teacherID) :
                new ObjectParameter("teacherID", typeof(long));
    
            var roomIDParameter = roomID.HasValue ?
                new ObjectParameter("roomID", roomID) :
                new ObjectParameter("roomID", typeof(int));
    
            var lessonOrderParameter = lessonOrder.HasValue ?
                new ObjectParameter("lessonOrder", lessonOrder) :
                new ObjectParameter("lessonOrder", typeof(int));
    
            var dayOfWeekParameter = dayOfWeek.HasValue ?
                new ObjectParameter("dayOfWeek", dayOfWeek) :
                new ObjectParameter("dayOfWeek", typeof(byte));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertLesson", subjectIDParameter, groupIDParameter, teacherIDParameter, roomIDParameter, lessonOrderParameter, dayOfWeekParameter);
        }
    
        public virtual int InsertLessonDate(Nullable<long> lessonID, Nullable<System.DateTime> date)
        {
            var lessonIDParameter = lessonID.HasValue ?
                new ObjectParameter("lessonID", lessonID) :
                new ObjectParameter("lessonID", typeof(long));
    
            var dateParameter = date.HasValue ?
                new ObjectParameter("date", date) :
                new ObjectParameter("date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertLessonDate", lessonIDParameter, dateParameter);
        }
    
        public virtual int InsertLessonPresence(Nullable<long> lessonDateID, Nullable<long> studentID, Nullable<bool> presence, Nullable<byte> mark)
        {
            var lessonDateIDParameter = lessonDateID.HasValue ?
                new ObjectParameter("lessonDateID", lessonDateID) :
                new ObjectParameter("lessonDateID", typeof(long));
    
            var studentIDParameter = studentID.HasValue ?
                new ObjectParameter("studentID", studentID) :
                new ObjectParameter("studentID", typeof(long));
    
            var presenceParameter = presence.HasValue ?
                new ObjectParameter("presence", presence) :
                new ObjectParameter("presence", typeof(bool));
    
            var markParameter = mark.HasValue ?
                new ObjectParameter("mark", mark) :
                new ObjectParameter("mark", typeof(byte));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertLessonPresence", lessonDateIDParameter, studentIDParameter, presenceParameter, markParameter);
        }
    
        public virtual int InsertRoom(string roomNo, byte[] features, Nullable<short> capacity, Nullable<bool> isAvialable)
        {
            var roomNoParameter = roomNo != null ?
                new ObjectParameter("roomNo", roomNo) :
                new ObjectParameter("roomNo", typeof(string));
    
            var featuresParameter = features != null ?
                new ObjectParameter("features", features) :
                new ObjectParameter("features", typeof(byte[]));
    
            var capacityParameter = capacity.HasValue ?
                new ObjectParameter("capacity", capacity) :
                new ObjectParameter("capacity", typeof(short));
    
            var isAvialableParameter = isAvialable.HasValue ?
                new ObjectParameter("isAvialable", isAvialable) :
                new ObjectParameter("isAvialable", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertRoom", roomNoParameter, featuresParameter, capacityParameter, isAvialableParameter);
        }
    
        public virtual int InsertStudentGroup(Nullable<int> groupID, Nullable<int> studentID, Nullable<System.DateTime> enrollmentDate, Nullable<System.DateTime> graduationDate)
        {
            var groupIDParameter = groupID.HasValue ?
                new ObjectParameter("groupID", groupID) :
                new ObjectParameter("groupID", typeof(int));
    
            var studentIDParameter = studentID.HasValue ?
                new ObjectParameter("studentID", studentID) :
                new ObjectParameter("studentID", typeof(int));
    
            var enrollmentDateParameter = enrollmentDate.HasValue ?
                new ObjectParameter("enrollmentDate", enrollmentDate) :
                new ObjectParameter("enrollmentDate", typeof(System.DateTime));
    
            var graduationDateParameter = graduationDate.HasValue ?
                new ObjectParameter("graduationDate", graduationDate) :
                new ObjectParameter("graduationDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertStudentGroup", groupIDParameter, studentIDParameter, enrollmentDateParameter, graduationDateParameter);
        }
    
        public virtual int InsertSubject(string subjectname, byte[] requirements)
        {
            var subjectnameParameter = subjectname != null ?
                new ObjectParameter("subjectname", subjectname) :
                new ObjectParameter("subjectname", typeof(string));
    
            var requirementsParameter = requirements != null ?
                new ObjectParameter("requirements", requirements) :
                new ObjectParameter("requirements", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertSubject", subjectnameParameter, requirementsParameter);
        }
    
        public virtual int InsertTask(Nullable<long> lessonDateID, string homeTask, Nullable<System.DateTime> expiryDate)
        {
            var lessonDateIDParameter = lessonDateID.HasValue ?
                new ObjectParameter("lessonDateID", lessonDateID) :
                new ObjectParameter("lessonDateID", typeof(long));
    
            var homeTaskParameter = homeTask != null ?
                new ObjectParameter("homeTask", homeTask) :
                new ObjectParameter("homeTask", typeof(string));
    
            var expiryDateParameter = expiryDate.HasValue ?
                new ObjectParameter("expiryDate", expiryDate) :
                new ObjectParameter("expiryDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertTask", lessonDateIDParameter, homeTaskParameter, expiryDateParameter);
        }
    
        public virtual int InsertTeacherSubject(Nullable<int> subjectID, Nullable<int> teacherID)
        {
            var subjectIDParameter = subjectID.HasValue ?
                new ObjectParameter("subjectID", subjectID) :
                new ObjectParameter("subjectID", typeof(int));
    
            var teacherIDParameter = teacherID.HasValue ?
                new ObjectParameter("teacherID", teacherID) :
                new ObjectParameter("teacherID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertTeacherSubject", subjectIDParameter, teacherIDParameter);
        }
    
        public virtual int InsertUniversityGroup(string groupName, Nullable<long> supervisorID, Nullable<System.DateTime> creationDate, Nullable<long> elderID, Nullable<int> facultyID)
        {
            var groupNameParameter = groupName != null ?
                new ObjectParameter("groupName", groupName) :
                new ObjectParameter("groupName", typeof(string));
    
            var supervisorIDParameter = supervisorID.HasValue ?
                new ObjectParameter("supervisorID", supervisorID) :
                new ObjectParameter("supervisorID", typeof(long));
    
            var creationDateParameter = creationDate.HasValue ?
                new ObjectParameter("creationDate", creationDate) :
                new ObjectParameter("creationDate", typeof(System.DateTime));
    
            var elderIDParameter = elderID.HasValue ?
                new ObjectParameter("elderID", elderID) :
                new ObjectParameter("elderID", typeof(long));
    
            var facultyIDParameter = facultyID.HasValue ?
                new ObjectParameter("facultyID", facultyID) :
                new ObjectParameter("facultyID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertUniversityGroup", groupNameParameter, supervisorIDParameter, creationDateParameter, elderIDParameter, facultyIDParameter);
        }
    
        public virtual int InsertUser(string username, string email, string password, Nullable<byte> roleID, Nullable<System.DateTime> creationDate, string name, string surname, string middlename, string photoLink, string address, Nullable<bool> sex, Nullable<System.DateTime> lastEdit)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var roleIDParameter = roleID.HasValue ?
                new ObjectParameter("roleID", roleID) :
                new ObjectParameter("roleID", typeof(byte));
    
            var creationDateParameter = creationDate.HasValue ?
                new ObjectParameter("creationDate", creationDate) :
                new ObjectParameter("creationDate", typeof(System.DateTime));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var surnameParameter = surname != null ?
                new ObjectParameter("surname", surname) :
                new ObjectParameter("surname", typeof(string));
    
            var middlenameParameter = middlename != null ?
                new ObjectParameter("middlename", middlename) :
                new ObjectParameter("middlename", typeof(string));
    
            var photoLinkParameter = photoLink != null ?
                new ObjectParameter("photoLink", photoLink) :
                new ObjectParameter("photoLink", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("address", address) :
                new ObjectParameter("address", typeof(string));
    
            var sexParameter = sex.HasValue ?
                new ObjectParameter("sex", sex) :
                new ObjectParameter("sex", typeof(bool));
    
            var lastEditParameter = lastEdit.HasValue ?
                new ObjectParameter("lastEdit", lastEdit) :
                new ObjectParameter("lastEdit", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertUser", usernameParameter, emailParameter, passwordParameter, roleIDParameter, creationDateParameter, nameParameter, surnameParameter, middlenameParameter, photoLinkParameter, addressParameter, sexParameter, lastEditParameter);
        }
    }
}
