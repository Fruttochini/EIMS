using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EIMS.Startup))]
namespace EIMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

        }
    }
}
