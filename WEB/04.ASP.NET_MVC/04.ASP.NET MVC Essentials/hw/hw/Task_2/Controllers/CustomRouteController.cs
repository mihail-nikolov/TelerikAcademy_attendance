using System.Web.Mvc;

namespace Task_2.Controllers
{
    public class CustomRouteController : Controller
    {
        public string GetData(string text)
        {
            return text;
            //ViewData["data"] = text;
            //return View();
        }
    }
}