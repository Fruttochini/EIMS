using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace EIMS.AuthorizationIdentity
{
    class IdentityRole : IRole<byte>
    {
        public byte Id { get; }

        public string Name { get; set; }
    }
}
