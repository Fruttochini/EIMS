using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using EIMS.Models;
using EIMS.AuthorizationIdentity;




namespace EIMS
{
    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<EIMSUser, long>
    {
        public ApplicationSignInManager(EIMSUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(EIMSUser user)
        {
            return user.GenerateUserIdentityAsync((EIMSUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<EIMSUserManager>(), context.Authentication);
        }
    }
}
