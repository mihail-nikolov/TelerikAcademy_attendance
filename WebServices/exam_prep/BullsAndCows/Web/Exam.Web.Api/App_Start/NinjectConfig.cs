using System;
using Ninject.Extensions.Conventions;
using Ninject;
using Ninject.Web.Common;
using System.Web;
using Exam.Data;
using Exam.Data.Repositories;
using Exam.Common.Constants;
using Exam.Services.Data.Contracts;

namespace Exam.Web.Api.App_Start
{

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
            kernel.Bind<IGameService>().To<IGameService>();
            kernel.Bind<IExamDbContext>().To<ExamDbContext>();
            kernel.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));

            kernel.Bind(b => b
                .From(Assemblies.DataServices)
                .SelectAllClasses()
                .BindDefaultInterface());
        }
    }
}