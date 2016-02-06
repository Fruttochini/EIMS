using System;

namespace EIMS.Common
{
    public class Student
    {
        public long ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Nullable<byte> RoleID { get; set; }
        public System.DateTime CreationDate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string photoLink { get; set; }
        public string address { get; set; }
        public bool sex { get; set; }
        public DateTime? LastEditDate { get; set; }
    }
}