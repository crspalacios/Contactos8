using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Contactos8.Backend.Startup))]
namespace Contactos8.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
