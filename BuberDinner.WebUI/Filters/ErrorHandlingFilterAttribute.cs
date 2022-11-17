// ---------------------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lieberman Technologies, LLC. All rights reserved.
// BuberDinner > BuberDinner.WebUI > ErrorHandlingFilterAttribute.cs
// Created: 11 11, 2022
// Modified: 11 11, 2022
// ---------------------------------------------------------------------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BuberDinner.WebUI.Filters;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    /// <inheritdoc />
    public override void OnException(ExceptionContext context)
    {
        // ReSharper disable once UnusedVariable
        Exception exception = context.Exception;

        var problemDetails = new ProblemDetails
        {
            Type = "https://httpstatuses.com/500", Title = "🤔 An error occurred while processing your request.", Status = StatusCodes.Status500InternalServerError,
        };

        context.Result = new JsonResult(problemDetails);

        context.ExceptionHandled = true;
    }
}
