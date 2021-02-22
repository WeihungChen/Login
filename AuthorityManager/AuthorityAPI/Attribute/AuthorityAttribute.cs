using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace AuthorityAPI.Attribute
{
    public class AuthorityAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var userManager = new UserManager();
            if (userManager.IsExpired(out string userIdx))
                throw new CustomException("Permission denied!!");
        }
    }
}