using System.ComponentModel.DataAnnotations;
using FIAP.WebApiDotnet8Challenge.Application;
using FIAP.WebApiDotnet8Challenge.Domain.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.WebApiDotnet8Challenge.WebAPI.Controllers;

[Route("api/[controller]")]
[AllowAnonymous]
public class TokenController(ITokenService tokenService) : ControllerBase
{
    [HttpPost]
    public IActionResult GenerateToken([FromBody][Required] TokenPostRequest request)
    {
        var token = tokenService.GetToken(request);

        if (token == null)
        {
            return Unauthorized();
        }

        return Ok(token);
    }
}