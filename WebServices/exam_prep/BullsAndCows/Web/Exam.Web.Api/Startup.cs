using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Exam.Web.Api.App_Start;
using Exam.Common.Constants;

[assembly: OwinStartup(typeof(Exam.Web.Api.Startup))]

namespace Exam.Web.Api
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
