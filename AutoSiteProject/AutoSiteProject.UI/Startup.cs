using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutoSiteProject.UI.Startup))]
namespace AutoSiteProject.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
