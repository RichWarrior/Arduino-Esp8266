using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Arduino.API.Filters
{
    public class ArduinoAllowAnonymous : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
