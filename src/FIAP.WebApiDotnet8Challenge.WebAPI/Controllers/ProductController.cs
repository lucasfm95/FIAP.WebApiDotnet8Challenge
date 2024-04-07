using System.ComponentModel.DataAnnotations;
using FIAP.WebApiDotnet8Challenge.Domain.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.WebApiDotnet8Challenge.WebAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok();
    }
    
    /// <summary>
    /// Resource to create a new product
    /// </summary>
    /// <param name="request"> data about a new product </param>
    /// <returns> return ok when inserted successful </returns>
    [HttpPost]
    public IActionResult Create([FromBody] [Required] ProductPostRequest request)
    {
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