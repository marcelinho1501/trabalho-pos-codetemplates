using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Trabalho_Marcelo.Startup))]
namespace Trabalho_Marcelo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
