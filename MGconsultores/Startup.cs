using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MGconsultores.Startup))]
namespace MGconsultores
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
