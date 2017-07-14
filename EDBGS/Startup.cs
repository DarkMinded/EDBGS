using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EDBGS.Startup))]
namespace EDBGS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
