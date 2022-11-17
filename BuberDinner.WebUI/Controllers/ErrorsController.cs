// ---------------------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lieberman Technologies, LLC. All rights reserved.
// BuberDinner > BuberDinner.WebUI > ErrorsController.cs
// Created: 11 11, 2022
// Modified: 11 11, 2022
// ---------------------------------------------------------------------------------------------------------------------------------

using BuberDinner.Application.Common.Errors;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.WebUI.Controllers;

public class ErrorsController : ControllerBase
{
    [ Route("error") ]
    public IActionResult Error()
    {
        // ReSharper disable once UnusedVariable
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        (int statusCode, string message) = exception switch
                                           {
                                               IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
                                               _                       => (StatusCodes.Status500InternalServerError, "An unexpected error occurred")
                                           };

        return Problem(statusCode: statusCode, detail: message);
    }
}
