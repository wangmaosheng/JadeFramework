using JadeFramework.Core.Domain.Entities;
using JadeFramework.Core.Mvc.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace JadeFramework.Core.Mvc
{
    public class BaseController : Controller
    {
        public UserIdentity UserIdentity
        {
            get
            {
                return User.ToUserIdentity();
            }
        }
    }
}
