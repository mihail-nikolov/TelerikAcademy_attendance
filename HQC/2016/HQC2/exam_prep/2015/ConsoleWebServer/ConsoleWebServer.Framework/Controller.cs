namespace ConsoleWebServer.Framework
{
    using ConsoleWebServer.Framework.ActionResults;
    using ConsoleWebServer.Framework.ActionResults.Contracts;

    public abstract class Controller
    {
        protected Controller(IHttpRequest request)
        {
            this.Request = request;
        }

        public IHttpRequest Request { get; private set; }

        protected IActionResult Content(object model)
        {
            return new ContentActionResult(this.Request, model);
        }

        protected IActionResult Json(object model)
        {
            return new JsonActionResult(this.Request, model);
        }
    }
}