// ---------------------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lieberman Technologies, LLC. All rights reserved.
// BuberDinner > BuberDinner.WebUI > ApiController.cs
// Created: 17 11, 2022
// Modified: 17 11, 2022
// ---------------------------------------------------------------------------------------------------------------------------------

using BuberDinner.WebUI.Common.Http;

using ErrorOr;

using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.WebUI.Controllers;

[ ApiController ]
public class ApiController : ControllerBase
{
    protected IActionResult Problem(List<Error> errors)
    {
        HttpContext.Items[HttpContextItemKeys.Errors]= errors;
        
        Error firstError = errors[0];

        int statusCode = firstError.Type switch
                         {
                             ErrorType.Validation => StatusCodes.Status400BadRequest,
                             ErrorType.Conflict   => StatusCodes.Status409Conflict,
                             ErrorType.NotFound   => StatusCodes.Status404NotFound,
                             _                    => StatusCodes.Status500InternalServerError
                         };

        return Problem(statusCode: statusCode, title: firstError.Description);
    }
}
