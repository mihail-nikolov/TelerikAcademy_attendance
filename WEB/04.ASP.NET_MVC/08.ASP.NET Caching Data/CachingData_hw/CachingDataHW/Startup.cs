using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CachingDataHW.Startup))]
namespace CachingDataHW
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
