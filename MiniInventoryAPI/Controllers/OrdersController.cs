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
        [HttpPost()]
        public async Task<IActionResult> Create(CreateOrderDTO createOrderDTO)
        {
            var createOrder = await _orderService.CreateOrderAsync(createOrderDTO);
            return CreatedAtAction(nameof(GetAll), createOrder);
        }

     
    }
}
