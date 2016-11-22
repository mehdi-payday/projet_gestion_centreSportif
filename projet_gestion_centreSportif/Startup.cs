using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(projet_gestion_centreSportif.Startup))]
namespace projet_gestion_centreSportif
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
