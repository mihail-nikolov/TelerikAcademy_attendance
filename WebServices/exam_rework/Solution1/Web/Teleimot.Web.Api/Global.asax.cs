namespace Teleimot.Web.Api
{
    using System.Web;
    using System.Web.Http;
    using App_Start;

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            DataBaseConfig.Initialize();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
