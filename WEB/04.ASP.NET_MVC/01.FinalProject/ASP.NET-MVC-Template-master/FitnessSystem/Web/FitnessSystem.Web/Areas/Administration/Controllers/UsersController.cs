namespace FitnessSystem.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class UsersController : Controller
    {
        // GET: Administration/Users
        public ActionResult Index()
        {
            return this.View();
        }
    }
}