using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Net.Http;
using AuthorityAPI.Models;

namespace AuthorityAPI.Attribute
{
    public class UserAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception != null)
                return;
            var objectContent = actionExecutedContext.Response.Content as ObjectContent;
            var result = new ResultModel<object>
            {
                Success = true,
                Data = objectContent.Value
            };
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(result);
        }
    }
}