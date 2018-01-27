using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Jan2018DemoWebsite.Startup))]
namespace Jan2018DemoWebsite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
