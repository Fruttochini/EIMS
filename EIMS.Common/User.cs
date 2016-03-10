using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Common
{
    public class User
    {

        public long ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public System.DateTime CreationDate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string photoLink { get; set; }

        public string Country { get; set; }
        public string StateOrProvince { get; set; }
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }

        public string Gender { get; set; }
        public string LastLoginDate { get; set; }

    }
}
