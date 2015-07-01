using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArquivoDigital.Startup))]
namespace ArquivoDigital
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
