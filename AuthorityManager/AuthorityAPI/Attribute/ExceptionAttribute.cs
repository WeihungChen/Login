using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Net.Http;
using AuthorityAPI.Models;

namespace AuthorityAPI.Attribute
{
    public class ExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            string message = string.Empty;
            if (actionExecutedContext.Exception.GetType() != typeof(CustomException))
                message = $"Exception: {actionExecutedContext.Exception.Message}";
            else
                message = actionExecutedContext.Exception.Message;

            var result = new ResultModel<object>
            {
                Success = false,
                Message = message
            };

            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(result);
        }
    }
}