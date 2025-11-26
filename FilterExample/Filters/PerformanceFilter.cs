using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace FilterExample.Filters;

// Authorization Filter
public class AuthorizedCustom : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var isAuthenticated = context.HttpContext.User.Identity?.IsAuthenticated ?? false;
        if (!isAuthenticated)
        {
            context.Result = new UnauthorizedResult();
        }
    }
}
// Resource Filter
public class CacheResourceFilter : IResourceFilter
{
    public void OnResourceExecuted(ResourceExecutedContext context)
    {
        // Logic after the action has executed
    }
    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        // Logic before the action executes
        context.HttpContext.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
    }
}
// Action Filter (*****)
public class PerformanceFilter : IActionFilter
{
    private Stopwatch _timer;

    public void OnActionExecuted(ActionExecutedContext context)
    {
        _timer.Stop();

        var elapsed = _timer.ElapsedMilliseconds;

        Console.WriteLine($"Action executed in {elapsed} ms");
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        _timer = Stopwatch.StartNew();
    }
}
// Result Filter
public class AddHeaderResultFilter : IResultFilter
{
    public void OnResultExecuting(ResultExecutingContext context)
    {
        context.HttpContext.Response.Headers.Add("X-App", "v1");
    }
    public void OnResultExecuted(ResultExecutedContext context) { }
}

// Exception Filter
public class ApiExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var pd = new ProblemDetails { Status = 500, Title = "Server error" };
        context.Result = new ObjectResult(pd) { StatusCode = 500 };
        context.ExceptionHandled = true;
    }
}



public class PerformanceAttribute : TypeFilterAttribute
{
    public PerformanceAttribute() : base(typeof(PerformanceFilter)) { }
}