namespace ConsoleWebServer.Framework
{
    using ConsoleWebServer.Framework.ActionResults.Contracts;

    public abstract class Controller
    {
        private readonly IActionResultFactory actionResultFactory;

        protected Controller(IHttpRequest request, IActionResultFactory actionResultFactory)
        {
            this.Request = request;
            this.actionResultFactory = actionResultFactory;
        }

        public IActionResultFactory ActionResultFactory
        {
            get
            {
                return this.actionResultFactory;
            }
        }

        public IHttpRequest Request { get; private set; }

        protected IActionResult Content(object model)
        {
            return this.ActionResultFactory.GetContentActionResult(this.Request, model);
        }

        protected IActionResult Json(object model)
        {   
            return this.ActionResultFactory.GetJsonActionResult(this.Request, model);
        }
    }
}