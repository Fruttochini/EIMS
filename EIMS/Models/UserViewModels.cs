using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EIMS.Models
{
    public class UserDetailsViewModel
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }

        public string Email { get; set; }

        public string photoLink { get; set; }

    }
}