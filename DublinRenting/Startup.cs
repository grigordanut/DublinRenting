using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DublinRenting.Startup))]
namespace DublinRenting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
