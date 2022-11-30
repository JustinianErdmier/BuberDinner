using BuberDinner.WebUI.Common.Http;

using ErrorOr;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BuberDinner.WebUI.Controllers;

[ ApiController ]
public class ApiController : ControllerBase
{
    protected IActionResult Problem(List<Error> errors)
    {
        if (! errors.Any()) return Problem();

        if (errors.All(e => e.Type == ErrorType.Validation)) return ValidationProblem(errors);

        HttpContext.Items[HttpContextItemKeys.Errors] = errors;

        return Problem(errors.First());
    }

    private IActionResult Problem(Error error)
    {
        int statusCode = error.Type switch
                         {
                             ErrorType.Validation => StatusCodes.Status400BadRequest,
                             ErrorType.Conflict   => StatusCodes.Status409Conflict,
                             ErrorType.NotFound   => StatusCodes.Status404NotFound,
                             _                    => StatusCodes.Status500InternalServerError
                         };

        return Problem(statusCode: statusCode, title: error.Description);
    }

    private IActionResult ValidationProblem(List<Error> errors)
    {
        ModelStateDictionary modelState = new ();

        errors.ForEach(e => modelState.AddModelError(e.Code, e.Description));

        return ValidationProblem(modelState);
    }
}
