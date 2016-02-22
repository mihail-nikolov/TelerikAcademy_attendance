using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using FitnessSystem.Data.Models;
using FitnessSystem.Data;
using FitnessSystem.Web.Administration.ViewModels.Comments;
using FitnessSystem.Services.Data;
using FitnessSystem.Web.Infrastructure.Mapping;

namespace FitnessSystem.Web.Areas.Administration.Controllers
{
    public class ManageCommentsController : Controller
    {
        private readonly ICommentsServices comments;

        public ManageCommentsController(ICommentsServices comments)
        {
            this.comments = comments;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Comments_Read([DataSourceRequest]DataSourceRequest request)
        {
            var comments = this.comments.GetAll().To<ManageCommentsViewModel>().ToList();
            DataSourceResult result = comments.ToDataSourceResult(request);

            return this.Json(result);
        }
    }
}
