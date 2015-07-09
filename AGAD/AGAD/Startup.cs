using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AGAD.Startup))]
namespace AGAD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
