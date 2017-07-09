using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Teleimot.Web.Api.App_Start;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Teleimot.Common;

[assembly: OwinStartup(typeof(Teleimot.Web.Api.Startup))]

namespace Teleimot.Web.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AutoMapperConfig.RegisterMappings(Assemblies.WebApi);
            ConfigureAuth(app);

            var httpConfig = new HttpConfiguration();
            WebApiConfig.Register(httpConfig);
            httpConfig.EnsureInitialized();
            app
               .UseNinjectMiddleware(NinjectConfig.CreateKernel)
               .UseNinjectWebApi(httpConfig);
        }
    }
}
