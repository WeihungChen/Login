using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Net.Http;
using AuthorityAPI.Models;

namespace AuthorityAPI.Attribute
{
    public class ResultAttribute : UserAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception == null)
            {
                UserManager userManager = new UserManager();
                userManager.UpdateExpires();
            }
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}