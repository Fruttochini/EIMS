using Microsoft.AspNet.Identity;
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

        //public string Name { get; set; }
        //public string Surname { get; set; }
        //public string MiddleName { get; set; }
        //public string photoLink { get; set; }

        //public string Gender { get; set; }
        //public string DateOfBirth { get; set; }

        //public string Country { get; set; }
        //public string StateOrProvince { get; set; }
        //public string StreetAddress { get; set; }
        //public string PostalCode { get; set; }

        //public string CreationDate { get; set; }
        //public string LastLoginDate { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(EIMSUserManager userManager)
        {

            var userIdentity = await userManager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            //userIdentity.AddClaim(new Claim(ClaimTypes.Name, this.Name));
            //userIdentity.AddClaim(new Claim(ClaimTypes.Surname, this.Surname));

            //userIdentity.AddClaim(new Claim(ClaimTypes.Gender, this.Gender));
            //userIdentity.AddClaim(new Claim(ClaimTypes.DateOfBirth, this.DateOfBirth));

            //userIdentity.AddClaim(new Claim("MiddleName", this.MiddleName));
            //userIdentity.AddClaim(new Claim("photoLink", this.photoLink));

            //userIdentity.AddClaim(new Claim(ClaimTypes.Country, this.Country));
            //userIdentity.AddClaim(new Claim(ClaimTypes.StateOrProvince, this.StateOrProvince));
            //userIdentity.AddClaim(new Claim(ClaimTypes.StreetAddress, this.StreetAddress));
            //userIdentity.AddClaim(new Claim(ClaimTypes.PostalCode, this.PostalCode));

            //userIdentity.AddClaim(new Claim("CreationDate", this.CreationDate));
            //userIdentity.AddClaim(new Claim("LastLoginDate", this.LastLoginDate));


            return userIdentity;
        }

    }
}
