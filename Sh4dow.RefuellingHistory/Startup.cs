using Microsoft.Owin;
using Owin;
using Sh4dow.RefuellingHistory.WebApp;

[assembly: OwinStartup(typeof(Startup))]
namespace Sh4dow.RefuellingHistory.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
