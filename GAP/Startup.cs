using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GAP.Startup))]
namespace GAP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
