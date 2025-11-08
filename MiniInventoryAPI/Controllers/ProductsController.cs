using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniInventory.Application.DTOs;
using MiniInventory.Application.Service;

namespace MiniInventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
      
            private readonly ProductService _service;
            public ProductsController(ProductService service)
            {
                _service = service;
            }

            [HttpGet()]
            public async Task<IActionResult> GetAll()
            {
                return Ok(await _service.GetAllProductsAsync());
            }
            //[HttpGet("Get")]
            [HttpGet("{id:int}")]
            public async Task<IActionResult> Get(int id)
            {
                var dto = await _service.GetByIdAsync(id);
                return dto == null ? NotFound() : Ok(dto);
            }
            [HttpPost()]
            public async Task<IActionResult> Create(CreateProductDTO createProductDTO)
            {
                var createdProduct = await _service.CreateProductAsync(createProductDTO);
                return CreatedAtAction(nameof(GetAll), new { id = createdProduct.ProductId }, createdProduct);
            }
            //[HttpPut("Update")] 

            [HttpPut("{id:int}")] 
            public async Task<IActionResult> Update(int id, UpdateProductDTO createProductDTO)

            {

                var ok = await _service.UpdateProductAsync(id, createProductDTO);
                return ok ? NoContent() : NotFound();
            }

             //[HttpPost("Delete")]
             [HttpDelete("{id:int}")]
            public async Task<IActionResult> Delete(int id)
            {
                var ok = await _service.RemoveProductAsync(id);
                return ok ? NoContent() : NotFound();
            }
        }
}
