using Microsoft.AspNetCore.Mvc;
using System;

namespace OstadFirstMVC.Execptions;

public static class ExceptionMapper
{
    public static (int StatusCode, ProblemDetails problem) Map(Exception ex, HttpContext context)
    {
        return ex switch
        {
            NotFoundException nf => (
                StatusCodes.Status404NotFound,
                new ProblemDetails
                {
                    Title = "Resource Not Found",
                    Detail = nf.Message,
                    Type = "404",
                }
            ),
            ValidationException ve => (
                StatusCodes.Status400BadRequest,
                new ProblemDetails
                {
                    Title = "Validation Failed",
                    Detail = ve.Message,
                    Type = "404"
                }
            ),

            _ => (
                StatusCodes.Status400BadRequest,
                new ProblemDetails
                {
                    Title = "Internal Server Error",
                    Detail = "Un expected",
                    Type = "404"
                }
            )
        };
    }
}
