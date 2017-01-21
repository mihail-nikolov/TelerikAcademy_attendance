namespace FitnessSystem.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Common;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNet.Identity;
    using Services.Data;
    using ViewModels.Users;
    using Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class ManageUsersController : BaseController
    {
        private readonly IUserServices manager;

        public ManageUsersController(IUserServices manager)
        {
            this.manager = manager;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Users_Read([DataSourceRequest]DataSourceRequest request)
        {
            var adminId = this.User.Identity.GetUserId();
            var users = this.manager.GetAll().Where(u => u.Id != adminId).To<UserViewModel>().ToList();
            DataSourceResult result = users.ToDataSourceResult(request);
            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Destroy([DataSourceRequest]DataSourceRequest request, UserViewModel userToRemove)
        {
            if (userToRemove.Id == this.User.Identity.GetUserId())
            {
                this.TempData["notification"] = "Please do not remove yourself! :)";
                return this.RedirectToAction("Index");
            }

            if (this.ModelState.IsValid)
            {
                this.manager.Delete(userToRemove.Id);
            }

            return this.Json(new[] { userToRemove }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
