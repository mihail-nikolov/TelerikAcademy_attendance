namespace Task_2.Areas.Admin.Controllers
{
    using System.Web.Mvc;

    public class CategoriesController : Controller
    {
        public ActionResult Index()
        {
            ViewData["message"] = "I am the ADMIN!";
            return View();
        }
    }
}