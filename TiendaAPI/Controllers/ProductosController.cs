using Microsoft.AspNetCore.Mvc;
using TiendaAPI.Services;

namespace TiendaAPI.Controllers;

[ApiController]
[Route("api/productos")]
public class ProductosController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductosController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productService.GetAllAsync();
        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        return product is null ? NotFound() : Ok(product);
    }

    [HttpGet("buscar")]
    public async Task<IActionResult> SearchByName([FromQuery] string nombre = "")
    {
        var products = await _productService.SearchByNameAsync(nombre);
        return Ok(products);
    }

    [HttpGet("categoria/{id:int}")]
    public async Task<IActionResult> GetByCategoryId(int id)
    {
        var products = await _productService.GetByCategoryIdAsync(id);
        return Ok(products);
    }
}