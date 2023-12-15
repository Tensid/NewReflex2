using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Reflex.Services
{
    //public class SystemTextJsonResult : IActionResult
    //{
    //    private readonly object _value;
    //    private readonly JsonSerializerOptions _jsonSerializerOptions;

    //    public SystemTextJsonResult(object value, JsonSerializerOptions jsonSerializerOptions = null)
    //    {
    //        _value = value;
    //        _jsonSerializerOptions = jsonSerializerOptions ?? new JsonSerializerOptions();
    //    }

    //    public async Task ExecuteResultAsync(ActionContext context)
    //    {
    //        var response = context.HttpContext.Response;
    //        response.ContentType = "application/json";
    //        if (_value != null)
    //        {
    //            await JsonSerializer.SerializeAsync(response.Body, _value, _value.GetType(), _jsonSerializerOptions);
    //        }
    //    }
    //}

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class UseSystemTextJsonAttribute : TypeFilterAttribute
    {
        public UseSystemTextJsonAttribute() : base(typeof(UseSystemTextJsonActionFilter))
        {
        }
    }


    public class UseSystemTextJsonActionFilter : IActionFilter
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public UseSystemTextJsonActionFilter(JsonSerializerOptions jsonSerializerOptions = null)
        {
            _jsonSerializerOptions = jsonSerializerOptions ?? new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase            
        };
            
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Filters.OfType<UseSystemTextJsonActionFilter>().Any() && context.Result is ObjectResult objectResult)
            {
                //objectResult.Formatters.Add(new SystemTextJsonOutputFormatter(_jsonSerializerOptions));

                var route = context.HttpContext.Request.Path.Value;
                //if (route.Contains("/api"))
                //{
                    objectResult.Formatters.Add(new SystemTextJsonOutputFormatter(_jsonSerializerOptions));
                //}

                context.HttpContext.Response.Headers["Content-Type"] = "application/json";
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // This is called before the action method is executed
        }
    }
}