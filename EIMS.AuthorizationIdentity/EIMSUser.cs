﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;

namespace EIMS.AuthorizationIdentity
{
    public class EIMSUser : IdentityUser<long, EIMSLogin, EIMSUserRole, EIMSClaim>
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string photoLink { get; set; }
        public string address { get; set; }
        public bool sex { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(EIMSUserManager userManager)
        {
            var userIdentity = await userManager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

    }
}