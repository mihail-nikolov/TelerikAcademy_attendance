﻿namespace FitnessSystem.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class VideosController : Controller
    {
        // GET: Administration/Videos
        public ActionResult Index()
        {
            return this.View();
        }
    }
}