using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EIMS.AuthorizationIdentity
{
    public class EIMSRoleManager : RoleManager<EIMSRole, long>
    {
        public EIMSRoleManager(IRoleStore<EIMSRole, long> store) : base(store)
        {

        }

        public static EIMSRoleManager Create(IdentityFactoryOptions<EIMSRoleManager> options, IOwinContext context)
        {
            var roleStore = new RoleStore<EIMSRole, long, EIMSUserRole>(context.Get<ApplicationDbContext>());
            return new EIMSRoleManager(roleStore);
        }
    }
}
