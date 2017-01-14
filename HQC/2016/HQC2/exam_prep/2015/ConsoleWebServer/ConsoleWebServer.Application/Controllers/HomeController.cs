namespace ConsoleWebServer.Application.Controllers
{
    using Framework;
    using Framework.ActionResults;
    using Framework.ActionResults.Contracts;

    public class HomeController : Controller
    {
        public HomeController(HttpRequest request) : base(request)
        {
        }

        public IActionResult Index(string param)
        {
            string homePageText = "Home page :)";
            return this.Content(homePageText);
        }

        public IActionResult LivePage(string param)
        {
            string livePageText = "Live page with no caching";
            return new ContentActionResultWithoutCaching(this.Request, livePageText);
        }

        public IActionResult LivePageForAjax(string param)
        {
            string livePageForAjaxText = "Live page with no caching and CORS";
            string coreSettings = "*";
            return new ContentActionResultWithCorsWithoutCaching(this.Request, livePageForAjaxText, coreSettings);
        }
    }
}