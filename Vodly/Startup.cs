using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vodly.Startup))]
namespace Vodly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
