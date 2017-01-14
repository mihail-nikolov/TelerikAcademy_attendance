using System.Net;

namespace ConsoleWebServer.Framework.Handlers
{
    public abstract class Handler : IHandler
    {
        private IHandler Successor { get; set; }

        public virtual IHttpResponse Handle(IHttpRequest request)
        {
            if (this.CanHandle(request))
            {
                return this.HandleRequest(request);
            }

            else if (this.Successor != null)
            {
                return this.Successor.Handle(request);
            }

            string body = "Request cannot be handled.";
            return new HttpResponse(request.ProtocolVersion, HttpStatusCode.NotImplemented, body);
        }

        public abstract IHttpResponse HandleRequest(IHttpRequest request);

        protected abstract bool CanHandle(IHttpRequest request);

        public void SetSuccessor(IHandler successor)
        {
            this.Successor = successor;
        }
    }
}
