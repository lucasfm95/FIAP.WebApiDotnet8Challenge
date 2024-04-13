using FIAP.WebApiDotnet8Challenge.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.WebApiDotnet8Challenge.WebAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        
        return Ok(users);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok();
    }
    
    [HttpPost]
    public IActionResult Create()
    {
        //_userService.AddUser();
        return Ok();
    }
    
    [HttpPut("{id}")]
    public IActionResult Update(int id)
    {
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return Ok();
    }
}