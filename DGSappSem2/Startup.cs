using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DGSappSem2.Startup))]
namespace DGSappSem2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
