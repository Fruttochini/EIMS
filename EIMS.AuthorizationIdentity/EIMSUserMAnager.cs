using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.AuthorizationIdentity
{
    public class EIMSUserManager : UserManager<EIMSUser, long>
    {
        public EIMSUserManager(IUserStore<EIMSUser, long> store) : base(store)
        {

        }

        public static EIMSUserManager Create(IdentityFactoryOptions<EIMSUserManager> options, IOwinContext context)
        {

            var manager = new EIMSUserManager(new UserStore<EIMSUser, EIMSRole, long, EIMSLogin, EIMSUserRole, EIMSClaim>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<EIMSUser, long>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 4,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = true,
                RequireUppercase = false,
            };
            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug in here.
            manager.RegisterTwoFactorProvider(
                "PhoneCode",
                new PhoneNumberTokenProvider<EIMSUser, long>
                {
                    MessageFormat = "Your security code is: {0}"
                });
            manager.RegisterTwoFactorProvider(
                "EmailCode",
                new EmailTokenProvider<EIMSUser, long>
                {
                    Subject = "Security Code",
                    BodyFormat = "Your security code is: {0}"
                });
            //manager.EmailService = new EmailService();
            //manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<EIMSUser, long>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;

        }


    }
}
