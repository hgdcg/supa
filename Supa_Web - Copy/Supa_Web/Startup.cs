using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Supa_Web.Startup))]
namespace Supa_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
