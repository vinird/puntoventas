using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PUNTOVENTA.Startup))]
namespace PUNTOVENTA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
