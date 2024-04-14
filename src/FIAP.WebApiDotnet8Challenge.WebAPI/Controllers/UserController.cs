using System.ComponentModel.DataAnnotations;
using FIAP.WebApiDotnet8Challenge.Application;
using FIAP.WebApiDotnet8Challenge.Domain.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.WebApiDotnet8Challenge.WebAPI.Controllers;

//[Authorize(Roles = "Administrator")]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        
        return Ok(users);
    }
    
    [HttpGet("{userName}")]
    public IActionResult GetById([FromRoute] string userName)
    {
        var user = _userService.GetUserByUserName(userName);

        if (user == null)
        {
            return NoContent();
        }
        
        return Ok(user);
    }
    
    [HttpPost]
    public IActionResult Create([FromBody, Required] UserPostRequest request)
    {
        var user = _userService.AddUser(request);

        return Ok(user.UserName);
    }
    
    [HttpPut("{userName}")]
    public IActionResult Update([FromRoute] string userName, [FromBody, Required] UserPutRequest request)
    {
        var user = _userService.GetUserByUserName(userName);

        if (user == null)
        {
            return NoContent();
        }

        if (!_userService.UpdateUser(userName, request))
            return BadRequest("failed to update user");

        return Ok();
    }
    
    [HttpDelete("{userName}")]
    public IActionResult Delete([FromRoute] string userName)
    {
        var user = _userService.GetUserByUserName(userName);

        if (user == null)
        {
            return NoContent();
        }
        
        if(!_userService.DeleteUser(userName))
            return BadRequest("failed to delete user");

        return Ok();
    }
}