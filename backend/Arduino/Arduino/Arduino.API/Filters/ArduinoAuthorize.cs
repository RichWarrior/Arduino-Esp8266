using Arduino.API.Models;
using Core.Entities;
using Core.Interfaces;
using Core.Utilities;
using Core.Utilities.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Arduino.API.Filters
{
    public class ArduinoAuthorize : Attribute,IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if(!context.Filters.Any(x=>x.GetType() == typeof(AllowAnonymousAttribute)))
            {
                using (IUnitOfWork uow = new UnitOfWork())
                {
                    var token = JWTManager.GetToken(context.HttpContext);
                    if (String.IsNullOrEmpty(token))
                    {
                        UnAuthorized(context);
                        return;
                    }
                    IDataResult<User> existsUser = uow.User.CheckToken(token);
                    if (!existsUser.Success)
                    {
                        UnAuthorized(context);
                        return;
                    }
                }                
            }
        }

        public void UnAuthorized(ActionExecutingContext context)
        {
            BaseResult<int> baseResult = new BaseResult<int>();
            baseResult.Message = "Unauthorized";

            baseResult.StatusCode = HttpStatusCode.Unauthorized;
            context.Result = new UnauthorizedObjectResult(baseResult);
        }
    }
}
