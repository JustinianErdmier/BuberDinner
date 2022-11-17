// ---------------------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lieberman Technologies, LLC. All rights reserved.
// BuberDinner > BuberDinner.WebUI > ErrorsController.cs
// Created: 11 11, 2022
// Modified: 11 11, 2022
// ---------------------------------------------------------------------------------------------------------------------------------

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.WebUI.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        
        return Problem(title: exception?.Message);
    }
}
