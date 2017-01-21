using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(FitnessSystem.Web.Startup))]

namespace FitnessSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
