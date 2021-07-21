using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(demo_02.Startup))]
namespace demo_02
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
