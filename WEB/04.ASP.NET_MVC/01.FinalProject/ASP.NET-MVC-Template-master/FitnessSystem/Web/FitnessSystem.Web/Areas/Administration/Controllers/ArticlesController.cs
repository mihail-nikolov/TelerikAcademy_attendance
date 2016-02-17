namespace FitnessSystem.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class ArticlesController : Controller
    {
        // GET: Administration/Articles
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
