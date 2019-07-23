using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Brp.Startup))]
namespace Brp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
