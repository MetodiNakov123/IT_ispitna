using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ispitnaa.Startup))]
namespace ispitnaa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
