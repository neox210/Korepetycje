using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Korepetycje.Startup))]
namespace Korepetycje
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
