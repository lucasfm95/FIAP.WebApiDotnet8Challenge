using Microsoft.AspNetCore.Mvc;

namespace FIAP.WebApiDotnet8Challenge.WebAPI.Controllers;

[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }
}