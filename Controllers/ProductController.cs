using FromScratch.Services;
using Microsoft.AspNetCore.Mvc;
using FromScratch.DTOs;

namespace FromScratch.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService productService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await productService.GetAllProducts();
        return Ok(products);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetProduct(Guid id)
    {
        var product = await productService.GetProductById(id);
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductDTO product)
    {
        var createdProduct = await productService.CreateProduct(product);
        return Ok(createdProduct);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] ProductDTO product)
    {
        var updatedProduct = await productService.UpdateProduct(id, product);
        return Ok(updatedProduct);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        await productService.DeleteProduct(id);
        return Ok();
    }
}