using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LeadTracker.WebMVC.Startup))]
namespace LeadTracker.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
