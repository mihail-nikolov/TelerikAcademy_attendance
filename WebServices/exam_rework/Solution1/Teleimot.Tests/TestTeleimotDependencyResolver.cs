using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;
using Teleimot.Data.Common.Contracts;
using Teleimot.Data.Models;
using Teleimot.Services.Contracts;
using Teleimot.Web.Api.Controllers;

namespace Teleimot.Tests
{
    class TestTeleimotDependencyResolver : IDependencyResolver
    {
        private ICommentsService comments;

        private IUsersService users;

        public ICommentsService Comments
        {
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }

        public IUsersService Users
        {
            get
            {
                return this.users;
            }
            set
            {
                this.users = value;
            }
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            //add all controllers
            if (serviceType == typeof(CommentsController))
            {
                return new CommentsController(this.Comments as ICommentsService, this.Users as IUsersService);
            }
            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {

        }
    }
}