using OstadFirstMVC.Execptions;
using System.Diagnostics;

namespace OstadFirstMVC.Middleware;

public class GlobalExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
		try
		{
			await next(context);
		}
		catch (Exception ex)
		{
			var (statusCode, problem) = ExceptionMapper.Map(ex, context);
			problem.Extensions["traceId"] = Activity.Current?.Id ?? context.TraceIdentifier;

			// File Log
			// Database Log

			context.Response.StatusCode = statusCode;
			context.Response.ContentType = "application/problem+json";

			await context.Response.WriteAsJsonAsync(problem);
        }
    }
}
