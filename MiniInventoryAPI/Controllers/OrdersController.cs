using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniInventory.Application.Service;
using MiniInventory.Domain.Entities;
using static MiniInventory.Application.DTOs.OrderDTOs;

namespace MiniInventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            return Ok( await _orderService.GetAllOrderAsync());
            
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _orderService.GetByIdOrderItemsAsync(id));

        }
        [HttpPost()]
        public async Task<IActionResult> Create(CreateOrderDTO createOrderDTO)
        {
            var createOrder = await _orderService.CreateOrderAsync(createOrderDTO);
            return CreatedAtAction(nameof(GetAll), createOrder);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id,int statusId)

        {
            statusId = 1;

            var ok = await _orderService.UpdateOrderAsync(id,statusId);
            return ok ? NoContent() : NotFound();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var statusId = 2;
            var ok = await _orderService.UpdateOrderAsync(id, statusId);
            return ok ? NoContent() : NotFound();
        }


    }
}
