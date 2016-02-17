using System.Web.Mvc;

namespace Task_2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewData["message"] = "here is the about";
            return View();
        }
    }
}