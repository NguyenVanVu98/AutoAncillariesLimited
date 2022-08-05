using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutoAncillariesLimited.Startup))]
namespace AutoAncillariesLimited
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
