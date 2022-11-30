using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.WebUI.Controllers;

[ Route("[controller]") ]
public class DinnersController : ApiController
{
    public IActionResult ListDinners() => Ok(Array.Empty<string>());
}
