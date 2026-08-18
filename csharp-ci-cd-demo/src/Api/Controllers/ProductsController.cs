using CiCdDemo.Api.Models;
using CiCdDemo.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CiCdDemo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ProductsController(IProductService productService) : ControllerBase
{
    [HttpGet]
    public ActionResult<IReadOnlyCollection<Product>> GetAll() => Ok(productService.GetAll());

    [HttpGet("{id:int}")]
    public ActionResult<Product> GetById(int id)
    {
        var product = productService.GetById(id);
        return product is null ? NotFound() : Ok(product);
    }

    [HttpPost]
    public ActionResult<Product> Create(CreateProductRequest request)
    {
        try
        {
            var product = productService.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }
        catch (ArgumentOutOfRangeException)
        {
            return BadRequest("Product price cannot be negative.");
        }
        catch (ArgumentException)
        {
            return BadRequest("A valid product name is required.");
        }
    }
}
