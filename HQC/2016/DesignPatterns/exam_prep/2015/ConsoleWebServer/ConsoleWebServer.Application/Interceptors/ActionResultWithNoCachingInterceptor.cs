using Ninject.Extensions.Interception;
using ConsoleWebServer.Framework;

namespace ConsoleWebServer.Application.Interceptors
{
    public class ActionResultWithNoCachingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();

            IHttpResponse httpResponse = invocation.ReturnValue as IHttpResponse;
            if (httpResponse != null)
            {
                httpResponse.AddHeader("Cache-Control", "private, max-age=0, no-cache");
            }
        }
    }
}