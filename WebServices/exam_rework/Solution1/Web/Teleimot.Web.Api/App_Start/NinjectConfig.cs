namespace Teleimot.Web.Api.App_Start
{
    using Ninject;
    using System;
    using Ninject.Extensions.Conventions;
    using Ninject.Web.Common;
    using System.Web;
    using Data;
    using Data.Common;
    using Data.Common.Contracts;
    using Data.Contracts;
    using Common;
    using Services.Contracts;
    using Services;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Data.Models;
    using Microsoft.AspNet.Identity;

    public static class NinjectConfig
    {
        public static object ObjectFactory { get; private set; }

        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ITeleimotDbContext>().To<TeleimotDbContext>();
            kernel.Bind(typeof(IDbRepository<>)).To(typeof(DbRepository<>));
            kernel.Bind(typeof(IUserStore<User>)).To(typeof(UserStore<User>));

            kernel.Bind(b => b
                .From(Assemblies.DataServices)
                .SelectAllClasses()
                .BindDefaultInterface());
        }
    }
}