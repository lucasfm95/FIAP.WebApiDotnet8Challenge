using System.ComponentModel.DataAnnotations;
using FIAP.WebApiDotnet8Challenge.Application.ProductUseCase;
using FIAP.WebApiDotnet8Challenge.Domain.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.WebApiDotnet8Challenge.WebAPI.Controllers;

[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_productService.GetAll());
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
    public IActionResult Create([FromBody, Required] ProductPostRequest request)
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