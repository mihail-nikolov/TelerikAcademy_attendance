namespace FitnessSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return this.View();
        }
    }
}