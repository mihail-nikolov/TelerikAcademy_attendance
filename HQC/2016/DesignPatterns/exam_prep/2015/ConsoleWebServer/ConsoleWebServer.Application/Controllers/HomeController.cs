namespace ConsoleWebServer.Application.Controllers
{
    using Framework;
    using Framework.ActionResults.Contracts;

    public class HomeController : Controller
    {
        public HomeController(HttpRequest request, IActionResultFactory actionResultFactory)
            : base(request, actionResultFactory)
        {
        }

        public IActionResult Index(string param)
        {
            string homePageText = "Home page :)";
            return this.Content(homePageText);
        }

        public IActionResult LivePage(string param)
        {
            string model = "Live page with no caching";

            return this.ActionResultFactory.GetContentActionResultWithNoCaching(this.Request, model);
        }

        public IActionResult LivePageForAjax(string param)
        {
            string model = "Live page with no caching and CORS";
            string corSettings = "*";

            return this.ActionResultFactory.GetContentActionResultWithCorsAndNoCaching(this.Request, model, corSettings);
        }
    }
}