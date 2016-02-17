using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibrarySystem_Kendo.Startup))]
namespace LibrarySystem_Kendo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
