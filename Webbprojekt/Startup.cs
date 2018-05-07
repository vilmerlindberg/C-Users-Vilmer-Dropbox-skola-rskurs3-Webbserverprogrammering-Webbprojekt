using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Webbprojekt.Startup))]
namespace Webbprojekt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
