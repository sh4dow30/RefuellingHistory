using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sh4dow.RefuellingHistory.Startup))]
namespace Sh4dow.RefuellingHistory
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
