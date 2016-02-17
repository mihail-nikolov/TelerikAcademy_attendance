using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PingPongHW.Startup))]
namespace PingPongHW
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
